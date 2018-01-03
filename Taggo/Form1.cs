using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HelloTaggo {
    public partial class Form1 : Form {
        const string tag_delimiter = " ";
        private bool valid_file_loaded = false;
        string original_file_path;

        private HashSet<string> tags;
        private string tag_file_directory;
        private string tag_file_path = "";
        public Form1() {
            InitializeComponent();
            tags = new HashSet<string>();
            tag_file_directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            tag_file_directory = Path.Combine(tag_file_directory, "HelloTaggo");
            tag_file_path = Path.Combine(tag_file_directory, "default_tag_set.txt");

            LoadTagSet();
            tagControl.SetupAutoComplete(tags.ToArray()); //update autocomplete
        }

        private void LoadTagSet() {
            if (File.Exists(tag_file_path)) {
                string[] tag_list = File.ReadAllLines(tag_file_path);
                foreach (string tag in tag_list) {
                    if (!tags.Contains(tag)) {
                        tags.Add(tag);
                    }
                }
            }
        }

        private void SaveTagSet() {
            LoadTagSet();
            Directory.CreateDirectory(tag_file_directory);
            File.WriteAllLines(tag_file_path, tags.ToArray());
        }

        private void tagControl_KeyUp(object sender, KeyEventArgs e) {

        }

        private void SubmitButton_Click(object sender, EventArgs e) {
            //revalidate file
            if (tagControl.Tags.Count > 0 && valid_file_loaded && Validate_File(original_file_path)) {
                string original_file_dir = Path.GetDirectoryName(original_file_path);
                string output_file_name = String.Join(tag_delimiter, tagControl.Tags.ToArray());
                string extension = Path.GetExtension(original_file_path);
                string output_file_path = Path.Combine(original_file_dir, output_file_name + extension);
                string unique_output_path = output_file_path;
                //handle_duplicate_names
                uint dup_number = 1;
                //if not updating a file and a file with a duplicate name exists, append [#] to the output
                while (unique_output_path != original_file_path && File.Exists(unique_output_path)) {
                    unique_output_path = Path.Combine(original_file_dir, output_file_name + "[" + dup_number + "]" + extension);
                    dup_number++;
                }
                output_file_path = unique_output_path;
                Console.WriteLine("new file: " + output_file_path);
                File.Move(original_file_path, output_file_path);
                Console.WriteLine("File moved successfully");

                //track tags used in this file
                foreach (string tag in tagControl.Tags) {
                    if (!string.IsNullOrWhiteSpace(tag) && !tags.Contains(tag)) {
                        tags.Add(tag);
                    }
                }
                //switch target to new file, allowing continuous edits
                SetOriginalFile(output_file_path, false);
                SaveTagSet(); //persist new tags to file (if any)
                tagControl.SetupAutoComplete(tags.ToArray()); //update autocomplete
            }
        }

        bool Validate_File(string path) {

            if (!File.Exists(path)) {
                Console.WriteLine("file does not exist");
                return false;
            }
            /*if (string.IsNullOrWhiteSpace(Path.GetExtension(path))) {
                Console.WriteLine("no file extension");
                return false;
            }*/

            return true;
        }

        private void SetOriginalFile(string path , bool clear_tags = true) {
            bool valid = Validate_File(path);
            if (valid) {
                valid_file_loaded = true;
                //if file to load is not the currently loaded file
                if (original_file_path != path && clear_tags) {
                    //loaded a different file
                    tagControl.Tags = new List<string>(); //clear tags in ui
                }
                original_file_path = path;
                fileNameLabel.Text = path;

            } else {
                original_file_path = "";
                valid_file_loaded = false;
                //throw new Exception("invalid file loaded");
            }
        }

        private void fileDropPanel_DragDrop(object sender, DragEventArgs e) {
            string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (data != null && data.Length > 0) {
                string input_path = data[0];
                Console.WriteLine(input_path);
                SetOriginalFile(input_path);
            }
        }

        private void fileDropPanel_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
    }
}

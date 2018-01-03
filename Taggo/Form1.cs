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

        private bool valid_file_loaded = false;
        string original_file_path;

        private HashSet<string> tags;
        public Form1() {
            InitializeComponent();
            tags = new HashSet<string>();

            /*string[] args = Environment.GetCommandLineArgs();
            /*foreach (string s in args) {
                Console.WriteLine("FORM ARG: " + s);
            }*/
           /* string path = args[1];
            Console.WriteLine("LOAD PATH: " + path);
            SetOriginalFile(path);
            Console.WriteLine("File is valid: " + valid_file_loaded.ToString());*/
        }

        private void tagControl_KeyUp(object sender, KeyEventArgs e) {

        }

        private void SubmitButton_Click(object sender, EventArgs e) {
            //revalidate file
            if (tagControl.Tags.Count > 0 && valid_file_loaded && Validate_File(original_file_path)) {
                string original_file_dir = Path.GetDirectoryName(original_file_path);
                string output_file_name = String.Join("-", tagControl.Tags.ToArray());
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

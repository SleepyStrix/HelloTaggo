namespace HelloTaggo {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.tagControl = new FerretLib.WinForms.Controls.TagListControl();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fileDropPanel = new System.Windows.Forms.Panel();
            this.fileNameLabel = new System.Windows.Forms.TextBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Tags Here";
            // 
            // tagControl
            // 
            this.tagControl.Location = new System.Drawing.Point(220, 39);
            this.tagControl.Name = "tagControl";
            this.tagControl.Size = new System.Drawing.Size(332, 250);
            this.tagControl.TabIndex = 0;
            this.tagControl.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("tagControl.Tags")));
            this.tagControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tagControl_KeyUp);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(477, 304);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 2;
            this.SubmitButton.Text = "Rename";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Drop File Here";
            // 
            // fileDropPanel
            // 
            this.fileDropPanel.AllowDrop = true;
            this.fileDropPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.fileDropPanel.Location = new System.Drawing.Point(14, 39);
            this.fileDropPanel.Name = "fileDropPanel";
            this.fileDropPanel.Size = new System.Drawing.Size(200, 250);
            this.fileDropPanel.TabIndex = 6;
            this.fileDropPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileDropPanel_DragDrop);
            this.fileDropPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileDropPanel_DragEnter);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.CausesValidation = false;
            this.fileNameLabel.Enabled = false;
            this.fileNameLabel.Location = new System.Drawing.Point(13, 13);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fileNameLabel.Size = new System.Drawing.Size(201, 20);
            this.fileNameLabel.TabIndex = 7;
            this.fileNameLabel.Text = "File name shown here";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 335);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tagControl);
            this.Controls.Add(this.fileDropPanel);
            this.Name = "Form1";
            this.Text = "HelloTaggo File Tagger";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FerretLib.WinForms.Controls.TagListControl tagControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel fileDropPanel;
        private System.Windows.Forms.TextBox fileNameLabel;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}


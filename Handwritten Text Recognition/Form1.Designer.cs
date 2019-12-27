namespace handwritten_text_recognition
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.loadImageButton = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.recognizeTextLabel = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.imageLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imageGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.copyLabel = new System.Windows.Forms.Label();
            this.copyTextButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.imageGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadImageButton
            // 
            this.loadImageButton.BackColor = System.Drawing.Color.SlateGray;
            this.loadImageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loadImageButton.ImageKey = "image_50px.png";
            this.loadImageButton.ImageList = this.imageList1;
            this.loadImageButton.Location = new System.Drawing.Point(10, 16);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(46, 48);
            this.loadImageButton.TabIndex = 2;
            this.loadImageButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.loadImageButton, "Load Image From PC");
            this.loadImageButton.UseVisualStyleBackColor = false;
            this.loadImageButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-account-50.png");
            this.imageList1.Images.SetKeyName(1, "icons8-bookmark-50.png");
            this.imageList1.Images.SetKeyName(2, "icons8-bright-mind-50.png");
            this.imageList1.Images.SetKeyName(3, "icons8-calendar-50.png");
            this.imageList1.Images.SetKeyName(4, "icons8-cancel-50.png");
            this.imageList1.Images.SetKeyName(5, "icons8-checkmark-50.png");
            this.imageList1.Images.SetKeyName(6, "icons8-clock-50.png");
            this.imageList1.Images.SetKeyName(7, "icons8-cloud-business-50.png");
            this.imageList1.Images.SetKeyName(8, "icons8-combo-chart-50.png");
            this.imageList1.Images.SetKeyName(9, "icons8-completed-task-50.png");
            this.imageList1.Images.SetKeyName(10, "icons8-connect-50.png");
            this.imageList1.Images.SetKeyName(11, "icons8-customer-insights-manager-50.png");
            this.imageList1.Images.SetKeyName(12, "icons8-delete-50.png");
            this.imageList1.Images.SetKeyName(13, "icons8-download-from-the-cloud-50.png");
            this.imageList1.Images.SetKeyName(14, "icons8-edit-50.png");
            this.imageList1.Images.SetKeyName(15, "icons8-facebook-old-50.png");
            this.imageList1.Images.SetKeyName(16, "icons8-file-50.png");
            this.imageList1.Images.SetKeyName(17, "icons8-financial-analytics-50.png");
            this.imageList1.Images.SetKeyName(18, "icons8-idea-50.png");
            this.imageList1.Images.SetKeyName(19, "icons8-image-file-50.png");
            this.imageList1.Images.SetKeyName(20, "icons8-inspection-50.png");
            this.imageList1.Images.SetKeyName(21, "icons8-instagram-50.png");
            this.imageList1.Images.SetKeyName(22, "icons8-lock-50.png");
            this.imageList1.Images.SetKeyName(23, "icons8-management-50.png");
            this.imageList1.Images.SetKeyName(24, "icons8-ok-50.png");
            this.imageList1.Images.SetKeyName(25, "icons8-people-50.png");
            this.imageList1.Images.SetKeyName(26, "icons8-picture-50.png");
            this.imageList1.Images.SetKeyName(27, "icons8-plus-50.png");
            this.imageList1.Images.SetKeyName(28, "icons8-refresh-50.png");
            this.imageList1.Images.SetKeyName(29, "icons8-remove-50.png");
            this.imageList1.Images.SetKeyName(30, "icons8-restart-50.png");
            this.imageList1.Images.SetKeyName(31, "icons8-scroll-50.png");
            this.imageList1.Images.SetKeyName(32, "icons8-search-50.png");
            this.imageList1.Images.SetKeyName(33, "icons8-settings-50.png");
            this.imageList1.Images.SetKeyName(34, "icons8-share-3-50.png");
            this.imageList1.Images.SetKeyName(35, "icons8-speech-bubble-50.png");
            this.imageList1.Images.SetKeyName(36, "icons8-support-50.png");
            this.imageList1.Images.SetKeyName(37, "icons8-synchronize-50.png");
            this.imageList1.Images.SetKeyName(38, "icons8-target-50.png");
            this.imageList1.Images.SetKeyName(39, "icons8-tick-box-50.png");
            this.imageList1.Images.SetKeyName(40, "icons8-toolbox-50.png");
            this.imageList1.Images.SetKeyName(41, "icons8-trash-50.png");
            this.imageList1.Images.SetKeyName(42, "icons8-trash-can-50.png");
            this.imageList1.Images.SetKeyName(43, "icons8-unavailable-50.png");
            this.imageList1.Images.SetKeyName(44, "icons8-undelete-50.png");
            this.imageList1.Images.SetKeyName(45, "icons8-upload-to-the-cloud-50.png");
            this.imageList1.Images.SetKeyName(46, "machine learning.ico");
            this.imageList1.Images.SetKeyName(47, "image_50px.png");
            this.imageList1.Images.SetKeyName(48, "save_48px.png");
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(535, 503);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // recognizeTextLabel
            // 
            this.recognizeTextLabel.AutoSize = true;
            this.recognizeTextLabel.BackColor = System.Drawing.Color.White;
            this.recognizeTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recognizeTextLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recognizeTextLabel.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recognizeTextLabel.Location = new System.Drawing.Point(902, 585);
            this.recognizeTextLabel.Name = "recognizeTextLabel";
            this.recognizeTextLabel.Size = new System.Drawing.Size(165, 28);
            this.recognizeTextLabel.TabIndex = 9;
            this.recognizeTextLabel.Text = "Recognized Text";
            // 
            // resultTextBox
            // 
            this.resultTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.resultTextBox.Font = new System.Drawing.Font("UTM Avo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultTextBox.Location = new System.Drawing.Point(553, 118);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultTextBox.Size = new System.Drawing.Size(540, 503);
            this.resultTextBox.TabIndex = 10;
            // 
            // imageLabel
            // 
            this.imageLabel.AutoSize = true;
            this.imageLabel.BackColor = System.Drawing.Color.White;
            this.imageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageLabel.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageLabel.Location = new System.Drawing.Point(463, 585);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(72, 28);
            this.imageLabel.TabIndex = 9;
            this.imageLabel.Text = "Image";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Add";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 28);
            this.label2.TabIndex = 9;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // imageGroupBox
            // 
            this.imageGroupBox.Controls.Add(this.loadImageButton);
            this.imageGroupBox.Controls.Add(this.label1);
            this.imageGroupBox.Location = new System.Drawing.Point(12, 627);
            this.imageGroupBox.Name = "imageGroupBox";
            this.imageGroupBox.Size = new System.Drawing.Size(535, 89);
            this.imageGroupBox.TabIndex = 12;
            this.imageGroupBox.TabStop = false;
            this.imageGroupBox.Text = "Image ToolBox";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.copyTextButton);
            this.groupBox1.Controls.Add(this.copyLabel);
            this.groupBox1.Location = new System.Drawing.Point(553, 628);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 89);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text ToolBox";
            // 
            // copyLabel
            // 
            this.copyLabel.AutoSize = true;
            this.copyLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyLabel.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyLabel.Location = new System.Drawing.Point(20, 64);
            this.copyLabel.Name = "copyLabel";
            this.copyLabel.Size = new System.Drawing.Size(42, 19);
            this.copyLabel.TabIndex = 9;
            this.copyLabel.Text = "Copy";
            // 
            // copyTextButton
            // 
            this.copyTextButton.BackColor = System.Drawing.Color.SlateGray;
            this.copyTextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.copyTextButton.ImageKey = "icons8-inspection-50.png";
            this.copyTextButton.ImageList = this.imageList1;
            this.copyTextButton.Location = new System.Drawing.Point(19, 16);
            this.copyTextButton.Name = "copyTextButton";
            this.copyTextButton.Size = new System.Drawing.Size(46, 48);
            this.copyTextButton.TabIndex = 2;
            this.copyTextButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.copyTextButton, "Copy recognized text to Clipboard");
            this.copyTextButton.UseVisualStyleBackColor = false;
            this.copyTextButton.Click += new System.EventHandler(this.copyButton_click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Save as";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.SlateGray;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.saveButton.ImageKey = "save_48px.png";
            this.saveButton.ImageList = this.imageList1;
            this.saveButton.Location = new System.Drawing.Point(89, 16);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(46, 48);
            this.saveButton.TabIndex = 2;
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.saveButton, "Save recognized text as document");
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1105, 728);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageGroupBox);
            this.Controls.Add(this.recognizeTextLabel);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imageLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Handwriting Recognizer   ( Beta Version 0.9.1 )";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.imageGroupBox.ResumeLayout(false);
            this.imageGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label recognizeTextLabel;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox imageGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button copyTextButton;
        private System.Windows.Forms.Label copyLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}


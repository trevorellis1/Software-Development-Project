namespace Digital_Safety_Deposit_Box
{
    partial class MainMenuForm
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
            this.uploadBTN = new System.Windows.Forms.Button();
            this.searchBTN = new System.Windows.Forms.Button();
            this.deleteBTN = new System.Windows.Forms.Button();
            this.renameBTN = new System.Windows.Forms.Button();
            this.newBTN = new System.Windows.Forms.Button();
            this.updateBTN = new System.Windows.Forms.Button();
            this.exportBTN = new System.Windows.Forms.Button();
            this.profileBTN = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.backButton = new System.Windows.Forms.Button();
            this.logoutBTN = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uploadBTN
            // 
            this.uploadBTN.Location = new System.Drawing.Point(3, 32);
            this.uploadBTN.Name = "uploadBTN";
            this.uploadBTN.Size = new System.Drawing.Size(109, 24);
            this.uploadBTN.TabIndex = 0;
            this.uploadBTN.Text = "Upload";
            this.uploadBTN.UseVisualStyleBackColor = true;
            this.uploadBTN.Click += new System.EventHandler(this.uploadBTN_Click);
            // 
            // searchBTN
            // 
            this.searchBTN.Location = new System.Drawing.Point(3, 62);
            this.searchBTN.Name = "searchBTN";
            this.searchBTN.Size = new System.Drawing.Size(109, 23);
            this.searchBTN.TabIndex = 1;
            this.searchBTN.Text = "Search";
            this.searchBTN.UseVisualStyleBackColor = true;
            this.searchBTN.Click += new System.EventHandler(this.searchBTN_Click);
            // 
            // deleteBTN
            // 
            this.deleteBTN.Location = new System.Drawing.Point(3, 91);
            this.deleteBTN.Name = "deleteBTN";
            this.deleteBTN.Size = new System.Drawing.Size(109, 23);
            this.deleteBTN.TabIndex = 2;
            this.deleteBTN.Text = "Delete";
            this.deleteBTN.UseVisualStyleBackColor = true;
            this.deleteBTN.Click += new System.EventHandler(this.deleteBTN_Click);
            // 
            // renameBTN
            // 
            this.renameBTN.Location = new System.Drawing.Point(3, 120);
            this.renameBTN.Name = "renameBTN";
            this.renameBTN.Size = new System.Drawing.Size(109, 23);
            this.renameBTN.TabIndex = 3;
            this.renameBTN.Text = "Rename";
            this.renameBTN.UseVisualStyleBackColor = true;
            this.renameBTN.Click += new System.EventHandler(this.renameBTN_Click);
            // 
            // newBTN
            // 
            this.newBTN.Location = new System.Drawing.Point(3, 149);
            this.newBTN.Name = "newBTN";
            this.newBTN.Size = new System.Drawing.Size(109, 23);
            this.newBTN.TabIndex = 4;
            this.newBTN.Text = "New";
            this.newBTN.UseVisualStyleBackColor = true;
            this.newBTN.Click += new System.EventHandler(this.newBTN_Click);
            // 
            // updateBTN
            // 
            this.updateBTN.Location = new System.Drawing.Point(3, 178);
            this.updateBTN.Name = "updateBTN";
            this.updateBTN.Size = new System.Drawing.Size(109, 23);
            this.updateBTN.TabIndex = 5;
            this.updateBTN.Text = "Update";
            this.updateBTN.UseVisualStyleBackColor = true;
            // 
            // exportBTN
            // 
            this.exportBTN.Location = new System.Drawing.Point(3, 207);
            this.exportBTN.Name = "exportBTN";
            this.exportBTN.Size = new System.Drawing.Size(109, 23);
            this.exportBTN.TabIndex = 6;
            this.exportBTN.Text = "Export";
            this.exportBTN.UseVisualStyleBackColor = true;
            // 
            // profileBTN
            // 
            this.profileBTN.Location = new System.Drawing.Point(3, 236);
            this.profileBTN.Name = "profileBTN";
            this.profileBTN.Size = new System.Drawing.Size(109, 23);
            this.profileBTN.TabIndex = 7;
            this.profileBTN.Text = "Profile";
            this.profileBTN.UseVisualStyleBackColor = true;
            this.profileBTN.Click += new System.EventHandler(this.profileBTN_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.backButton);
            this.flowLayoutPanel1.Controls.Add(this.uploadBTN);
            this.flowLayoutPanel1.Controls.Add(this.searchBTN);
            this.flowLayoutPanel1.Controls.Add(this.deleteBTN);
            this.flowLayoutPanel1.Controls.Add(this.renameBTN);
            this.flowLayoutPanel1.Controls.Add(this.newBTN);
            this.flowLayoutPanel1.Controls.Add(this.updateBTN);
            this.flowLayoutPanel1.Controls.Add(this.exportBTN);
            this.flowLayoutPanel1.Controls.Add(this.profileBTN);
            this.flowLayoutPanel1.Controls.Add(this.logoutBTN);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(118, 432);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // backButton
            // 
            this.backButton.Enabled = false;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(109, 23);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // logoutBTN
            // 
            this.logoutBTN.Location = new System.Drawing.Point(3, 265);
            this.logoutBTN.Name = "logoutBTN";
            this.logoutBTN.Size = new System.Drawing.Size(109, 23);
            this.logoutBTN.TabIndex = 8;
            this.logoutBTN.Text = "Logout";
            this.logoutBTN.UseVisualStyleBackColor = true;
            this.logoutBTN.Click += new System.EventHandler(this.logoutBTN_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(148, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(652, 450);
            this.flowLayoutPanel2.TabIndex = 10;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainMenuForm";
            this.Text = "Digital Safety Deposit Box - Main Menu";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uploadBTN;
        private System.Windows.Forms.Button searchBTN;
        private System.Windows.Forms.Button deleteBTN;
        private System.Windows.Forms.Button renameBTN;
        private System.Windows.Forms.Button newBTN;
        private System.Windows.Forms.Button updateBTN;
        private System.Windows.Forms.Button exportBTN;
        private System.Windows.Forms.Button profileBTN;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button logoutBTN;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button backButton;
    }
}

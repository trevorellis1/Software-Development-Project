namespace Digital_Safety_Deposit_Box
{
    partial class ForgotForm2
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
            this.questionLabel = new System.Windows.Forms.Label();
            this.confirmPassBox = new System.Windows.Forms.TextBox();
            this.questionBox = new System.Windows.Forms.TextBox();
            this.newPassBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.okBTN = new System.Windows.Forms.Button();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Location = new System.Drawing.Point(38, 47);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(96, 13);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "(Security Question)";
            // 
            // confirmPassBox
            // 
            this.confirmPassBox.Location = new System.Drawing.Point(138, 142);
            this.confirmPassBox.Name = "confirmPassBox";
            this.confirmPassBox.PasswordChar = '*';
            this.confirmPassBox.Size = new System.Drawing.Size(199, 20);
            this.confirmPassBox.TabIndex = 1;
            // 
            // questionBox
            // 
            this.questionBox.Location = new System.Drawing.Point(41, 63);
            this.questionBox.Name = "questionBox";
            this.questionBox.Size = new System.Drawing.Size(296, 20);
            this.questionBox.TabIndex = 2;
            // 
            // newPassBox
            // 
            this.newPassBox.Location = new System.Drawing.Point(138, 101);
            this.newPassBox.Name = "newPassBox";
            this.newPassBox.PasswordChar = '*';
            this.newPassBox.Size = new System.Drawing.Size(199, 20);
            this.newPassBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "New Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Confirm Password:";
            // 
            // okBTN
            // 
            this.okBTN.Location = new System.Drawing.Point(102, 207);
            this.okBTN.Name = "okBTN";
            this.okBTN.Size = new System.Drawing.Size(75, 23);
            this.okBTN.TabIndex = 6;
            this.okBTN.Text = "OK";
            this.okBTN.UseVisualStyleBackColor = true;
            this.okBTN.Click += new System.EventHandler(this.okBTN_Click);
            // 
            // cancelBTN
            // 
            this.cancelBTN.Location = new System.Drawing.Point(225, 207);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(75, 23);
            this.cancelBTN.TabIndex = 7;
            this.cancelBTN.Text = "Cancel";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // ForgotForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 307);
            this.Controls.Add(this.cancelBTN);
            this.Controls.Add(this.okBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newPassBox);
            this.Controls.Add(this.questionBox);
            this.Controls.Add(this.confirmPassBox);
            this.Controls.Add(this.questionLabel);
            this.Name = "ForgotForm2";
            this.Text = "Digital Safety Deposit Box - Forgot Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.TextBox confirmPassBox;
        private System.Windows.Forms.TextBox questionBox;
        private System.Windows.Forms.TextBox newPassBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okBTN;
        private System.Windows.Forms.Button cancelBTN;
    }
}
namespace Digital_Safety_Deposit_Box
{
    partial class RegisterForm
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
            this.regEmailLabel = new System.Windows.Forms.Label();
            this.regUsernameLabel = new System.Windows.Forms.Label();
            this.regPassLabel = new System.Windows.Forms.Label();
            this.regConfirmLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RegisterBTN = new System.Windows.Forms.Button();
            this.regEmailBox = new System.Windows.Forms.TextBox();
            this.regConfirmBox = new System.Windows.Forms.TextBox();
            this.regPassBox = new System.Windows.Forms.TextBox();
            this.regUsernameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioSuper = new System.Windows.Forms.RadioButton();
            this.radioGeneric = new System.Windows.Forms.RadioButton();
            this.radioAdmin = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // regEmailLabel
            // 
            this.regEmailLabel.AutoSize = true;
            this.regEmailLabel.Location = new System.Drawing.Point(146, 71);
            this.regEmailLabel.Name = "regEmailLabel";
            this.regEmailLabel.Size = new System.Drawing.Size(35, 13);
            this.regEmailLabel.TabIndex = 0;
            this.regEmailLabel.Text = "Email:";
            // 
            // regUsernameLabel
            // 
            this.regUsernameLabel.AutoSize = true;
            this.regUsernameLabel.Location = new System.Drawing.Point(123, 105);
            this.regUsernameLabel.Name = "regUsernameLabel";
            this.regUsernameLabel.Size = new System.Drawing.Size(58, 13);
            this.regUsernameLabel.TabIndex = 1;
            this.regUsernameLabel.Text = "Username:";
            // 
            // regPassLabel
            // 
            this.regPassLabel.AutoSize = true;
            this.regPassLabel.Location = new System.Drawing.Point(125, 137);
            this.regPassLabel.Name = "regPassLabel";
            this.regPassLabel.Size = new System.Drawing.Size(56, 13);
            this.regPassLabel.TabIndex = 2;
            this.regPassLabel.Text = "Password:";
            // 
            // regConfirmLabel
            // 
            this.regConfirmLabel.AutoSize = true;
            this.regConfirmLabel.Location = new System.Drawing.Point(87, 172);
            this.regConfirmLabel.Name = "regConfirmLabel";
            this.regConfirmLabel.Size = new System.Drawing.Size(94, 13);
            this.regConfirmLabel.TabIndex = 3;
            this.regConfirmLabel.Text = "Confirm Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "User Status:";
            // 
            // RegisterBTN
            // 
            this.RegisterBTN.Location = new System.Drawing.Point(258, 238);
            this.RegisterBTN.Name = "RegisterBTN";
            this.RegisterBTN.Size = new System.Drawing.Size(75, 23);
            this.RegisterBTN.TabIndex = 5;
            this.RegisterBTN.Text = "Register";
            this.RegisterBTN.UseVisualStyleBackColor = true;
            // 
            // regEmailBox
            // 
            this.regEmailBox.Location = new System.Drawing.Point(200, 71);
            this.regEmailBox.Name = "regEmailBox";
            this.regEmailBox.Size = new System.Drawing.Size(180, 20);
            this.regEmailBox.TabIndex = 6;
            // 
            // regConfirmBox
            // 
            this.regConfirmBox.Location = new System.Drawing.Point(200, 169);
            this.regConfirmBox.Name = "regConfirmBox";
            this.regConfirmBox.Size = new System.Drawing.Size(180, 20);
            this.regConfirmBox.TabIndex = 8;
            // 
            // regPassBox
            // 
            this.regPassBox.Location = new System.Drawing.Point(200, 137);
            this.regPassBox.Name = "regPassBox";
            this.regPassBox.Size = new System.Drawing.Size(180, 20);
            this.regPassBox.TabIndex = 9;
            // 
            // regUsernameBox
            // 
            this.regUsernameBox.Location = new System.Drawing.Point(200, 105);
            this.regUsernameBox.Name = "regUsernameBox";
            this.regUsernameBox.Size = new System.Drawing.Size(180, 20);
            this.regUsernameBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(400, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 12;
            // 
            // radioSuper
            // 
            this.radioSuper.AutoSize = true;
            this.radioSuper.Location = new System.Drawing.Point(200, 204);
            this.radioSuper.Name = "radioSuper";
            this.radioSuper.Size = new System.Drawing.Size(53, 17);
            this.radioSuper.TabIndex = 13;
            this.radioSuper.TabStop = true;
            this.radioSuper.Text = "Super";
            this.radioSuper.UseVisualStyleBackColor = true;
            // 
            // radioGeneric
            // 
            this.radioGeneric.AutoSize = true;
            this.radioGeneric.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioGeneric.Location = new System.Drawing.Point(318, 204);
            this.radioGeneric.Name = "radioGeneric";
            this.radioGeneric.Size = new System.Drawing.Size(62, 17);
            this.radioGeneric.TabIndex = 14;
            this.radioGeneric.TabStop = true;
            this.radioGeneric.Text = "Generic";
            this.radioGeneric.UseVisualStyleBackColor = true;
            // 
            // radioAdmin
            // 
            this.radioAdmin.AutoSize = true;
            this.radioAdmin.Location = new System.Drawing.Point(258, 204);
            this.radioAdmin.Name = "radioAdmin";
            this.radioAdmin.Size = new System.Drawing.Size(54, 17);
            this.radioAdmin.TabIndex = 15;
            this.radioAdmin.TabStop = true;
            this.radioAdmin.Text = "Admin";
            this.radioAdmin.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radioAdmin);
            this.Controls.Add(this.radioGeneric);
            this.Controls.Add(this.radioSuper);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.regUsernameBox);
            this.Controls.Add(this.regPassBox);
            this.Controls.Add(this.regConfirmBox);
            this.Controls.Add(this.regEmailBox);
            this.Controls.Add(this.RegisterBTN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.regConfirmLabel);
            this.Controls.Add(this.regPassLabel);
            this.Controls.Add(this.regUsernameLabel);
            this.Controls.Add(this.regEmailLabel);
            this.Name = "RegisterForm";
            this.Text = "Digital Safety Deposit Box - Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label regEmailLabel;
        private System.Windows.Forms.Label regUsernameLabel;
        private System.Windows.Forms.Label regPassLabel;
        private System.Windows.Forms.Label regConfirmLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button RegisterBTN;
        private System.Windows.Forms.TextBox regEmailBox;
        private System.Windows.Forms.TextBox regConfirmBox;
        private System.Windows.Forms.TextBox regPassBox;
        private System.Windows.Forms.TextBox regUsernameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioSuper;
        private System.Windows.Forms.RadioButton radioGeneric;
        private System.Windows.Forms.RadioButton radioAdmin;
    }
}
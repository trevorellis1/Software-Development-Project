using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Safety_Deposit_Box
{
    public partial class Profile : Form
    {
 
        String connectionString = "server=localhost;database=dsdb;uid=root;pwd=pass";
        MySqlConnection cnn;
        bool mainPage = true;
        String email;
        String userName;


        public Profile(String email, String username)
        {
            this.email = email;
            this.userName = username; 
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Image Icon = Digital_Safety_Deposit_Box.Properties.Resources.UserIcon;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = Icon; 

            nameBox.Text = userName;
            emailBox.Text = email;

            nameBox.ReadOnly = true;
            emailBox.ReadOnly = true;

            submitButton.Visible = false; 

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Edit Info Button
        private void button1_Click_1(object sender, EventArgs e)
        {
            mainPage = false;
            nameBox.Text = userName; 
            List<Button> buttons = new List<Button> { Backup, back, submitButton };
            enableButtons(buttons);
            editInfo.Enabled = false;

            List<Label> labels = new List<Label> { nameLabel, emailLabel, passwordLabel1 };
            enableLabels(labels);
            List<String> labelsText = new List<String> { "UserName", "Email", "Password" };
            changeLabelText(labels, labelsText);
            passwordLabel2.Visible = false;

            List<TextBox> boxes = new List<TextBox> { nameBox, emailBox, passwordBox1 };
            showTextBoxes(boxes, true);
            changeReadOnly(boxes, false);
            passwordBox2.Visible = false;
        }

        private void Backup_Click(object sender, EventArgs e)
        {
            mainPage = false; 
            List<Button> buttons = new List<Button> { editInfo, back, submitButton };
            enableButtons(buttons);
            Backup.Enabled = false;

            List<Label> labels = new List<Label> { emailLabel, passwordLabel1, passwordLabel2 };
            disableLabels(labels);
            nameLabel.Enabled = true;
            nameLabel.Text = "File Path to Backup";

            List<TextBox> boxes = new List<TextBox> { emailBox, passwordBox1, passwordBox2 };
            showTextBoxes(boxes, false);
            changeReadOnly(boxes, true);
            nameBox.Visible = true;
            nameBox.ReadOnly = false;
            nameBox.Text = "File Path";
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (mainPage)
            {
                MainMenuForm m = new MainMenuForm();
                m.Show();
                this.Close(); 
            }
            else
            {
                nameBox.Text = userName; 
                submitButton.Enabled = false;
                submitButton.Visible = false;
                List<Button> buttons = new List<Button> { editInfo, Backup, back };
                enableButtons(buttons);

                List<Label> labels = new List<Label> { nameLabel, emailLabel, passwordLabel1, passwordLabel2 };
                List<String> labelText = new List<String> { "Username", "Email", "No. of Drawers", "No. of Files" };
                enableLabels(labels);
                changeLabelText(labels, labelText);

                List<TextBox> boxes = new List<TextBox> { nameBox, emailBox, passwordBox1, passwordBox2 };
                showTextBoxes(boxes, true);
                changeReadOnly(boxes, true);
            }
            mainPage = true; 
        }


        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }

        void showTextBoxes(List<TextBox> l, bool b)
        {
            foreach (var item in l)
            {
                item.Visible = b;
            }
        }

        void changeReadOnly(List<TextBox> l, Boolean b)
        {
            foreach (var item in l)
            {
                item.ReadOnly = b;
            }
        }

        void enableLabels(List<Label> l)
        {
            foreach (var item in l)
            {
                item.Visible = true;
            }
        }

        void disableLabels(List<Label> l)
        {
            foreach (var item in l)
            {
                item.Visible = false;
            }
        }

        void changeLabelText(List<Label> l, List<String> text)
        {
            for (int i = 0; i < l.Count; i++)
            {
                l[i].Text = text[i];
            }
        }

        void enableButtons(List<Button> l)
        {
            foreach (var item in l)
            {
                item.Visible = true;
                item.Enabled = true;
            }
        }

        void disableButtons(List<Button> l)
        {
            foreach (var item in l)
            {
                item.Visible = false;
                item.Enabled = false;
            }
        }

        /* Event when someone edits their password. Brings up a second box
        * to confirm new password */
        private void passwordBox1_TextChanged_1(object sender, EventArgs e)
        {
            passwordLabel2.Text = "Confirm Password";
            passwordLabel2.Visible = true;
            passwordBox2.ReadOnly = false;
            passwordBox2.Text = "";
            passwordBox2.Visible = true;
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Register
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load (object sender, EventArgs e)
        {
            Label questions = new Label();
            questions.Location = new Point(200, 100);
            questions.Size = new Size(200, 200);
            questions.Text = "Select Your Question";

            this.Controls.Add(questions);

            ComboBox mybox = new ComboBox();
            mybox.Location = new Point(300, 100);
            mybox.Size = new Size(216, 26);
            mybox.Name = "comboBox";
            mybox.Visible = true;
            mybox.Items.Add("Moms name");
            mybox.Items.Add("Middle school");
            mybox.Items.Add("Pets name");

            this.Controls.Add(mybox);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load_1(object sender, EventArgs e)
        {
            Label questions = new Label();
            questions.Location = new Point(200, 100);
            questions.Size = new Size(200, 200);
            questions.Text = "Select Your Question";

            this.Controls.Add(questions);

            ComboBox mybox = new ComboBox();
            mybox.Location = new Point(300, 100);
            mybox.Size = new Size(216, 26);
            mybox.Name = "comboBox";
            mybox.Visible = true;
            mybox.Items.Add("Moms name");
            mybox.Items.Add("Middle school");
            mybox.Items.Add("Pets name");

            this.Controls.Add(mybox);
        }
    }
}

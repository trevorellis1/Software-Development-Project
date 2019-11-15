using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Digital_Safety_Deposit_Box
{
    public partial class ForgotForm1 : Form
    {
        LogIn l = new LogIn();
        MySqlConnection conDataBase = new MySqlConnection("SERVER=localhost;DATABASE=cs305;UID=root;PASSWORD=pass;");

        public ForgotForm1()
        {
            InitializeComponent();
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            emailBox.Text = "";
            this.Close();
            l.makeVisible();
        }

        private void submitBTN_Click(object sender, EventArgs e)
        {
            int count = 0;
            string email = "";

            if (emailBox.Text != "")
            {
                string queryEmail = "select userEmail from cs305.login where userEmail like '" + emailBox.Text + "';";

                MySqlDataAdapter searchEmail = new MySqlDataAdapter(queryEmail, conDataBase);
                DataTable dt = new DataTable();
                searchEmail.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    ForgotForm2 f2 = new ForgotForm2();

                    foreach (DataRow dataRow in dt.Rows)
                    {
                        foreach (var item in dataRow.ItemArray)
                        {
                            if (count == 0)
                            {
                                email = item.ToString();
                                //Console.WriteLine(email);
                            }
                            count++;
                        }
                    }
                    f2.setEmail(email);
                    this.Visible = false;
                    emailBox.Text = "";
                    f2.displayQuestion();
                    f2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid email address.");
                    emailBox.Text = "";
                }
            }
        }
    }
}

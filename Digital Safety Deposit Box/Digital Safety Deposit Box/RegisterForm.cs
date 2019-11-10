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
    public partial class RegisterForm : Form
    {
        string proStatus = "";
        Boolean emailCorrect = false;
        Boolean usernameCorrect = false;
        Boolean passwordCorrect = false;
        Boolean statusCorrect = false;
        LogIn l = new LogIn();

        MySqlConnection conDataBase = new MySqlConnection("SERVER=localhost;DATABASE=cs305;UID=root;PASSWORD=pass;");

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterBTN_Click(object sender, EventArgs e)
        {
            Boolean isInt = false;
            Boolean isChar = false;
            Boolean isSpecial = false;

            if (regEmailBox.Text != "" || regUsernameBox.Text != "" || regPassBox.Text != "" || regConfirmBox.Text != "" || proStatus != "")
            {
                //query inserting credentials into data table
                string queryInsert = "insert into cs305.login(userEmail, userName, password, status) values('" +
                    regEmailBox.Text + "', '" + regUsernameBox.Text + "', '" + regPassBox.Text + "', '" + proStatus + "');";
                //query scanning email address
                string queryEmail = "select * from cs305.login where userEmail like '" + regEmailBox.Text + "';";
                //query scanning username
                string queryUsername = "select * from cs305.login where userName like '" + regUsernameBox.Text + "';";
                //query scanning password
                string queryPassword = "select * from cs305.login where password like '" + regPassBox.Text + "';";
                //query scanning status
                string queryStatus = "select * from cs305.login where status like 'Super';";

                MySqlDataAdapter searchEmail = new MySqlDataAdapter(queryEmail, conDataBase);
                DataTable dt = new DataTable();
                searchEmail.Fill(dt);
                if (regEmailBox.Text.IndexOf("@yahoo.com") == -1 || regEmailBox.Text.IndexOf("@outlook.com") == -1 || regEmailBox.Text.IndexOf("@hotmail.com") == -1 ||
                    regEmailBox.Text.IndexOf("@gmail.com") == -1 || regEmailBox.Text.IndexOf("@aol.com") == -1)
                {
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("The email address you entered is already being used.");
                        resetBoxes();
                    }
                    else
                    {
                        emailCorrect = true;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid email address.");
                    resetBoxes();
                }

                MySqlDataAdapter searchUsername = new MySqlDataAdapter(queryUsername, conDataBase);
                dt = new DataTable();
                searchUsername.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("The username you entered is already being used.");
                    resetBoxes();
                }
                else
                {
                    usernameCorrect = true;
                }

                MySqlDataAdapter searchPassword = new MySqlDataAdapter(queryPassword, conDataBase);
                dt = new DataTable();
                searchPassword.Fill(dt);
                if ((regPassBox.Text.Length >= 14 && regPassBox.Text.Length <= 20))
                {
                    for (int i = 0; i < regPassBox.Text.Length; i++)
                    {
                        if (char.IsDigit(regPassBox.Text[i]) == true)
                        {
                            isInt = true;
                        }
                        else if (char.IsLetter(regPassBox.Text[i]) == true)
                        {
                            isChar = true;
                        }
                        else
                        {
                            isSpecial = true;
                        }
                    }

                    if (isInt == true && isChar == true && isSpecial == true)
                    {
                        if (dt.Rows.Count >= 1)
                        {
                            MessageBox.Show("The password you entered is already being used.");
                            resetBoxes();
                        }
                        else
                        {
                            if (regPassBox.Text != regConfirmBox.Text && regConfirmBox.Text != regPassBox.Text)
                            {
                                MessageBox.Show("Password confirmation is invalid.");
                                resetBoxes();
                            }
                            else
                            {
                                passwordCorrect = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password must contain letters, numbers, and special characters.");
                        resetBoxes();
                    }
                }
                else
                {
                    MessageBox.Show("Password must be from 14 to 20 characters long.");
                    resetBoxes();
                }

                MySqlDataAdapter searchStatus = new MySqlDataAdapter(queryStatus, conDataBase);
                dt = new DataTable();
                searchStatus.Fill(dt);
                if (proStatus == "Super")
                {
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("There is already a super admin, and there can only be one.");
                        resetBoxes();
                    }
                    else
                    {
                        statusCorrect = true;
                    }
                }
                else
                {
                    statusCorrect = true;
                }

                if (emailCorrect == true && usernameCorrect == true && passwordCorrect == true && statusCorrect == true)
                {
                    conDataBase.Open();
                    MySqlCommand cmd = new MySqlCommand(queryInsert, conDataBase);
                    cmd.ExecuteNonQuery();
                    conDataBase.Close();
                    resetBoxes();
                    MessageBox.Show("Login created.");
                    resetBoxes();
                    this.Close();
                    l.makeVisible();
                }
            }   
        }

        private void radioSuper_CheckedChanged(object sender, EventArgs e)
        {
            proStatus = "Super";
            //Console.WriteLine(proStatus);
        }

        private void radioAdmin_CheckedChanged(object sender, EventArgs e)
        {
            proStatus = "Admin";
            //Console.WriteLine(proStatus);
        }

        private void radioGeneric_CheckedChanged(object sender, EventArgs e)
        {
            proStatus = "Generic";
            //Console.WriteLine(proStatus);
        }

        public void resetBoxes()
        {
            regEmailBox.Text = "";
            regUsernameBox.Text = "";
            regPassBox.Text = "";
            regConfirmBox.Text = "";
            radioSuper.Checked = false;
            radioAdmin.Checked = false;
            radioGeneric.Checked = false;
            proStatus = "";
            emailCorrect = false;
            usernameCorrect = false;
            passwordCorrect = false;
            statusCorrect = false;
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            resetBoxes();
            this.Close();
            l.makeVisible();
        }
    }
}

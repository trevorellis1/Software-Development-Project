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
    public partial class ForgotForm2 : Form
    {
        string email = "";
        LogIn l = new LogIn();
        MySqlConnection conDataBase = new MySqlConnection("SERVER=localhost;DATABASE=cs305;UID=root;PASSWORD=pass;");

        public ForgotForm2()
        {
            InitializeComponent();
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public string getEmail()
        {
            return email;
        }

        public void displayQuestion()
        {
            int count = 0;

            string queryQuestion = "select secQuestion from cs305.login where userEmail like '" + getEmail() + "';";

            MySqlDataAdapter searchQuestion = new MySqlDataAdapter(queryQuestion, conDataBase);
            DataTable dt = new DataTable();
            searchQuestion.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        if (count == 0)
                        {
                            questionLabel.Text = item.ToString();
                        }
                        count++;
                    }
                }
            }
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            questionBox.Text = "";
            newPassBox.Text = "";
            confirmPassBox.Text = "";
            this.Close();
            setEmail("");
            l.makeVisible();
        }

        private void okBTN_Click(object sender, EventArgs e)
        {
            Boolean isInt = false;
            Boolean isChar = false;
            Boolean isSpecial = false;
            Boolean passwordCorrect = false;
            Boolean answerCorrect = false;

            string queryAnswer = "select * from cs305.login where secAnswer like '" + questionBox.Text + "';";

            string queryPassword = "select * from cs305.login where password like '" + newPassBox.Text + "';";

            string queryChange = "update cs305.login set password = '" + newPassBox.Text + "' where userEmail like '" + getEmail() + "';";

            MySqlDataAdapter searchAnswer = new MySqlDataAdapter(queryAnswer, conDataBase);
            DataTable dt = new DataTable();
            searchAnswer.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                answerCorrect = true;
            }
            else
            {
                MessageBox.Show("Answer to your security question is incorrect.");
                questionBox.Text = "";
                newPassBox.Text = "";
                confirmPassBox.Text = "";
            }

            MySqlDataAdapter searchPassword = new MySqlDataAdapter(queryPassword, conDataBase);
            dt = new DataTable();
            searchPassword.Fill(dt);

            if ((newPassBox.Text.Length >= 14 && newPassBox.Text.Length <= 20))
            {
                for (int i = 0; i < newPassBox.Text.Length; i++)
                {
                    if (char.IsDigit(newPassBox.Text[i]) == true)
                    {
                        isInt = true;
                    }
                    else if (char.IsLetter(newPassBox.Text[i]) == true)
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
                        questionBox.Text = "";
                        newPassBox.Text = "";
                        confirmPassBox.Text = "";
                    }
                    else
                    {
                        if (newPassBox.Text != confirmPassBox.Text && confirmPassBox.Text != newPassBox.Text)
                        {
                            MessageBox.Show("Password confirmation is invalid.");
                            questionBox.Text = "";
                            newPassBox.Text = "";
                            confirmPassBox.Text = "";
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
                    questionBox.Text = "";
                    newPassBox.Text = "";
                    confirmPassBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Password must be from 14 to 20 characters long.");
                questionBox.Text = "";
                newPassBox.Text = "";
                confirmPassBox.Text = "";
            }

            if (answerCorrect == true && passwordCorrect == true)
            {
                conDataBase.Open();
                MySqlCommand cmd = new MySqlCommand(queryChange, conDataBase);
                cmd.ExecuteNonQuery();
                conDataBase.Close();
                MessageBox.Show("Your password has been changed.");
                questionBox.Text = "";
                newPassBox.Text = "";
                confirmPassBox.Text = "";
                this.Close();
                setEmail("");
                l.makeVisible();
            }
            else
            {
                MessageBox.Show("Please, try again.");
                questionBox.Text = "";
                newPassBox.Text = "";
                confirmPassBox.Text = "";
            }
        }
    }
}

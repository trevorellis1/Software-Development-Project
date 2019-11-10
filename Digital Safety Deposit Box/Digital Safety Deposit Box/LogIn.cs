﻿using System;
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
    public partial class LogIn : Form
    {
        Boolean rememberMe = false;
        MySqlConnection conDataBase = new MySqlConnection("SERVER=localhost;DATABASE=cs305;UID=root;PASSWORD=pass;");

        public LogIn()
        {
            InitializeComponent();
            credRemembered();
        }

        //if you click on the "Register" button
        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm rf = new RegisterForm();
            this.Visible = false;
            rf.ShowDialog();
        }

        //if you exit application
        private void exitBTN_Click(object sender, EventArgs e)
        {
            if (rememberMe == false)
            {
                string queryForget = "delete from cs305.savedcredentials;";
                conDataBase.Open();
                MySqlCommand cmd = new MySqlCommand(queryForget, conDataBase);
                cmd.ExecuteNonQuery();
                conDataBase.Close();
            }
            System.Windows.Forms.Application.Exit();
        }

        //after you log out
        public void makeVisible()
        {
            this.Visible = true;
        }

        public void credRemembered()
        {
            int count = 0;
            string queryCredentials = "select * from cs305.savedcredentials";

            MySqlDataAdapter searchCredentials = new MySqlDataAdapter(queryCredentials, conDataBase);
            DataTable dt = new DataTable();
            searchCredentials.Fill(dt);

            if (dt.Rows.Count == 2)
            {
                rememberMe = true;
                checkBox1.Checked = true;

                if (rememberMe == true)
                {
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        foreach (var item in dataRow.ItemArray)
                        {
                            if (count == 0)
                            {
                                textBox2.Text = item.ToString();
                                //Console.WriteLine(item);
                            }
                            if (count == 1)
                            {
                                textBox1.Text = item.ToString();
                                //Console.WriteLine(item);
                            }
                            count++;
                        }
                    }
                }
            }
        }

        //if you log in
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int count = 0;
                string email = "";
                string username = "";
                string status = "";

                string queryLogin = "select * from cs305.login where userEmail like '" + textBox1.Text + "' and password like'" + textBox2.Text + "';";

                MySqlDataAdapter searchLogin = new MySqlDataAdapter(queryLogin, conDataBase);
                DataTable dt = new DataTable();
                searchLogin.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    MainMenuForm mmf = new MainMenuForm();

                    foreach (DataRow dataRow in dt.Rows)
                    {
                        foreach (var item in dataRow.ItemArray)
                        {
                            if (count == 0)
                            {
                                email = item.ToString();
                                //Console.WriteLine(email);
                            }

                            if (count == 1)
                            {
                                username = item.ToString();
                                //Console.WriteLine(username);
                            }

                            if (count == 3)
                            {
                                status = item.ToString();
                                //Console.WriteLine(status);
                            }
                            count++;
                        }
                    }
                    
                    mmf.setCredentials(email, username, status);
                    this.Visible = false;

                    string queryForget = "delete from cs305.savedcredentials where credValue like '" + textBox1.Text + "';";
                    conDataBase.Open();
                    MySqlCommand cmd = new MySqlCommand(queryForget, conDataBase);
                    cmd.ExecuteNonQuery();
                    conDataBase.Close();

                    queryForget = "delete from cs305.savedcredentials where credValue like '" + textBox2.Text + "';";
                    conDataBase.Open();
                    cmd = new MySqlCommand(queryForget, conDataBase);
                    cmd.ExecuteNonQuery();
                    conDataBase.Close();

                    if (rememberMe != true)
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    else
                    {
                        string queryInsert = "insert into cs305.savedcredentials(credValue) values('" + textBox1.Text + "');";

                        conDataBase.Open();
                        cmd = new MySqlCommand(queryInsert, conDataBase);
                        cmd.ExecuteNonQuery();
                        conDataBase.Close();

                        queryInsert = "insert into cs305.savedcredentials(credValue) values('" + textBox2.Text + "');";

                        conDataBase.Open();
                        cmd = new MySqlCommand(queryInsert, conDataBase);
                        cmd.ExecuteNonQuery();
                        conDataBase.Close();
                    }
                    mmf.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                    textBox2.Text = "";
                }
            }
            else if (textBox1.Text != "" && textBox2.Text == "")
            {
                MessageBox.Show("You must enter your password.");
                textBox2.Text = "";
            }
            else if (textBox1.Text == "" && textBox2.Text != "")
            {
                MessageBox.Show("You must enter your username.");
                textBox2.Text = "";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                rememberMe = true;
                //Console.WriteLine(rememberMe);
            }
            else if (checkBox1.Checked == false)
            {
                rememberMe = false;
                //Console.WriteLine(rememberMe);
            }
        }
    }
}

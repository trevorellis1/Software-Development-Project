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
    public partial class MainMenuForm : Form
    {
        string email;
        string username;
        string status;

        public void setCredentials(string email, string username, string status)
        {
            this.email = email;
            this.username = username;
            this.status = status;
        }

        public string getEmail()
        {
            return email;
        }

        public string getUsername()
        {
            return username;
        }

        public string getStatus()
        {
            return status;
        }

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void logoutBTN_Click(object sender, EventArgs e)
        {
            LogIn l = new LogIn();
            this.Close();
            l.makeVisible();
        }
    }
}

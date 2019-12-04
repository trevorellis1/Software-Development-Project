using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Digital_Safety_Deposit_Box
{
    public partial class MainMenuForm : Form
    {
        string email;
        string username;
        string status;
        readonly StorageRecord sr = new StorageRecord();
         

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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            flowLayoutPanel2.AutoScroll = true;
            // Creates the initial pictureBoxes and adds their events
            sr.getListOfItems().ForEach(item => sr.drawImage(item, flowLayoutPanel2, backButton, Font));
            // Adds the pictureBoxes onto the panel. 
            sr.AddFolderToPanel(sr.getTopDrawer(), flowLayoutPanel2);

        }

        private void logoutBTN_Click(object sender, EventArgs e)
        {
            LogIn l = new LogIn();
            this.Close();
            l.makeVisible();
        }

        private void uploadBTN_Click(object sender, EventArgs e)
        {
            DragAndDrop upload = new DragAndDrop(flowLayoutPanel2, backButton);
            upload.Show(); 
        }

        // Gets file/Drawer name through user input and searches for it. 
        private void searchBTN_Click(object sender, EventArgs e)
        {
            
            String search = Interaction.InputBox("Enter the file name you would like to search for.", "Search", "Query");
            if (search == "")
            {
                return;
            }
            PictureBox p = sr.findEntryImage(search);
            if (p == null)
            {
                MessageBox.Show("Looks like there weren't any matches.");
                return;
            }
            displayResult(p);  
            flowLayoutPanel2.ResumeLayout();
            
        }

        /* Clears the screen and adds the searched for pictureBox as the only icon. 
         * Used in the search and delete button events.  
         * Does not resume the flowLayoutPanel layout, which must be called after this function
         * flowLayoutPanel2.ResumeLayout();
         */
        private void displayResult(PictureBox p)
        {
            flowLayoutPanel2.SuspendLayout();
            Item item = (Item)p.Tag;

            sr.setCurrentDrawer(item.getParent());
            backButton.Enabled = true;
            flowLayoutPanel2.Controls.Clear();

            sr.addImageToPanel(item.getPictureBox(), flowLayoutPanel2);
            sr.setCurrentDrawer(item.getParent());
            
        }


        private void backButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.SuspendLayout();
            // For special search and delete cases. 
            if (sr.getCurrentDrawer().getName().Equals(sr.getTopDrawer().getName()))
            {
                backButton.Enabled = false;
                sr.AddFolderToPanel(sr.getCurrentDrawer(), flowLayoutPanel2);
                flowLayoutPanel2.ResumeLayout();
                return;
            }
           
            flowLayoutPanel2.Controls.Clear();
            sr.AddFolderToPanel(sr.getCurrentDrawer().getParent(), flowLayoutPanel2);
            sr.setCurrentDrawer(sr.getCurrentDrawer().getParent());

            flowLayoutPanel2.ResumeLayout();
        }

        // Creates a new drawer or file within the directory the user is in. 
        private void newBTN_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Would you like to create a drawer?", "Create New Item", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            { 
                String name = Interaction.InputBox("Enter a name for the drawer.", "Drawer Name", "Name");
                if (name == "")
                {
                    return;
                }
                String fullPath = sr.getCurrentDrawer().getFullPath() + "\\" + name;

                // If there isn't already existing item for the path, create a drawer there.
                if (!sr.iterateByFullPath(fullPath))
                {
                    Drawer newDrawer = new Drawer(sr.getCurrentDrawer(), name);
                    PictureBox p = sr.drawImage(newDrawer, flowLayoutPanel2, backButton, Font);
                    sr.addImageToPanel(p, flowLayoutPanel2); 

                }
                else
                {
                    MessageBox.Show("This name already exists in the Drawer."); 
                }
           }
            else if (dialogResult == DialogResult.No)
            {
                String name = Interaction.InputBox("Enter a name for the File.", "File Name", "Name");
                if(name == "")
                {
                    return;
                }

                String fullPath = sr.getCurrentDrawer().getFullPath() + "\\" + name;

                // If there isn't already existing item for the path, create a file there. 
                if (!sr.iterateByFullPath(fullPath))
                {
                    Files newFile = new Files(sr.getCurrentDrawer(), name);
                    sr.drawImage(newFile, flowLayoutPanel2, backButton, Font);
                    sr.addImageToPanel(newFile.getPictureBox(), flowLayoutPanel2);
                }
                else
                {
                    MessageBox.Show("This name already exists in the Drawer.");
                }
            }      
        }

        private void profileBTN_Click(object sender, EventArgs e)
        {
            Profile p = new Profile(email, username);
            p.Show();
            this.Close();  
        }


        private void deleteBTN_Click(object sender, EventArgs e)
        {

            // Should probably be changed to a form with a single radio button box or something similar. 
            String search = Interaction.InputBox("Enter the name of file/Drawer you would like to search for.", "Delete", "Query");
            if (search == "")
            {
                return;
            }
          //  String fullPath = sr.getCurrentDrawer() + "\\" + search;
            PictureBox p = sr.findEntryImage(search);
            if (p == null)
            {
                MessageBox.Show("Looks like there weren't any matches.");
                return;
            }
            Item currentItem = (Item)p.Tag;
            sr.setCurrentDrawer(currentItem.getParent());
            if (!sr.getCurrentDrawer().getName().Equals(sr.getTopDrawer().getName()))
            {
                backButton.Enabled = true;
            }
            displayResult(p);

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Item i = (Item)p.Tag; 
                sr.getListOfItems().Remove(i);
                if (currentItem is Files)
                {
                    Files f = (Files)currentItem;
                    f.delete();
                }
                else if (currentItem is Drawer)
                {
                    Drawer d = (Drawer)currentItem;
                    d.delete(true);
                }
                flowLayoutPanel2.Controls.Clear();
                sr.AddFolderToPanel(sr.getTopDrawer(), flowLayoutPanel2);
            }
            flowLayoutPanel2.ResumeLayout();
        }
        
            private void renameBTN_Click(object sender, EventArgs e)
        {
            
        }
    }
} 
 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Digital_Safety_Deposit_Box
{
    class StorageRecord
    {

        // Holds all the entries in the file/drawer system. 
        protected static List<Item> listOfItems = new List<Item>();
    
        // Top directory that holds everything else. 
        public static Drawer topDrawer;
        // The name of the top drawer 
        const String topDrawerName = "DrawerLib";

        // Keeps track of the current folder's parent. Used mainly for the back button. 
        static Drawer currentDrawer;

        Image drawerImg = Digital_Safety_Deposit_Box.Properties.Resources.drawerIcon;
        Image fileImg = Digital_Safety_Deposit_Box.Properties.Resources.fileIcon;

        public StorageRecord()
        {
            addTopDrawer(); 
        }

        // Blank constructor 
        public StorageRecord(bool b)
        {
        }

        // Adds the top level directory to the record. If it already exists, returns false . 
        protected bool addTopDrawer()
        {
            if (topDrawer == null)
            {
                topDrawer = new Drawer(System.IO.Directory.GetCurrentDirectory() + "\\" + topDrawerName);
                return true;
            }
            return false;
        }

        /* Goes through the initial directory and records already existing entries. 
           Should only be called once at start of program. */
        public void addExistingItems(Drawer drawer)
        { 
            if (drawer != null)
            {
                foreach (String file in Directory.GetFiles(drawer.getFullPath()))
                {
                    if (File.Exists(file))
                    {
                        Files temp = new Files(drawer, Path.GetFileName(file));
                        if (!listOfItems.Contains(temp))
                        {
                            listOfItems.Add(temp);
                        }
                    }
                }

                foreach (String item in Directory.GetDirectories(drawer.getFullPath()))
                {

                    if (Directory.Exists(item))
                    {
                        Drawer temp = new Drawer(drawer, Path.GetFileName(item));
                        if (!listOfItems.Contains(temp))
                        {
                            listOfItems.Add(temp);
                            addExistingItems(temp);
                        }
                    }
                }
            }
        }

        /* Searches the list of items for a specific file/folder path and 
         * returns true if it finds a match.
         */ 
        public bool iterateByFullPath(String path)
        {
            bool b = false; 
            listOfItems.ForEach(item => { if (item.getFullPath().Equals(path)) b = true; });
            return b; 
        }

        // Finds the corresponding pictureBox by its name. 
        public PictureBox findEntryImage(String query)
        {
            PictureBox image = null;
            listOfItems.ForEach(item => { if (item.getName().Equals(query))
                image = item.getPictureBox(); });
            
            return image; 
        }
       

        /* Used to add a single pictureBox to the panel. Meant mainly for the create 
        * and upload buttons */
        public void addImageToPanel(PictureBox b, FlowLayoutPanel flowLayoutPanel2)
        {
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.Controls.Add(b);
            flowLayoutPanel2.ResumeLayout();
        }

        // Adds the drawer's sub-content onto the panel as pictureBoxes. 
        public void AddFolderToPanel(Drawer parent, FlowLayoutPanel flowLayoutPanel2)
        {
            flowLayoutPanel2.SuspendLayout();

            listOfItems.ForEach(item => {if(item.getParent().getName().Equals(parent.getName())) 
                                            flowLayoutPanel2.Controls.Add(item.getPictureBox()); });
            flowLayoutPanel2.ResumeLayout();
            
        }

        /* Creates a list of pictureBoxes containing icons and click events.
         * Meant to be used before the main menu form is visible */
        public PictureBox drawImage(Item item, FlowLayoutPanel flowLayoutPanel2, Button backButton, Font font)
        {
            PictureBox p = new PictureBox();
            p.Margin = new Padding(10, 10, 10, 10);  
            p.SizeMode = PictureBoxSizeMode.StretchImage;

            DelegateEvent d = new DelegateEvent(item, flowLayoutPanel2, backButton);

            if (item is Drawer)
            {
                p.Image = drawerImg;
                p.DoubleClick += d.getDrawerDoubleClick();
                // p.Click += d.getDrawerSelect();
            }
            else if (item is Files)
            {
                p.Image = fileImg;
                p.DoubleClick += d.getFileDoubleClick();
            }
            
            item.setPictureBox(p);
            p.Tag = item;
            p.Paint += new PaintEventHandler((sender, e) =>
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                e.Graphics.DrawString(item.getName(), font, Brushes.Black, 0, 0);
            });
            
            return p; 
        }


    

        public Drawer getTopDrawer()
        {
            return topDrawer;
        }

        public String getTopDrawerName()
        {
            return topDrawerName;
        }

        public List<Item> getListOfItems()
        {
            return listOfItems;
        }

        public Drawer getCurrentDrawer()
        {
            if(currentDrawer == null)
            {
                currentDrawer = topDrawer; 
            }
            return currentDrawer;
        }

        public void setCurrentDrawer(Drawer d)
        {
            currentDrawer = d;
        }

        public Image getDrawerImg()
        {
            return drawerImg;
        }
        public Image getFileImg()
        {
            return fileImg;
        }

    }
}

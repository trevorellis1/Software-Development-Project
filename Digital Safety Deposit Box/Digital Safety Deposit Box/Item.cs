using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Digital_Safety_Deposit_Box
{
    class Item
    {

        // Parent directory. 
        protected Drawer parent;

        // The path to the current item. 
        protected String fullPath;

        // Name of the item 
        protected String name;

        protected PictureBox pictureBox;

        protected bool isDrawer;
       
        String connectionString = "server=localhost;database=dsdb;uid=root;pwd=pass";
        
        MySqlConnection cnn;


        
        public Item()
        {

        }

        public bool rename(String newName)
        {
            if (this is Drawer)
            {
                String temp = this.fullPath;
                String newPath = temp.Replace(this.name, newName);


                if (Directory.Exists(fullPath) && !Directory.Exists(newPath))
                {
                    Directory.Move(fullPath, newPath);
                    this.name = newName;
                    fullPath = newPath;

                    return true;
                }
            }
            else if (this is Files)
            {
                if (File.Exists(fullPath))
                {
                    File.Copy(fullPath, fullPath.Replace(name, newName), true);
                    File.Delete(fullPath);
                    this.fullPath = this.fullPath.Replace(this.name, newName);
                    this.name = newName;
                    return true;
                }
            }
            return false;
        }

        public void setName(String s)
        {
            this.name = s;
        }

        public String getName()
        {
            return this.name;
        }

        public void setFullPath(String s)
        {
            this.fullPath = s;
        }

        public String getFullPath()
        {
            return fullPath;
        }

        protected void setParent(String fullPath, String name)
        {
            StorageRecord sr = new StorageRecord(); 
            fullPath.Replace("\\" + name, "");
            parent = (Drawer) sr.getListOfItems().Find(item => fullPath.Equals(item.fullPath));
;       }

        public Drawer getParent()
        {
            return this.parent;
        }

        public PictureBox getPictureBox()
        {
            return pictureBox;
        }
        public void setPictureBox(PictureBox picture)
        {
            this.pictureBox = picture;
        }

        public void setIsDrawer(bool b)
        {
            this.isDrawer = b;
        }

        public bool getIsDrawer()
        {
            return this.isDrawer; 
        }
    }
}

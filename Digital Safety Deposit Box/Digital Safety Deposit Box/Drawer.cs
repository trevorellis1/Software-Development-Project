using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Safety_Deposit_Box
{
    class Drawer : Item 
    {

        public Drawer(String name, String fullPath)
        {
            StorageRecord sr = new StorageRecord();
            this.isDrawer = true;
            this.parent = sr.getTopDrawer(); 
            this.name = name;
            this.fullPath = fullPath;
            if (fullPath != null && !Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
                sr.getListOfItems().Add(this);
            }
        }

        // Used for creating the top drawer. 
        public Drawer(String fullPath)
        {
            StorageRecord sr = new StorageRecord(true);
            this.isDrawer = true;
            this.name = sr.getTopDrawerName();
            this.fullPath = fullPath;
            if (fullPath != null)
            {
                Directory.CreateDirectory(fullPath);
            }
        }

        public Drawer(Drawer parent, String name)
        {
            StorageRecord sr = new StorageRecord();
            this.isDrawer = true;
            this.name = name;
            this.parent = parent;  
            this.fullPath = parent.getFullPath() + "\\" + name;
            if (fullPath != null && !Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
                sr.getListOfItems().Add(this);
            }
        }

        public bool delete()
        {
            if(Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath, true);
                return true;
            }
            return false; 
        }

        public bool rename(String newName)
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
            return false;
        }
    }
}

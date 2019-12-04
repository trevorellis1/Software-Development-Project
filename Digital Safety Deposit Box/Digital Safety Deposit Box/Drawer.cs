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
        /* Constructor for when there is no clear parent. 
         * Makes the topDrawer the parent. 
         */
        public Drawer(String name, String fullPath)
        {
            StorageRecord sr = new StorageRecord();
            this.isDrawer = true;            
            this.name = name;
            this.fullPath = fullPath;
            setParent(fullPath, name);
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

        // Main constructor for when there is a clear parent and name. 
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

        public bool delete(bool b)
        {
            StorageRecord sr = new StorageRecord();

            if (this is Drawer && Directory.Exists(fullPath))
            {
                // If the directory has any sub-content
                if (Directory.EnumerateFileSystemEntries(fullPath).Any())
                {
                    DialogResult result = MessageBox.Show("The drawer you are about to delete has " +
                   "sub-content that will be deleted. Are you sure you want proceed?", "Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        // Delete direcotry and all sub-content
                        sr.getListOfItems().RemoveAll(item => item.getFullPath().Contains(fullPath));
                        return true;
                    }
                }
                else
                {

                    Directory.Delete(fullPath);
                    sr.getListOfItems().Remove(this);
                    return true;
                }
            }
            return false;
        }
    }
}
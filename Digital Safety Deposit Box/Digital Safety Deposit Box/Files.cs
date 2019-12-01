using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Safety_Deposit_Box
{
     class Files : Item
    {

        public Files(String name, String fullPath)
        {
            StorageRecord sr = new StorageRecord();
            this.isDrawer = false; 
            this.name = name;
            this.fullPath = fullPath;
            this.parent = sr.getTopDrawer();
            if (this.fullPath != null && !File.Exists(fullPath)) 
            {
                File.Create(fullPath).Close();
                sr.getListOfItems().Add(this);
            } 
        } 

        public Files(Drawer parent, String name)
        {
            StorageRecord sr = new StorageRecord();
            this.isDrawer = false;
            this.name = name;
            this.fullPath = parent.getFullPath() + "\\" + name;
            if (this.fullPath != null && !File.Exists(fullPath))
            {
                File.Create(fullPath).Close();
                sr.getListOfItems().Add(this);
            }
        }

        public bool delete()
        {
            if(File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true; 
            }
            return false; 
        }


        // Copies file with a new name then deletes the old instance. 
        public bool rename(String newName)
        {
            if (File.Exists(fullPath))
            {
                File.Copy(fullPath, fullPath.Replace(name, newName), true);
                File.Delete(fullPath);
                this.fullPath = this.fullPath.Replace(this.name, newName);
                this.name = newName; 
                return true;
            }
            return false;
        }
    }
}

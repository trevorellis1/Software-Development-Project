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
        // Contrustor for when there is no parent. 
        public Files(String name, String fullPath)
        {
            StorageRecord sr = new StorageRecord();

            this.isDrawer = false;
            this.name = name;
            this.fullPath = fullPath;
            setParent(fullPath, name);
            if (this.fullPath != null && !File.Exists(fullPath))
            {
                File.Create(fullPath).Close();
                sr.getListOfItems().Add(this);
            }
        }

        // Main constructor 
        public Files(Drawer parent, String name)
        {
            StorageRecord sr = new StorageRecord();

            this.isDrawer = false;
            this.name = name;
            this.fullPath = parent.getFullPath() + "\\" + name;
            this.parent = parent;
            if (this.fullPath != null && !File.Exists(fullPath))
            {
                File.Create(fullPath).Close();
                sr.getListOfItems().Add(this);
            }
        }

        public bool delete()
        {
            StorageRecord sr = new StorageRecord();

            if (this is Files && File.Exists(fullPath))
            {
                File.Delete(fullPath);
                sr.getListOfItems().Remove(this);
                return true;
            }
            return false;
        }
    }
}
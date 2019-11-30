using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Safety_Deposit_Box
{
    class Files : Item
    {
        public Files(String name, Drawer parent)
        {

            this.name = name;
            if (parent == null)
            {
                this.parent = new Drawer();
            }
            else
            {
                this.parent = parent;
            }

            this.fullPath = this.parent.getFullPath() + "\\" + this.name;
            if (create())
            {
                fileDrawerList.Add(this);
                this.parent.getChildren().Add(this);
            }

        }


        // Returns true upon successful creation of the file. 
        public bool create()
        {
            if (this.name == null || this.fullPath == null)
            {
                return false;
            }
            if (!File.Exists(fullPath))
            {
                File.Create(fullPath).Close();


                return true;
            }
            return false;
        }

        // Returns true upon successful deletion of the file. 
        public bool delete()
        {
            if (File.Exists(fullPath))
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
                File.Copy(name, fullPath.Replace(name, newName), true);
                File.Delete(fullPath);
                this.name = newName;
                this.fullPath = parent.getFullPath() + "\\" + newName;
                return true;
            }
            return false;
        }
    }
}
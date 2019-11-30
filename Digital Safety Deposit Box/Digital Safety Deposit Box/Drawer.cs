using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Safety_Deposit_Box
{
    class Drawer : Item
    {
        ArrayList children = new ArrayList(); 

        public Drawer(String name, Drawer parent)
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
            if(create())
            {
                fileDrawerList.Add(this);
                this.parent.getChildren().Add(this);
            }

        }

        // Used specifically for creating a drawer object representing the top directory. 
        public Drawer()
        {
            this.name = topDrawer;
            this.fullPath = System.IO.Directory.GetCurrentDirectory() + "\\" + topDrawer;
            create();
        }

        // Returns true upon successful creation of the drawer. 
        public bool create()
        {
            if (this.name == null || this.fullPath == null)
            {
                return false;
            }
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
                return true;
            }
            return false;
        }

        /* Returns true upon successful deletion of the folder. 
         * bool b = true, indicates that all sub-contents are to be deleted. */
        public bool delete(bool b)
        {
            if (Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath, b);
                return true;
            }
            return false;
        }


        public bool rename(String newName)
        {
            String newPath = parent.fullPath + "\\" + newName;

            // Changes the path for any folder/file contained within the folder to be renamed
            foreach (Item item in fileDrawerList)
            {
                if (item.getParent().Equals(this))
                {
                    item.setFullPath(newPath + "\\" + item.getName());
                }
            }

            if (Directory.Exists(fullPath) && !Directory.Exists(newPath))
            {
                Directory.Move(fullPath, newPath);
                name = newName;
                fullPath = newPath;

                return true;
            }
            return false;
        }

        public ArrayList getChildren()
        {
            return children;
        }
    }
}

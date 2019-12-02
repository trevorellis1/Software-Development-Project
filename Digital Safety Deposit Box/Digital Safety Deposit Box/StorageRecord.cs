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
    class StorageRecord
    {
        protected static ArrayList listOfItems = new ArrayList();
        public static Drawer topDrawer;
        const String topDrawerName = "DrawerLib";

        public StorageRecord()
        {
            addTopDrawer();
        }

        // Blank constructor 
        public StorageRecord(bool b)
        {

        }

        // Adds the top level directory to the record. 
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
                        listOfItems.Add(temp);
                    }
                }

                foreach (String item in Directory.GetDirectories(drawer.getFullPath()))
                {

                    if (Directory.Exists(item))
                    {
                        Drawer temp = new Drawer(drawer, Path.GetFileName(item));
                        listOfItems.Add(temp);
                        addExistingItems(temp);
                    }
                }
            }
        }

    
    

        public void addExistingFiles(Drawer drawer)
        {
            foreach(String item in Directory.GetDirectories(drawer.getFullPath()))
            {
                if (Directory.Exists(item))
                {
                    Drawer temp = new Drawer(drawer, Path.GetFileName(item));
                    listOfItems.Add(temp);
                    addExistingFiles(temp);
                }
            }
        }

        public void addExistingDrawers(Drawer drawer)
        {
            
        }

        // Returns a list of subdirectories and files under the input directory. 
        public ArrayList getChildrenOfDirectory(Drawer drawer) 
        {
            ArrayList results = new ArrayList(); 
            if(drawer != null)
            {
                foreach(Item item in listOfItems)
                {
                    if (Directory.GetFileSystemEntries(drawer.getFullPath()).Contains(item.getFullPath())) {
                            results.Add(item);
                    }
                }
            }
            return results; 
        }

        public Drawer getTopDrawer()
        {
            return topDrawer; 
        }

        public String getTopDrawerName()
        {
            return topDrawerName;
        }

        public ArrayList getListOfItems()
        {
            return listOfItems; 
        }
    }
}

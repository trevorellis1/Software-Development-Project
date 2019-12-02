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
        // Holds all the entries in the file/drawer system. 
        protected static ArrayList listOfItems = new ArrayList();
        // Top directory that holds everything else. 
        public static Drawer topDrawer;
        // The name of the top drawer 
        const String topDrawerName = "DrawerLib";

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
                        if (!listOfItems.Contains(temp)) {
                            listOfItems.Add(temp);
                        }
                    }
                }

                foreach (String item in Directory.GetDirectories(drawer.getFullPath()))
                {

                    if (Directory.Exists(item))
                    {
                        Drawer temp = new Drawer(drawer, Path.GetFileName(item));
                        if (!listOfItems.Contains(temp)) {
                            listOfItems.Add(temp);
                            addExistingItems(temp);
                        }
                    }
                }
            }
        }




        public void addExistingFiles(Drawer drawer)
        {
            foreach (String item in Directory.GetDirectories(drawer.getFullPath()))
            {
                if (Directory.Exists(item))
                {
                    Drawer temp = new Drawer(drawer, Path.GetFileName(item));
                    listOfItems.Add(temp);
                    addExistingFiles(temp);
                }
            }
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

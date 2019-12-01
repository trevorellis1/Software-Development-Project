﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Safety_Deposit_Box
{
    /* This class contains a list of all the files and drawers within the filesystem. 
       It also initiates the top directory within the system through the addTopDrawer() method used 
       in the first constructor. The top drawer, called DrawerLib, should be created at bin\debug 
       within the project folder. 
       */ 
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
            if(topDrawer == null)
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
                foreach (String item in Directory.GetFileSystemEntries(drawer.getFullPath(), "*", System.IO.SearchOption.AllDirectories)) 
                {
                    if (File.Exists(item))
                    {
                        Files newFiles = new Files(Path.GetFileName(item), item);
                        listOfItems.Add(newFiles);
                    }
                    else if (Directory.Exists(item))
                    {
                        Drawer newDrawer = new Drawer(Path.GetFileName(item), item);
                        listOfItems.Add(newDrawer);
                    }
                }
            }
        }

        // Returns a list of subdirectories and files directly under the input directory. 
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

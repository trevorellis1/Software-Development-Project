using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Safety_Deposit_Box
{
    // This class contains the delegates that act as click events for the file/drawer icons
     
    class DelegateEvent
    {
        EventHandler drawerSelect;
        EventHandler fileSelect;
        EventHandler drawerDoubleClick;
        EventHandler fileDoubleClick;
        StorageRecord sr = new StorageRecord();
        Item rename;
        ContextMenu cm; 

        public DelegateEvent(Item item, FlowLayoutPanel l, Button back)
        {
            createDrawerDoubleClick(item, l, back);
            createFileDoubleClick(item, l, back);
            
        }

        EventHandler createDrawerDoubleClick(Item item, FlowLayoutPanel flowLayoutPanel2, Button backButton)
        {
            drawerDoubleClick = delegate (object s, EventArgs e)
            {
                PictureBox p = (PictureBox)s;
                p.ContextMenu = cm; 
                sr.setCurrentDrawer((Drawer)item);
                flowLayoutPanel2.Controls.Clear();
                backButton.Enabled = true;
                sr.AddFolderToPanel((Drawer)p.Tag, flowLayoutPanel2);
                
            };
            return drawerDoubleClick;
        }

        EventHandler createFileDoubleClick(Item item, FlowLayoutPanel flowLayoutPanel2, Button backButton)
        {
            fileDoubleClick = delegate(Object s, EventArgs e) { 
                PictureBox p = (PictureBox)s;
                Files f = (Files)p.Tag;
                // Only handles .txt files right now. 
                //Process.Start(f.getFullPath());
                };
            return fileDoubleClick;
        }

        // For selecting a file through a single click
        EventHandler createFileSelect(Item item, FlowLayoutPanel flowLayoutPanel2, Button backButton)
        {
            fileSelect = delegate (Object s, EventArgs e) {
                PictureBox p = (PictureBox)s;
                if (p.Tag is Item)
                {
                    flowLayoutPanel2.SuspendLayout();
                    rename = (Item) p.Tag;
                    p.BorderStyle = BorderStyle.Fixed3D;
                    sr.addImageToPanel(p, flowLayoutPanel2);
                    Files f = (Files)p.Tag;
                    flowLayoutPanel2.ResumeLayout();

                }
            };
            return fileSelect;
        }

        // For selecting a drawer through a single click 
        EventHandler createDrawerSelect(Item item, FlowLayoutPanel flowLayoutPanel2, Button backButton)
        {
            drawerSelect = delegate (Object s, EventArgs e) {
                PictureBox p = (PictureBox)s;
                if (p.Tag is Item)
                {
                    rename = (Item)p.Tag;
                    flowLayoutPanel2.SuspendLayout(); 
                    p.BorderStyle = BorderStyle.Fixed3D;
                    sr.addImageToPanel(p, flowLayoutPanel2);
                    Drawer f = (Drawer)p.Tag;
                    flowLayoutPanel2.ResumeLayout(); 
                }
            };
            return drawerSelect;
        }

        public EventHandler getDrawerSelect()
        {
            return drawerSelect; 
        }

        public EventHandler getFileSelect()
        {
            return fileSelect;
        }

        public EventHandler getDrawerDoubleClick()
        {
            return drawerDoubleClick; 
        }
       
        public EventHandler getFileDoubleClick()
        {
            return fileDoubleClick;
        }

        public Item getRename()
        {
            return rename; 
        }
    }
}

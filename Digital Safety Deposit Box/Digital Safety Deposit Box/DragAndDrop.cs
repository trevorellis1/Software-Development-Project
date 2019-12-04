using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Safety_Deposit_Box
{
    public partial class DragAndDrop : Form
    {
        FlowLayoutPanel f2;
        Button back;
        Drawer d;
        Files f; 

        public DragAndDrop(FlowLayoutPanel f2, Button backButton)
        {
            InitializeComponent();
            this.f2 = f2;
            this.back = backButton; 
        }

        private void listBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            String[] s = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                listBox1.Items.Add(s[i]);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            StorageRecord sr = new StorageRecord(); 
            foreach(String s in listBox1.Items)
            {
                if (Directory.Exists(s))
                {
                    d = new Drawer(sr.getCurrentDrawer(), Path.GetFileName(s));
                    if (!sr.getListOfItems().Contains(d))
                    {
                        sr.getListOfItems().Add(d);
                    }
                    sr.drawImage(d, f2, back, Font);
                    sr.addImageToPanel(d.getPictureBox(), f2);                    
                    iterateFolder(d, sr);
                }
                else if (File.Exists(s))
                {
                    f = new Files(sr.getCurrentDrawer(), Path.GetFileName(s));
                    if (!sr.getListOfItems().Contains(f))
                    {
                        sr.getListOfItems().Add(f);
                    }
                    sr.drawImage(f, f2, back, Font);
                    sr.addImageToPanel(f.getPictureBox(), f2);
                }
            }
            this.Close(); 
        }
        
        private void iterateFolder(Drawer drawer, StorageRecord sr)
        {
            if (drawer != null)
            {
                foreach (String file in Directory.GetFiles(drawer.getFullPath()))
                {
                    if (File.Exists(file))
                    {
                        Files temp = new Files(drawer, Path.GetFileName(file));
                        sr.drawImage(temp, f2, back, Font);
                        if (!sr.getListOfItems().Contains(temp))
                        {
                            sr.getListOfItems().Add(temp);
                        }
                    }
                }

                foreach (String item in Directory.GetDirectories(drawer.getFullPath()))
                {

                    if (Directory.Exists(item))
                    {
                        Drawer temp = new Drawer(drawer, Path.GetFileName(item));
                        sr.drawImage(temp, f2, back, Font);
                        if (!sr.getListOfItems().Contains(temp))
                        {
                            sr.getListOfItems().Add(temp);
                            iterateFolder(temp, sr);
                        }
                    }
                }
            }
        } 
    }
}

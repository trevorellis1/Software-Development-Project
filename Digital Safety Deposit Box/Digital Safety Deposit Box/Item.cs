using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Safety_Deposit_Box
{
    class Item { 
    // Records all the drawers and files 
    protected static ArrayList fileDrawerList = new ArrayList();

    protected const String topDrawer = "DrawerLib";

    // Parent directory. 
    protected Drawer parent;

    // The path to the current item. 
    protected String fullPath;

    // Name of the item 
    protected String name;

    Button button;

    public Item()
    {

    }

    public void setName(String s)
    {
        this.name = s;
    }

    public String getName()
    {
        return this.name;
    }

    public void setFullPath(String s)
    {
        this.fullPath = s;
    }

    public String getFullPath()
    {
        return fullPath;
    }

    public void setParent(Drawer d)
    {
        this.parent = d;
    }

    public Drawer getParent()
    {
        return this.parent;
    }

    public ArrayList getFileDrawerList()
        {
            return fileDrawerList;
        }

    public Button getButton()
        {
            return button; 
        }
    public void setButton(Button button)
        {
            this.button = button; 
        }
    }
}

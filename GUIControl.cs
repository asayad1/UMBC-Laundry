using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMBC_Laundry
{
    internal class GUIControl
    {
        void CreateGUIElement()
        {
            Panel parent_panel = new Panel();
            Size parent_size = new Size(685, 100);
            Point parent_loc = new Point(0, 0);
            PictureBox dryer_image = new PictureBox();
            PictureBox washer_image = new PictureBox();
            Label room_name = new Label();
            Label avail_dryers = new Label();
            Label avail_washers = new Label();
        }

        void CreatePanel()
        {

        }
        
        void CreateLabel()
        {

        }

        void CreatePictureBox()
        {

        }

        // Panel with textbox, washer/dryer image count
        // On click creates popup from the bottom 
    }
}

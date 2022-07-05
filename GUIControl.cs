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
        Form1 ControlForm { get; set; }
        Size PANEL_SIZE = new Size(355, 390);
        Size DOCK_PANEL_SIZE = new Size(356, 405);
        Point DEFAULT_PANEL_LOC = new Point(0, 0);


        public GUIControl(Form1 form)
        {
            ControlForm = form;
            //CreateFlowPanel();
        }


        public void CreateRoomTemplate()
        {
            // Create the docking panels
            FlowLayoutPanel washerPanels = CreateFlowPanel(new Point(58, 75), DOCK_PANEL_SIZE);
            FlowLayoutPanel dryerPanels = CreateFlowPanel(new Point(414, 75), DOCK_PANEL_SIZE);

            for (int i = 0; i < 10; i ++)
               washerPanels.Controls.Add(CreateInfoPanel());



            // Add the panels to the control 
            ControlForm.Controls.Add(washerPanels);
            ControlForm.Controls.Add(dryerPanels);

        }


        Panel CreateInfoPanel()
        {
            Panel infoPanel = CreatePanel(DEFAULT_PANEL_LOC, new Size(330, 42));
            
            
            
            return infoPanel;
        }


        public void CreateGUIElement(string room_name, string avail_wash, string avail_dry)
        {
            //Panel dock_panel = CreatePanel();
            Label room = CreateLabel(room_name, new Point(0, 0), new Size(100, 30));
            Label avail_washers = CreateLabel(avail_wash, new Point(185, 10), new Size(40, 30));
            Label avail_dryers = CreateLabel(avail_dry, new Point(285, 10), new Size(40, 30));

            PictureBox washer = CreatePictureBox(Properties.Resources.washer, new Point(130, 0));
            PictureBox dryer = CreatePictureBox(Properties.Resources.dryer, new Point(230, 0));

            //dock_panel.Controls.Add(room);
            //dock_panel.Controls.Add(avail_washers);
            //dock_panel.Controls.Add(avail_dryers);
            //dock_panel.Controls.Add(washer);
            //dock_panel.Controls.Add(dryer);
        }

        FlowLayoutPanel CreateFlowPanel(Point location, Size size)
        {
            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.Location = location;
            flowPanel.AutoScroll = true;
            flowPanel.FlowDirection = FlowDirection.LeftToRight;
            flowPanel.Size = size;
            return flowPanel;
        }

        Panel CreatePanel(Point location, Size size)
        {
            Panel panel = new Panel();
            panel.Location = location;
            panel.Size = size;
            panel.BackColor = Color.PeachPuff;
            return panel;
        }
        
        Label CreateLabel(string text, Point location, Size size)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font("Arial", 15);
            label.Location = location;
            label.Size = size;
            return label; 
        }

        PictureBox CreatePictureBox(Image image, Point location)
        {
            PictureBox picture = new PictureBox();
            picture.Location = location;
            picture.Size = new Size(50, 50);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.Image = image;
            return picture;
        }
    }
}

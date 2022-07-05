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
        Size DOCK_PANEL_SIZE = new Size(356, 405);
        Point DEFAULT_PANEL_LOC = new Point(0, 0);

        public GUIControl(Form1 form)
        {
            ControlForm = form;
        }

        /*
        public void CreateSideTemplate()
        {
            // Create the panel
            Panel side_panel = CreatePanel(DEFAULT_PANEL_LOC, new Size(317, 482));
            side_panel.BackColor = Color.FromArgb(237, 165, 32);
            side_panel.BorderStyle = BorderStyle.FixedSingle;
            side_panel.RightToLeft = RightToLeft.Yes;

            ControlForm.Controls.Add(side_panel);
        }
        */

        public void CreateRoomTemplate()
        {
            // Create the room label
            Label room_name = CreateLabel("Room Name", new Point(50, 0), 32, new Size(600, 50), true);
            Label update_label = CreateLabel("Updating In:", new Point(57, 47), 11, new Size(85, 18), false);
            Label update_label_num = CreateLabel("60s", new Point(139, 48), 11, new Size(32, 18), false);
            Label available_machines = CreateLabel("0 W, 0 D", new Point(236, 47), 11, new Size(61, 18), false);


            // Create the docking panels
            FlowLayoutPanel washerPanels = CreateFlowPanel(new Point(55, 75), DOCK_PANEL_SIZE);
            FlowLayoutPanel dryerPanels = CreateFlowPanel(new Point(414, 75), DOCK_PANEL_SIZE);

            
            for (int i = 0; i < 5; i ++)
            { 
                washerPanels.Controls.Add(CreateInfoPanel());
                dryerPanels.Controls.Add(CreateInfoPanel());
            }

            // Add the panels to the control 
            ControlForm.Controls.Add(room_name);
            ControlForm.Controls.Add(update_label);
            ControlForm.Controls.Add(update_label_num);
            ControlForm.Controls.Add(available_machines);
            ControlForm.Controls.Add(washerPanels);
            ControlForm.Controls.Add(dryerPanels);
        }


        Panel CreateInfoPanel()
        {
            Panel infoPanel = CreatePanel(DEFAULT_PANEL_LOC, new Size(330, 42));
            Label machine_type = CreateLabel("Washer 00", new Point(0, 8), 17, new Size(125, 25), false);
            Label machine_status = CreateLabel("Available", new Point(225, 8), 17, new Size(200, 25), false);
            
            
            // Add the controls to the panel
            infoPanel.Controls.Add(machine_type);
            infoPanel.Controls.Add(machine_status);

            return infoPanel;
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
            
            /// Color will change depending on if the machine is available
            panel.BackColor = Color.Goldenrod;


            return panel;
        }
        
        Label CreateLabel(string text, Point location, int fnt_size, Size size, bool underline)
        {
            Label label = new Label();
            label.Text = text;
            
            if (underline)
            {
                label.Font = new Font("Roboto Light", fnt_size, FontStyle.Underline);
            }
            else
            {
                label.Font = new Font("Roboto Light", fnt_size);
            }

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

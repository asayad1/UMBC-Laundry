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
        Size PANEL_SIZE = new Size(340, 50);
        FlowLayoutPanel MasterPanel;

        public GUIControl(Form1 form)
        {
            ControlForm = form;
            CreateFlowPanel();
            for (int i = 0; i < 10; i++)
                CreateGUIElement("ABRV-00", "00", "00");
        }

        public void CreateGUIElement(string room_name, string avail_wash, string avail_dry)
        {
            Panel dock_panel = CreatePanel();
            Label room = CreateLabel(room_name, new Point(0, 0), new Size(100, 30));
            Label avail_washers = CreateLabel(avail_wash, new Point(185, 10), new Size(40, 30));
            Label avail_dryers = CreateLabel(avail_dry, new Point(285, 10), new Size(40, 30));

            PictureBox washer = CreatePictureBox(Properties.Resources.washer, new Point(130, 0));
            PictureBox dryer = CreatePictureBox(Properties.Resources.dryer, new Point(230, 0));

            dock_panel.Controls.Add(room);
            dock_panel.Controls.Add(avail_washers);
            dock_panel.Controls.Add(avail_dryers);
            dock_panel.Controls.Add(washer);
            dock_panel.Controls.Add(dryer);

            MasterPanel.Controls.Add(dock_panel);
        }

        void CreateFlowPanel()
        {
            MasterPanel = new FlowLayoutPanel();
            MasterPanel.Location = new Point(0, 0);
            MasterPanel.AutoScroll = true;
            MasterPanel.FlowDirection = FlowDirection.LeftToRight;
            MasterPanel.Size = new Size(365, 390);
            MasterPanel.BackColor = Color.Black;
            ControlForm.Controls.Add(MasterPanel);
        }

        Panel CreatePanel()
        {
            Panel panel = new Panel();
            panel.Location = new Point(0, 0);
            panel.Size = PANEL_SIZE;
            panel.BackColor = Color.Goldenrod;
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

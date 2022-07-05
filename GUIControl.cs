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
        public List<Control> controls = new List<Control>();

        public GUIControl(Form1 form)
        {
            ControlForm = form;
        }

        public void CreateRoomTemplate(LaundryRoom room)
        {
            // Derender controls if there are any
            if (controls.Count > 0)
            {
                DerenderControls();
            }

            int avail_washers = 0;
            int avail_dryers = 0;

            // Create the room label
            Label room_name = CreateLabel(room.name, new Point(50, 0), 32, new Size(700, 50), true);
            Label update_label = CreateLabel("Updating In:", new Point(57, 47), 11, new Size(85, 18), false);
            Label update_label_num = CreateLabel("60", new Point(139, 48), 11, new Size(32, 18), false);
            Label available_machines = CreateLabel("0 W, 0 D", new Point(236, 47), 11, new Size(85, 18), false);

            // Create the docking panels
            FlowLayoutPanel washerPanels = CreateFlowPanel(new Point(55, 75), DOCK_PANEL_SIZE);
            FlowLayoutPanel dryerPanels = CreateFlowPanel(new Point(414, 75), DOCK_PANEL_SIZE);


            // Load machine info 
            foreach (Machine machine in room.objects)
            {
                // Add to washer info
                if (machine.appliance_type == "W")
                {
                    if (machine.time_left_lite == "Available")
                    {
                        avail_washers += 1;
                    }
                    string machine_number = "Washer " + machine.appliance_desc;
                    string machine_status = machine.time_left_lite;
                    Panel infoPanel = CreateInfoPanel(machine_number, machine_status, machine.percentage);
                    washerPanels.Controls.Add(infoPanel);
                }
                // Add to dryer info
                else
                {
                    if (machine.appliance_type == "D")
                    {
                        if (machine.time_left_lite == "Available")
                        {
                            avail_dryers += 1;
                        }
                        string machine_number = "Dryer " + machine.appliance_desc;
                        string machine_status = machine.time_left_lite;
                        Panel infoPanel = CreateInfoPanel(machine_number, machine_status, machine.percentage);
                        
                        dryerPanels.Controls.Add(infoPanel);
                    }

                    if (machine.appliance_desc2 != null)
                    {
                        if (machine.time_left_lite2 == "Available")
                        {
                            avail_dryers += 1;
                        }
                        string machine_number2 = "Dryer " + machine.appliance_desc2;
                        string machine_status2 = machine.time_left_lite2;
                        Panel infoPanel = CreateInfoPanel(machine_number2, machine_status2, machine.percentage2);
                        dryerPanels.Controls.Add(infoPanel);
                    }
                }

                available_machines.Text = avail_washers + " W, " + avail_dryers + " D";
            }

            // Add the panels to the control 
            controls.Add(room_name);
            controls.Add(update_label);
            controls.Add(update_label_num);
            controls.Add(available_machines);
            controls.Add(washerPanels);
            controls.Add(dryerPanels);

            ControlForm.Controls.Add(room_name);
            ControlForm.Controls.Add(update_label);
            ControlForm.Controls.Add(update_label_num);
            ControlForm.Controls.Add(available_machines);
            ControlForm.Controls.Add(washerPanels);
            ControlForm.Controls.Add(dryerPanels);
        }

        void DerenderControls()
        {
            foreach (Control control in controls)
            {
                control.Location = new Point(0, 350);
                control.Dispose();
            }
            controls.Clear();
        }

        Panel CreateInfoPanel(string machine_name, string machine_state, string percentage)
        {
            Panel infoPanel = CreatePanel(DEFAULT_PANEL_LOC, new Size(330, 42));
            Label machine_type = CreateLabel(machine_name, new Point(0, 8), 17, new Size(125, 25), false);
            Label machine_status = CreateLabel(machine_state, new Point(225, 8), 17, new Size(200, 25), false);

            // Handling colors & formatting
            if (machine_state == "Offline")
            {
                machine_status.Location = new Point(250, 8);
                infoPanel.BackColor = Color.Gray;
            }
            else if (machine_state == "Out of service")
            {
                machine_status.Location = new Point(180, 8);
                infoPanel.BackColor = Color.Maroon;
            }
            else if (machine_state == "Available")
            {
                infoPanel.BackColor = Color.Goldenrod;
            }
            else
            {
                string fpercent = percentage.Substring(0, 4);
                machine_status.Text = "In Use (" + fpercent + "%)"; 
                infoPanel.BackColor = Color.DarkGoldenrod;
                machine_status.Location = new Point(175, 8);
            }



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
            
            // Color will change depending on if the machine is available
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
    }
}

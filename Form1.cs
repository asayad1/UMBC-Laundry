using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Drawing;

namespace UMBC_Laundry
{
    public partial class Form1 : Form
    {     
        GUIControl gui;
        bool isPanelOpen = false;
        string current_room_loc = "484103";
        public Form1()
        {
            InitializeComponent();
            gui = new GUIControl(this);
        }

        void LoadLaundryData(string room_loc)
        {
            string json = GETRequest(room_loc);
            LaundryRoom room = JsonConvert.DeserializeObject<LaundryRoom>(json);
            room.name = APIHelper.room_details[room_loc];
            room.ID = room_loc;

            gui.CreateRoomTemplate(room);
        }

        string GETRequest(string room_loc)
        {
            // Handle decompression whenever we have a GetRequest 
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };

            // Get JSON response from API 
            using (var client = new HttpClient(clientHandler))
            {
                var url = APIHelper.FormatURL(room_loc);
                var result = client.GetAsync(url).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                return json; 
            }
        }

        #region Events
        private void panel_MouseEnter(object sender, EventArgs e)
        {
            Control p = (Control)sender;

            // Make sure the panel is open
            if (isPanelOpen)
            {
                // If the control is not the container panel, set too transparent
                if (p.Parent != roomPanel)
                {
                    p.BackColor = Color.Transparent;
                    p.Parent.BackColor = Color.FromArgb(247, 200, 0);
                } else
                {
                    p.BackColor = Color.FromArgb(247, 200, 0);
                }
            }
        }

        private void panel_MouseLeave (object sender, EventArgs e)
        {
            Control p = (Control)sender;

            // Only if panel is open
            if (isPanelOpen)
            {
                // If the control is not the container panel, set too transparent
                if (p.Parent != roomPanel)
                {
                    p.BackColor = Color.Transparent;
                }
                else
                {
                    p.BackColor = Color.FromArgb(237, 165, 32);
                }
            }
        }

        // Move the panel into place
        private void optionsButton_MouseClick(object sender, MouseEventArgs e)
        {
            isPanelOpen = (isPanelOpen) ? false : true; 
            roomPanel.Location = (roomPanel.Location.X < 0) ? (new Point(0, 0)) : (new Point(-265, 0));
        }

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            // Either click on panel, or label
            Control p = (Control)sender;
            string loc;

            // If the control is not the container panel, set too transparent
            if (p.Parent != roomPanel)
            {
                loc = p.Parent.Tag.ToString();
            }
            else
            {
                loc = p.Tag.ToString();
            }

            // Render the info panels
            current_room_loc = loc;
            LoadLaundryData(current_room_loc);
        }
        #endregion

        private void Form1_Shown(object sender, EventArgs e)
        {
            LoadLaundryData(current_room_loc);
            refreshTimer.Enabled = true;
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (gui.controls[2].Text != "0")
            {
                gui.controls[2].Text = (Int32.Parse(gui.controls[2].Text) - 1).ToString();
            }
            else
            {
                // Update the room details
                LoadLaundryData(current_room_loc);
                gui.controls[2].Text = "60";
            }
        }

        // Open the settings form 
        private void settingsButton_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}

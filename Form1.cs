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
        LaundryList laundry_rooms = new LaundryList();
        GUIControl gui; 


        public Form1()
        {
            InitializeComponent();
            gui = new GUIControl(this);
        }

        void LoadLaundryData()
        {
            foreach (string room_loc in APIHelper.room_details.Keys)
            {
                string json = GETRequest(room_loc);
                LaundryRoom room = JsonConvert.DeserializeObject<LaundryRoom>(json);
                room.name = APIHelper.room_details[room_loc];
                room.ID = room_loc;
                laundry_rooms.room_list.Add(room);
            }
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

        private void panel_MouseLeave (object sender, EventArgs e)
        {
            Control p = (Control)sender;

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

        // Move the panel into place
        private void optionsButton_MouseClick(object sender, MouseEventArgs e)
        {
            roomPanel.Location = (roomPanel.Location.X < 0) ? (new Point(0, 0)) : (new Point(-265, 0));
        }
        #endregion

        private void Form1_Shown(object sender, EventArgs e)
        {
            LoadLaundryData();
            gui.CreateRoomTemplate();

        }
    }
}

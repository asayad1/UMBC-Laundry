using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace UMBC_Laundry
{
    public partial class Form1 : Form
    {
        Rooms rooms;
        LaundryList laundry_rooms;

        public Form1()
        {
            InitializeComponent();
            LoadRooms();
            LoadLaundryData();
        }

        void LoadRooms()
        {
            // Handle decompression whenever we have a GetRequest 
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };

            // Get JSON response from API 
            using (var client = new HttpClient(clientHandler))
            {
                var url = APIHelper.FormatURL(APIHelper.ROOMS_PROJ_KEY);
                var result = client.GetAsync(url).Result;
                var json = result.Content.ReadAsStringAsync().Result;

                // Deserialize the JSON into a list 
                rooms = JsonConvert.DeserializeObject<Rooms>(json);

                foreach (RoomDetails room in rooms.room_list)
                {
                    roomList.Items.Add(room.name);
                }
            }
        }

        void LoadLaundryData()
        {
            // Handle decompression whenever we have a GetRequest 
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };

            // Get JSON response from API 
            using (var client = new HttpClient(clientHandler))
            {
                var url = APIHelper.FormatURL(APIHelper.LAUNDRY_PROJ_KEY);
                var result = client.GetAsync(url).Result;
                var json = result.Content.ReadAsStringAsync().Result;

                // Deserialize the JSON into a list 
                laundry_rooms = JsonConvert.DeserializeObject<LaundryList>(json);

                foreach (LaundryRoom room in laundry_rooms.room_list)
                {
                    richTextBox1.AppendText("------------------------\n");
                    richTextBox1.AppendText("Name: " + room.room + '\n');
                    richTextBox1.AppendText("ID: " + room.ID+ '\n');
                    richTextBox1.AppendText("# Dryers: " + room.available_dryers + '\n');
                    richTextBox1.AppendText("# Washers: " + room.available_washers + '\n');
                }
            }
        }

        // Load laundry info every time we change rooms 
        private void roomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Find and pass the appropriate room code to the parser
            //GetLaundryData(UMBC_ID + rooms[roomList.SelectedItem.ToString()]);
        }
    }
}

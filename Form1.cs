using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace UMBC_Laundry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadRooms();
        }

        void LoadRooms()
        {
            // Handle decompression whenever we have a GetRequest 
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };

            // Get JSON response from API 
            using (var client = new HttpClient(clientHandler))
            {
                var url = URLFormatter(APIHelper.ROOMS_PROJ_KEY);
                var result = client.GetAsync(url).Result;
                var json = result.Content.ReadAsStringAsync().Result;

                // Deserialize the JSON into a list 
                Rooms rooms = JsonConvert.DeserializeObject<Rooms>(json);

                foreach (RoomDetails room in rooms.room_list)
                {
                    roomList.Items.Add(room.name);
                }
            }
        }

        private string URLFormatter(string PROJ_KEY)
        {
            return APIHelper.DEFAULT_URL + PROJ_KEY + "/last_ready_run/data?api_key=" + APIHelper.API_KEY;
        }


        // Load laundry info every time we change rooms 
        private void roomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Find and pass the appropriate room code to the parser
            //GetLaundryData(UMBC_ID + rooms[roomList.SelectedItem.ToString()]);
        }
    }
}

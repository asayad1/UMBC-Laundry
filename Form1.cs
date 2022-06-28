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
            string json = GETRequest(APIHelper.ROOMS_PROJ_KEY);
            rooms = JsonConvert.DeserializeObject<Rooms>(json); 
        }

        void LoadLaundryData()
        {
            string json = GETRequest(APIHelper.LAUNDRY_PROJ_KEY);
            laundry_rooms = JsonConvert.DeserializeObject<LaundryList>(json);
        }

        string GETRequest(string PROJECT_KEY)
        {
            // Handle decompression whenever we have a GetRequest 
            var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };

            // Get JSON response from API 
            using (var client = new HttpClient(clientHandler))
            {
                var url = APIHelper.FormatURL(PROJECT_KEY);
                var result = client.GetAsync(url).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                return json; 
            }
        }

        // Load laundry info every time we change rooms 
        private void roomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Find and pass the appropriate room code to the parser
        }
    }
}

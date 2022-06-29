using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UMBC_Laundry
{
    public partial class Form1 : Form
    {     
        Rooms rooms;
        LaundryList laundry_rooms;
        Dictionary<string, string> abrevs = new Dictionary<string, string>()
        {
            {"484103", "CPK-58"},
            {"484102", "CPK-58B"},
            {"4841027", "CC-LR" },
            {"4841013", "ERK-36"},
            {"4841014", "ERK-111"},
            {"4841011", "HH-114B"},
            {"4841026", "HH-114F"},
            {"484107", "ELK-14"},
            {"4841019", "PTP-8"},
            {"4841018", "PTP-56"},
            {"4841024", "PTP-171"},
            {"4841017", "PMC-3" },
            {"4841015", "PMC-59"},
            {"4841023", "SUS-18"},
            {"4841022", "SUS-71"}
        };

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
    }
}

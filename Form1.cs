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
        LaundryRoom rooms;
        LaundryList laundry_rooms;


        public Form1()
        {
            InitializeComponent();  
            LoadLaundryData();
        }


        void LoadLaundryData()
        {
            string json = GETRequest("484107");
            rooms = JsonConvert.DeserializeObject<LaundryRoom>(json);
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
    }
}

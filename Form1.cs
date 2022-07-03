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
        LaundryList laundry_rooms = new LaundryList();

        public Form1()
        {
            InitializeComponent();  
            LoadLaundryData();
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
    }
}

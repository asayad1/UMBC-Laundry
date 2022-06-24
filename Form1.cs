using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using HtmlAgilityPack;
using System.Net;
using System.IO;

/*
 * 
 * Will focus on getting DOM updates after JS scripts run on webpage
 * 
 * 
 */

namespace UMBC_Laundry
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        string UMBC_ID = "https://www.laundryview.com/home/5803/48410";
        string API_KEY = "td8ExBj5mtf-";

        /*
        IDictionary<string, string> rooms = new Dictionary<string, string>()
        {
            {"Chesapeake Hall 58A", "3"},
            {"Chesapeake Hall 58B", "2"},
            {"Community Center LR", "27"},
            {"Erickson Hall 36", "13"},
            {"Erickson Hall 111", "14"},
            {"Harbor Hall 114 Back", "11"},
            {"Harbor Hall 114 Front", "26"},
            {"Hillside Apartments Elk 14", "7"},
            {"Patapsco Hall 8", "19"},
            {"Patapsco Hall 56", "18"},
            {"Patapsco Hall 171", "24"},
            {"Potomac Hall 3", "17"},
            {"Potomac Hall 59", "15"},
            {"Susquehanna Hall 18", "23"},
            {"Susquehanna Hall 71", "22"}
        };
        */

        public Form1()
        {
            InitializeComponent();

            // Load rooms once 
            
            LoadRooms();



        }

        void LoadRooms()
        {
            // Post request to start project task 
            string url = "https://www.parsehub.com/api/v2/projects/tpRJpjCBPSBg/run";
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Credentials = new NetworkCredential("email", "password");

            string postData = "{\"api_key\":\"" + API_KEY + "\"";
            using (var sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(postData);
                sw.Flush();
                sw.Close();

                var response = (HttpWebResponse)request.GetResponse();

                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    var result = sr.ReadToEnd();

                    richTextBox1.AppendText(result);
                }
            }

//            richTextBox1.AppendText(result);
        }

        async void GetLaundryData(string url)
        {
            var html = await client.GetStringAsync(url);
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);

            richTextBox1.AppendText("Wiat!\n");
        }

        // Load laundry info every time we change rooms 
        private void roomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Find and pass the appropriate room code to the parser
            //GetLaundryData(UMBC_ID + rooms[roomList.SelectedItem.ToString()]);
        }
    }
}

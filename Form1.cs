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


/*
 * 
 * Will focus on getting DOM updates after JS scripts run on webpage
 *  
 */



namespace UMBC_Laundry
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        string UMBC_ID = "https://www.laundryview.com/home/5803/48410";
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

        public Form1()
        {
            InitializeComponent();
            LoadRooms();
        }

        void LoadRooms()
        {
            foreach (string room in rooms.Keys)
            {
                roomList.Items.Add(room);   
            }
        }

        async void GetLaundryData(string url)
        {
            var html = await client.GetStringAsync(url);
        }

        // Load laundry info every time we change rooms 
        private void roomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Find and pass the appropriate room code to the parser
            GetLaundryData(UMBC_ID + rooms[roomList.SelectedItem.ToString()]);
        }
    }
}

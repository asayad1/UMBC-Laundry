using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMBC_Laundry
{
    internal static class APIHelper
    {
        public static readonly string DEFAULT_URL = "https://www.laundryview.com/api/currentRoomData?school_desc_key=5803&location=";

        public static Dictionary<string, string> room_details = new Dictionary<string, string>()
        {
            {"484103", "CHESAPEAKE HALL - ROOM 058A"},
            {"484102", "CHESAPEAKE HALL - ROOM 058B"},
            {"4841027", "COMMUNITY CENTER-LR"},
            {"4841013", "ERICKSON HALL - ROOM 036"},
            {"4841014", "ERICKSON HALL - ROOM 111"},
            {"4841011", "HARBOR HALL - 114 BACK ROOM"},
            {"4841026", "HARBOR HALL 114 - FRONT ROOM"},
            {"484107", "HILLSIDE APARTMENTS - ELK 14"},
            {"4841019", "PATAPSCO HALL - ROOM 008"},
            {"4841018", "PATAPSCO HALL - ROOM 056"},
            {"4841024", "PATAPSCO HALL - ROOM 171"},
            {"4841017", "POTOMAC HALL - ROOM 003" },
            {"4841015", "POTOMAC HALL - ROOM 059"},
            {"4841023", "SUSQUEHANNA HALL - ROOM 018"},
            {"4841022", "SUSQUEHANNA HALL - ROOM 071"}
        };

        public static string FormatURL(string room_loc)
        {
            return DEFAULT_URL + room_loc;
        }
    }
}

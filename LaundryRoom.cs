using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMBC_Laundry
{
    internal class LaundryRoom
    {
        public string ID { get; set; }
        public string room { get; set; }
        public string available_washers { get; set; }
        public string available_dryers { get; set; }
        public List<Washer> washer { get; set; }
        public List<Dryer> dryer { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMBC_Laundry
{
    internal class LaundryRoom
    {
        public List<Machine> objects { get; set; }
        public string ID { get; set; }
        public string name { get; set; }
        public string available_dryers { get; set; }
        public string available_washers { get; set; }
    }
}

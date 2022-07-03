using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMBC_Laundry
{
    internal class Machine
    {
        public string appliance_type { get; set; } // Tells us if washer or dryer 
        public string appliance_desc { get; set; } // Tells us machine number
        public string time_left_lite { get; set; } // Tells us washer availability
        public string percentage { get; set; }     // Tells us % done if machine is being used 

        /// <summary>
        /// If there are double
        /// </summary>
        public string appliance_type2 { get; set; } // Tells us if washer or dryer 
        public string appliance_desc2 { get; set; } // Tells us machine number
        public string time_left_lite2 { get; set; } // Tells us washer availability
        public string percentage2 { get; set; }     // Tells us % done if machine is being used 


    }
}

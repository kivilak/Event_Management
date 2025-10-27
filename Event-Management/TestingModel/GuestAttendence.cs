using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management.TestingModel
{
    internal class GuestAttendence
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int Invited { get; set; }
        public  int Confirmed { get; set; }
        public int Declined { get; set; }
        public int Pending { get; set; }
        public double ResponseRate
        {
            get
            {
                if (Invited == 0) return 0; // avoid division by zero
                return ((double)Confirmed / Invited) * 100;
            }
        }
    }
}

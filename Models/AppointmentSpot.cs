using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter.Models
{
    class AppointmentSpot
    {
        public DateTime SpotDateTime { get; set; }
        public bool IsBooked { get; set; }
        public int? PatientId { get; set; } // Track which patient booked it
    }
}

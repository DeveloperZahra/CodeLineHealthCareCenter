using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    class Booking
    {
        public int Id { get; set; } // Unique identifier for the booking
        public int PatientId { get; set; } // Identifier for the patient making the booking
        public int ClinicId { get; set; }   // Identifier for the clinic where the booking is made
        public DateTime AppointmentDate { get; set; } // Date and time of the appointment
        public string AppointmentType { get; set; } // Type of appointment (e.g., consultation, follow-up, etc.)
    }
}

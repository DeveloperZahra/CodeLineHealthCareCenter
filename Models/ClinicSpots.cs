using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter.Models
{
    public class ClinicSpots
    {
        public int ClinicID { get; set; }            // ID of the clinic
        public DateTime Date_Time { get; set; }      // Date and time of the spot
        public bool IsBooked { get; set; }           // Status of the spot
        public int? PatientID { get; set; }          // Patient ID if booked
        public string PatientName { get; set; }      // Patient Name if booked

        // defualt constructor
        public ClinicSpots()
        {
            ClinicID = 0;
            Date_Time = DateTime.MinValue;
            IsBooked = false;
            PatientID = null;
            PatientName = string.Empty;
        }
        // Constructor
        public ClinicSpots(int clinicID, DateTime dateTime)
        {
            ClinicID = clinicID;
            Date_Time = dateTime;
            IsBooked = false;
            PatientID = null;
            PatientName = string.Empty;
        }
    }
}
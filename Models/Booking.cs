using HospitalSystemTeamTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalSystemTeamTask.Services;
using System.Security.Claims;

namespace CodeLineHealthCareCenter
{
    class Booking   
    {
        // 1. Class Fields
        public int id; // Unique identifier for the booking
        public int patientId; // Unique identifier for the patient
        public int clinicId; // Unique identifier for the clinic
        public DateTime appointmentDate; // Date and time of the appointment
        public string appointmentType; // Type of appointment (e.g., consultation, follow-up)

        //2. Class Properties
        public int Id //Unique identifier for the booking
        {
            get { return id; }
            set { id = value; }
        }
    }
}

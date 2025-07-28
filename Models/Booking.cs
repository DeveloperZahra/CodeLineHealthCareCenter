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

        public int PatientId // Unique identifier for the patient
        {
            get { return patientId; }
            set { patientId = value; }
        }
        public int ClinicId // Unique identifier for the clinic
        {
            get { return clinicId; }
            set { clinicId = value; }
        }
        public DateTime AppointmentDate // Date and time of the appointment
        {
            get { return appointmentDate; }
            set { appointmentDate = value; }
        }
        public string AppointmentType // Type of appointment (e.g., consultation, follow-up)
        {
            get { return appointmentType; }
            set { appointmentType = value; }
        }

        // 3. Class Constructor

        // Default constructor
        public Booking() { }

        // Constructor with parameters
        public Booking(int id, int patientId, int clinicId, DateTime appointmentDate, string appointmentType) 
        {
            this.id = id; // Unique identifier for the booking
            this.patientId = patientId; // Unique identifier for the patient
            this.clinicId = clinicId; // Unique identifier for the clinic
            this.appointmentDate = appointmentDate; // Date and time of the appointment
            this.appointmentType = appointmentType; // Type of appointment (e.g., consultation, follow-up)
        }

        // 4. Class Methods
        public void Reschedule(DateTime newDate) //Method to reschedule the appointment
        {
            appointmentDate = newDate; // Update the appointment date
        }
        public void Cancel() //Method to cancel the appointment
        {
            appointmentType = "Canceled"; // Update the appointment type to indicate cancellation
        }

        public void DisplayBookingDetails() //Method to display booking details
        {
            Console.WriteLine($"Booking ID: {id}");
            Console.WriteLine($"Patient ID: {patientId}");
            Console.WriteLine($"Clinic ID: {clinicId}");
            Console.WriteLine($"Appointment Date: {appointmentDate}");
            Console.WriteLine($"Appointment Type: {appointmentType}");
        }
    }
}

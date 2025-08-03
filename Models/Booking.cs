using HospitalSystemTeamTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeLineHealthCareCenter.Models
{
    public class Booking : IBookingService
    {
        private static int bookingCounter = 0;
        public int BookingId { get; private set; }
        public ClinicSpots Spot { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string AppointmentType { get; set; }

        public static List<Booking> Bookings = new();

        public Booking() // Default constructor
        {
            BookingId = ++bookingCounter;
            Spot = new ClinicSpots();
            DoctorId = 0;
            PatientId = 0;
            AppointmentType = "General";
        }
        public Booking(ClinicSpots spot, int doctorId, int patientId, string appointmentType)
        {
            BookingId = ++bookingCounter;
            Spot = spot;
            DoctorId = doctorId;
            PatientId = patientId;
            AppointmentType = appointmentType;
        }
        // static boject of clinic to call their function 
        public static Clinic CallMethodsFromClinic = new Clinic();

        // Book a new appointment
        public void BookAppointment()
        {

            Console.WriteLine("=== Book a New Appointment ===");

            // 1️⃣ Select department
            new Department("temp").GetAllDepartments();
            int departmentId = UserData.EnterDepartmentId(BranchDepartment.Departments);

            // 2️⃣ Select clinic
            CallMethodsFromClinic.GetClinicByDepartmentId(departmentId);
            int clinicId = UserValidator.IntValidation("Enter Clinic ID");
            var clinic = Clinic.Clinics.FirstOrDefault(c => c.ClinicId == clinicId);

            if (clinic == null)
            {
                Console.WriteLine("Clinic not found.");
                return;
            }

            // 3️⃣ Show available spots
            var availableSpots = clinic.ClinicSpots.Where(s => !s.IsBooked).ToList();

            if (availableSpots.Count == 0)
            {
                Console.WriteLine(" No available spots for this clinic.");
                return;
            }

            Console.WriteLine("Available Spots:");
            foreach (var spot in availableSpots)
                Console.WriteLine($"{spot.Date_Time:yyyy-MM-dd HH:mm}");

            DateTime selectedDate = UserValidator.DateTimeValidation("Enter Spot Date and Time (yyyy-MM-dd HH:mm)");
            var chosenSpot = availableSpots.FirstOrDefault(s => s.Date_Time == selectedDate);

            if (chosenSpot == null)
            {
                Console.WriteLine("❌ Selected spot is not available.");
                return;
            }

            // 4️⃣ Get doctor
            CallMethodsFromClinic.GetAllDoctorsByClinicId(clinicId);
            int doctorId = UserValidator.IntValidation("Enter Doctor ID");

            // 5️⃣ Create booking
            chosenSpot.IsBooked = true;
            chosenSpot.PatientID = AuthServices.currentPatient?.UserId;
            chosenSpot.PatientName = AuthServices.currentPatient?.UserName;

            var newBooking = new Booking(chosenSpot, doctorId, chosenSpot.PatientID ?? 0, "Consultation");
            Bookings.Add(newBooking);

            Console.WriteLine($"Booking created successfully! Booking ID: {newBooking.BookingId}");
        }

        // Cancel Appointment
        public void CancelAppointment()
        {
            int bookingId = UserValidator.IntValidation("Enter Booking ID to cancel");
            var booking = Bookings.FirstOrDefault(b => b.BookingId == bookingId);

            if (booking == null)
            {
                Console.WriteLine("❌ Booking not found.");
                return;
            }

            // Free the spot
            booking.Spot.IsBooked = false;
            booking.Spot.PatientID = null;
            booking.Spot.PatientName = string.Empty;

            booking.AppointmentType = "Canceled";

            Console.WriteLine("Booking canceled successfully.");
        }

        // View all bookings by Ductor ID
        public void GetBookingsById(int id)
        {
            // ✅ Step 1: Determine if the ID belongs to a doctor or a patient
            bool isDoctor = Doctor.doctors.Any(d => d.UserId == id);
            bool isPatient = Patient.patients.Any(p => p.UserId == id);

            if (!isDoctor && !isPatient)
            {
                Console.WriteLine("❌ The entered ID does not match any Doctor or Patient in the system.");
                return;
            }

            // ✅ Step 2: Get all bookings related to this ID
            var bookings = Bookings.Where(b => (isDoctor && b.DoctorId == id) || (isPatient && b.PatientId == id)).ToList();

            if (bookings.Count == 0)
            {
                Console.WriteLine($"❌ No bookings found for this {(isDoctor ? "Doctor" : "Patient")} ID: {id}");
                return;
            }

            // ✅ Step 3: Display the bookings
            Console.WriteLine($"📅 Bookings for {(isDoctor ? "Doctor" : "Patient")} ID {id}:");
            foreach (var booking in bookings)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"Booking ID: {booking.BookingId}");
                Console.WriteLine($"Spot Date & Time: {booking.Spot.Date_Time}");
                Console.WriteLine($"Doctor ID: {booking.DoctorId}");
                Console.WriteLine($"Patient ID: {booking.PatientId}");
                Console.WriteLine($"Appointment Type: {booking.AppointmentType}");
                Console.WriteLine("-------------------------------------------");
            }
        }

    }
}

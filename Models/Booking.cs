using System;
using System.Collections.Generic;
using System.Linq;
using HospitalSystemTeamTask.Services;

namespace CodeLineHealthCareCenter.Models
{
    public class Booking : IBookingService
    {
        // =============================== 1. Fields ===============================
        private static int bookingCounter = 0; // Counter to generate unique booking IDs

        // =============================== 2. Properties ===========================
        public int BookingId { get; private set; } // Unique identifier for the booking
        public DateTime BookingDateTime { get; set; } // Date and time of the appointment
        public int ClinicId { get; set; } // ID of the clinic for the appointment
        public int DoctorId { get; set; } // ID of the doctor for the appointment
        public int PatientId { get; set; } // ID of the patient booking the appointment
        public string AppointmentType { get; set; } // Type of appointment (consultation, follow-up, etc.)

        // =============================== 3. Static List ==========================
        public static List<Booking> Bookings = new List<Booking>(); // Stores all bookings in the system

        // =============================== 4. Constructor ==========================
        public Booking()
        {
            bookingCounter++;
            BookingId = bookingCounter;
        }

        public Booking(DateTime bookingDateTime, int clinicId, int doctorId, int patientId, string appointmentType)
            : this()
        {
            BookingDateTime = bookingDateTime;
            ClinicId = clinicId;
            DoctorId = doctorId;
            PatientId = patientId;
            AppointmentType = appointmentType;
        }

        // =============================== 5. Methods ==============================
        /// <summary>
        ///   Interface methods for booking management
        /// </summary>
        // 5.1 Book a new appointment
        public void BookAppointment()
        {
            Console.WriteLine("=== Book a New Appointment ===");

            // Step 1: Select department
            Department.GetAllDepartments();
            int departmentId = UserValidator.IntValidation("Enter Department ID");

            // Step 2: Select clinic in department
            GetAllClinicsByDepartmentId(departmentId);
            int clinicId = UserValidator.IntValidation("Enter Clinic ID");

            // Step 3: Select doctor in clinic
            GetAllDoctorsByClinicId(clinicId);
            int doctorId = UserValidator.IntValidation("Enter Doctor ID");

            // Step 4: Select service in clinic
            GetAllServicesByClinicId(clinicId);
            int serviceId = UserValidator.IntValidation("Enter Service ID");

            // Step 5: Select available appointment spot
            GetAllSpotsByClinicId(clinicId, departmentId);
            DateTime spotDateTime = UserValidator.DateTimeValidation("Enter Spot Date and Time (yyyy-MM-dd HH:mm)");

            // Step 6: Create booking
            Booking newBooking = new Booking(spotDateTime, clinicId, doctorId, serviceId, "Consultation");
            Bookings.Add(newBooking);

            Console.WriteLine($"Booking created successfully! Booking ID: {newBooking.BookingId}");
        }
        // 5.2 Cancel an existing booking
        public void CancelAppointment()
        {
            int bookingId = UserValidator.IntValidation("Enter Booking ID to cancel");
            var booking = Bookings.FirstOrDefault(b => b.BookingId == bookingId);

            if (booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            booking.AppointmentType = "Canceled";
            Console.WriteLine("Booking canceled successfully.");
        }
        // 5.3 Delete a booking completely
        public void DeleteAppointment()
        {
            int bookingId = UserValidator.IntValidation("Enter Booking ID to delete");
            var booking = Bookings.FirstOrDefault(b => b.BookingId == bookingId);

            if (booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            Bookings.Remove(booking);
            Console.WriteLine("Booking deleted successfully.");
        }
        // 5.4 Update booked appointment date/time
        public void UpdateBookedAppointment()
        {
            int bookingId = UserValidator.IntValidation("Enter Booking ID to update");
            var booking = Bookings.FirstOrDefault(b => b.BookingId == bookingId);

            if (booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            DateTime newDate = UserValidator.DateTimeValidation("Enter new appointment date and time");
            booking.BookingDateTime = newDate;

            Console.WriteLine("Booking updated successfully.");
        }
        // 5.5 Get all bookings
        public void GetAllBooking()
        {
            if (Bookings.Count == 0)
            {
                Console.WriteLine("No bookings available.");
                return;
            }

            foreach (var booking in Bookings)
            {
                DisplayBookingDetails(booking);
            }
        }
        // 5.6 Get booking by ID
        public void GetBookingById(int id)
        {
            var booking = Bookings.FirstOrDefault(b => b.BookingId == id);

            if (booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            DisplayBookingDetails(booking);
        }

        // 5.7 Get bookings by clinic ID and date
        public void GetBookingByClinicIdAndDate(int clinicId)
        {
            DateTime date = UserValidator.DateTimeValidation("Enter date to filter bookings");
            var filtered = Bookings.Where(b => b.ClinicId == clinicId && b.BookingDateTime.Date == date.Date).ToList();

            if (filtered.Count == 0)
            {
                Console.WriteLine("No bookings found for the given clinic and date.");
                return;
            }

            foreach (var booking in filtered)
            {
                DisplayBookingDetails(booking);
            }
        }
        // 5.8 Get bookings by patient ID
        public void GetBookingByPatientId(int patientId)
        {
            var patientBookings = Bookings.Where(b => b.PatientId == patientId).ToList();

            if (patientBookings.Count == 0)
            {
                Console.WriteLine("No bookings found for this patient.");
                return;
            }

            foreach (var booking in patientBookings)
            {
                DisplayBookingDetails(booking);
            }
        }
        // 5.9 Get available appointments by clinic and date
        public void GetAvailableAppointmentsByClinicIdAndDate(DateTime date, int clinicId)
        {
            var availableSpots = BranchDepartment.Departments
                .SelectMany(d => d.Clinics)
                .Where(c => c.ClinicId == clinicId)
                .SelectMany(c => c.ClinicSpots)
                .Where(s => s.Date == date.Date)
                .ToList();

            if (availableSpots.Count == 0)
            {
                Console.WriteLine("No available spots for this clinic on the selected date.");
                return;
            }

            Console.WriteLine("Available Spots:");
            foreach (var spot in availableSpots)
            {
                Console.WriteLine(spot);
            }
        }














    }
}

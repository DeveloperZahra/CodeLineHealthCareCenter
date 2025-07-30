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
            // // Find all departments in all relationships (BranchDepartment)
            var availableSpots = BranchDepartment.branchDepartments
                .SelectMany(bd => bd.Departments) // access to department
                .SelectMany(dep => dep.Clinics)   // accessto clinic in departmrnt
                .Where(clinic => clinic.ClinicId == clinicId) // select rquest clinic
                .SelectMany(clinic => clinic.ClinicSpots) // get all available spots in the clinic
                .Where(spot => spot.Date == date.Date) // filter by selected date
                .ToList();

            // Check if there are any available spots
            if (availableSpots.Count == 0)
            {
                Console.WriteLine("No available spots for this clinic on the selected date.");
                return;
            }

            //  Display available spots
            Console.WriteLine("Available Spots:");
            foreach (var spot in availableSpots)
            {
                Console.WriteLine(spot);
            }
        }


        // 5.10 Schedule a new appointment
        public void ScheduleAppointment(int patientId, int clinicId, DateTime date, TimeSpan time)
        {
            Booking newBooking = new Booking(date.Date + time, clinicId, 0, patientId, "Scheduled");
            Bookings.Add(newBooking);

            Console.WriteLine($"New appointment scheduled successfully. Booking ID: {newBooking.BookingId}");
        }

        // ========================== Helper Methods ==========================

        // Display details of a booking
        private void DisplayBookingDetails(Booking booking)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Booking ID: {booking.BookingId}");
            Console.WriteLine($"Patient ID: {booking.PatientId}");
            Console.WriteLine($"Clinic ID: {booking.ClinicId}");
            Console.WriteLine($"Doctor ID: {booking.DoctorId}");
            Console.WriteLine($"Date & Time: {booking.BookingDateTime}");
            Console.WriteLine($"Type: {booking.AppointmentType}");
            Console.WriteLine("----------------------------------");
        }

        // List clinics by department
        public static void GetAllClinicsByDepartmentId(int departmentId)
        {
            // Step 1: Get all departments from all branch-department relationships
            //         and filter only the department that matches the given departmentId.
            var clinics = BranchDepartment.branchDepartments
                .SelectMany(bd => bd.Departments) // Access the list of departments inside each branch-department
                .Where(dep => dep.DepartmentId == departmentId) // Filter by departmentId
                .SelectMany(dep => dep.Clinics) // Get all clinics inside the selected department
                .ToList();

            // Step 2: If no clinics are found, display a message and return.
            if (clinics.Count == 0)
            {
                Console.WriteLine("No clinics found for this department.");
                return;
            }

            // Step 3: Print all clinics' details (ID and Name).
            Console.WriteLine($"Clinics in Department ID {departmentId}:");
            foreach (var clinic in clinics)
            {
                Console.WriteLine($"Clinic ID: {clinic.ClinicId}, Name: {clinic.ClinicName}");
            }
        }

        // List doctors by clinic
        public static void GetAllDoctorsByClinicId(int clinicId)
        {
            // Step 1: Get all departments from all branch-department relationships
            //         Then access their clinics to find the clinic with the given ID.
            var doctors = BranchDepartment.branchDepartments
                .SelectMany(bd => bd.Departments)         // Access departments
                .SelectMany(dep => dep.Clinics)          // Access clinics inside each department
                .Where(clinic => clinic.ClinicId == clinicId) // Filter by clinicId
                .SelectMany(clinic => clinic.Doctors)    // Get all doctors inside the selected clinic
                .ToList();

            // Step 2: If no doctors found, display a message and return
            if (doctors.Count == 0)
            {
                Console.WriteLine("No doctors found for this clinic.");
                return;
            }

            // Step 3: Display all doctors' details
            Console.WriteLine($"Doctors in Clinic ID {clinicId}:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"Doctor ID: {doctor.UserId}, Name: {doctor.UserName}, Specialization: {doctor.Specialty}");
            }
        }

        // List services by clinic
        public static void GetAllServicesByClinicId(int clinicId)
        {
            // Fetch all services that belong to the given clinic
            var services = Service.Services.Where(s => s.ClinicId == clinicId).ToList();

            // Check if there are any services for this clinic
            if (services.Count == 0)
            {
                Console.WriteLine("No services found for this clinic.");
                return;
            }

            // Print all services
            Console.WriteLine($"Services available for Clinic ID {clinicId}:");
            foreach (var service in services)
            {
                Console.WriteLine($"Service ID: {service.ServiceId}, Name: {service.ServiceName}, Price: {service.Price}");
            }
        }


        // List available appointment spots by clinic
        public static void GetAllSpotsByClinicId(int clinicId, int departmentId)
        {
            //  Find the department by departmentId
            var department = BranchDepartment.branchDepartments
                .FirstOrDefault(d => d.departmentId == departmentId);

            //  Validate that department exists
            if (department == null)
            {
                Console.WriteLine("Department not found.");
                return;
            }

            // Find the clinic inside the found department
            var clinic = department.Clinics.FirstOrDefault(c => c.ClinicId == clinicId);

            // Validate that clinic exists and has available spots
            if (clinic == null)
            {
                Console.WriteLine("Clinic not found in this department.");
                return;
            }

            if (clinic.ClinicSpots == null || clinic.ClinicSpots.Count == 0)
            {
                Console.WriteLine("No available spots for this clinic.");
                return;
            }

            //  Print all available spots
            Console.WriteLine($"Available spots for Clinic ID {clinicId}:");
            foreach (var spot in clinic.ClinicSpots)
            {
                Console.WriteLine($"- {spot}");
            }
        }














    }
}

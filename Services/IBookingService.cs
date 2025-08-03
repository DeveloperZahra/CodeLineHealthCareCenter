//using HospitalSystemTeamTask.DTO_s;
using CodeLineHealthCareCenter;
using HospitalSystemTeamTask.Services;

namespace HospitalSystemTeamTask.Services
{
    public interface IBookingService
    {
        void BookAppointment();
        void CancelAppointment();
        //void DeleteAppointment();
        //void UpdateBookedAppointment();
        //void GetAllBooking();
        //void GetBookingById(int id);
        //void GetBookingByClinicIdAndDate(int patientId);
        //void GetBookingByPatientId(int patientId);
        //void GetAvailableAppointmentsByClinicIdAndDate(DateTime date, int clinicId);
        //void ScheduleAppointment(int patientId, int clinicId, DateTime date, TimeSpan time);
    }
}
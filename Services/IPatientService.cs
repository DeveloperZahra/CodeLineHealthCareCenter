using CodeLineHealthCareCenter.Models;
//using HospitalSystemTeamTask.DTO_s;
using HospitalSystemTeamTask.Services;

namespace HospitalSystemTeamTask.Services
{
    public interface IPatientService
    {
        void AddPatient(string name, DateTime DateOFBirthday, string email, string password, string nationalId, string phoneNumber, string gender, string city);

        //void GetAllPatients();
        //void GetPatientById(int Pid);
        //void UpdatePatientDetails(int UID, string phoneNumber);
        //void AddPatient();
        //void GetPatientByName(string PatientName);
        //void GetPatientData(string? userName, int? Pid);

    }
}
using CodeLineHealthCareCenter.Models;
//using HospitalSystemTeamTask.DTO_s;
using HospitalSystemTeamTask.Services;

namespace HospitalSystemTeamTask.Services
{
    public interface IDoctorService
    {
        void AddDoctor(string name, string email, string password, string nationalId, string phoneNumber, string gender, string specialization, int branchId, int departmentId);
        //void GetAllDoctors();
        //void GetDoctorByBrancDep(int branchId, int departmentId);
        //void GetDoctorByEmail(string email);
        //void GetDoctorById(int uid);
        //void GetDoctorByName(string docName);
        //void GetDoctorData(int Did);
        //void GetDoctorsByBranchName(string branchName);
        //void GetDoctorsByDepartmentName(string departmentName);
        //void UpdateDoctor(int DocId);
        //void UpdateDoctorDetails(int DoctId);
        //void GetDoctorDetailsById(int Docid);

    }
}
//using HospitalSystemTeamTask.DTO_s;
using HospitalSystemTeamTask.Services;
using CodeLineHealthCareCenter.Models;



namespace HospitalSystemTeamTask.Services
{
    public interface IClinicService
    {
        void AddClinic(string clinicName, string location, int departmentId, int branchId, int floorId, int roomId, decimal price);
        void GetClinicsByBranchAndDepartment();
        void GetClinic(int clinicId);
        void GetClinic(string clinicName);
        void GetClinicName(int clinicId);
        void GetClinicByBranchName(string branchName);
        void GetClinicByDepartmentId(int departmentId);
        void GetPrice(int clinicId);
        void SetClinicStatus(int clinicId, bool isActive);
        void UpdateClinicDetails(int clinicId, string clinicName, string location, decimal price);
        void DeleteClinic(int clinicId);
    }
}
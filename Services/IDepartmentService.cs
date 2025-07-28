//using HospitalSystemTeamTask.DTO_s;
//using HospitalSystemTeamTask.Models;
using HospitalSystemTeamTask.Services;

namespace HospitalSystemTeamTask.Services
{
    public interface IDepartmentService
    {
        void CreateDepartment(int branchId); // Creates a new department for a specific branch.
        void GetAllDepartments(); // Displays all departments
        void UpdateDepartment(int branchId, int departmentId); //Updates a department's details using branchId and departmentId.
        void SetDepartmentActiveStatus(int departmentId, bool isActive);
        void GetDepartmentByName(string department);
        void GetDepartmentByid(int did);
        string GetDepartmentName(int depId);


    }
}

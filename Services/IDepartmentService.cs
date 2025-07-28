//using HospitalSystemTeamTask.DTO_s;
//using HospitalSystemTeamTask.Models;
using HospitalSystemTeamTask.Services;

namespace HospitalSystemTeamTask.Services
{
    public interface IDepartmentService
    {
        void CreateDepartment(int branchId); // Creates a new department for a specific branch.
        void GetAllDepartments(); // Displays all departments
      

    }
}

using CodeLineHealthCareCenter;
using HospitalSystemTeamTask.DTO_s;
using HospitalSystemTeamTask.Models;

namespace HospitalSystemTeamTask.Services
{
    public interface IBranchDepartmentService
    {
        void AddDepartmentToBranch(int branchID); // Adds a new department to a specific branch.
        void GetDepartmentsByBranch(int branchID); // Displays all departments that belong to a specific branch.

        void GetBranchsByDepartment(int departmentId); // Displays all branches that contain a specific department.
        void UpdateBranchDepartment(int branchId, int departmentId, string newDepartmentName); // Updates the details of a branch-department relationship.
        void GetBranchDep(int departmentId, int branchId); // Displays details of a specific branch-department relationship.
    }
}
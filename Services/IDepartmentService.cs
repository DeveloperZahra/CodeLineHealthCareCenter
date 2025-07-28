//using HospitalSystemTeamTask.DTO_s;
//using HospitalSystemTeamTask.Models;
using CodeLineHealthCareCenter;
using HospitalSystemTeamTask.Services;
using System;
using System.Xml.Linq;

namespace HospitalSystemTeamTask.Services
{
    public interface IDepartmentService
    {
        void CreateDepartment(int branchId); // Creates a new department for a specific branch.
        void GetAllDepartments(); // Displays all departments
        void UpdateDepartment(int branchId, int departmentId); //Updates a department's details using branchId and departmentId.
        void SetDepartmentActiveStatus(int departmentId, bool isActive); //Sets the active status(open/closed) for a department.
        void GetDepartmentByName(string department); //Finds and displays a department by its name.
        void GetDepartmentByid(int did); //Finds and displays a department by its ID.
        string GetDepartmentName(int depId);


    }
}

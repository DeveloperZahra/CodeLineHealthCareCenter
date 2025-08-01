using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HospitalSystemTeamTask.Services;
using CodeLineHealthCareCenter.Models;



namespace CodeLineHealthCareCenter.Services

{
    public interface IAdminServices
    {
        void AddAdmin(string name, string email, string password, string nationalId, string phoneNumber,string gender, int branchId, int departmentId);
        void RemoveAdmin(int adminId); // Removes an admin by their ID
        void UpdateAdmin(int adminId); // Updates an admin's details by their ID
        void ViewAdmin(int adminId); // Views details of a specific admin by their ID
        void ViewAllAdmins(); // Views all admins in the system
        void ViewAdminsByBranch(int branchId); //   Views all admins in a specific branch
        void ViewAdminsByDepartment(int departmentId); //   Views all admins in a specific department




    }
}

using CodeLineHealthCareCenter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace CodeLineHealthCareCenter.Models
{
    // The Admin class inherits from the base User class.
    // Represents a user with administrative privileges over a specific department and branch.
    public class Admin : User, IAdminServices
    {
        // 1. ================================== Class feilds ===========================
        
        public int BranchId { get; set; } // The branch this admin is assigned to 
        public int DepartmentId { get; set; }  // The department this admin manages
        // 2. ============================== Admin List =================================
        public static List<Admin> Admins = new List<Admin>();
        // ================================= Class Constructor ==========================
        public Admin(string name, string email, string password, string nationalId, string phoneNumber,string gender, int branchId, int departmentId)
        {
            UserCount++;
            UserId = "A" + UserCount;
            UserName = name ;
            Email = email ;
            Password = password ;
            NationalID = nationalId ;
            PhoneNumber = phoneNumber ;
            Gender = gender ;
            Role = "Admin";
            BranchId = branchId ;
            DepartmentId = departmentId ;
            IsActive = true ;
        }
        //==================================================== Admins Methods =======================================================

       

    }
}

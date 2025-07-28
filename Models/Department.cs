using HospitalSystemTeamTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    class Department : IDepartmentService
    {
        //1. ======================================= Class Fields and attributes with properties =========================
        public int DepartmentId { get; set;}
        public string DepartmentName {  get; set;}
        public int BranchId {  get; set;}
        public static int DepartmentCount = 0;


        //2. Class Lists 
        private List<Department> departments = new List<Department>();


        //3. ======================================== Class Constructor ========================================
        public Department(string name, int branchId)
        {
            DepartmentCount++;
            DepartmentId = DepartmentCount;
            DepartmentName = name;
            BranchId = branchId;
        }
        //4. ========================================== Class Methods ================================
        
    }
}

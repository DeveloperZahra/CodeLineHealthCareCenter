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
        //1. ======================================= Class Fields and attributes=========================
        public int DepartmentId;
        public string DepartmentName;
        public int BranchId;
        public static int DepartmentCount = 0;

        //2. Class Lists 
        private List<Department> departments = new List<Department>();


        //2. ======================================== Class Constructor ========================================

        //3. ========================================== Class Methods ================================

    }
}

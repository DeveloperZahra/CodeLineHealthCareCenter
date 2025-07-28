using CodeLineHealthCareCenter.Models;
using HospitalSystemTeamTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    // Class BranchDepartment which represents the relationship between a branch and a department
    class BranchDepartment : IBranchDepartmentService
    {
        //1. ========================== class fields and their properities ==========================
        public int branchId { get; set; }
        public int departmentId {  get; set; }
        public bool isActive { get; set; }

        //2. =======================Storage the relationship ====================
        private List<BranchDepartment> branchDepartments = new List<BranchDepartment>();


        //2. class method ...

    }
}

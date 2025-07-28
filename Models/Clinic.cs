using CodeLineHealthCareCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    class Clinic
    {
        // 1. Class Fields
        public int id; // Unique identifier for the clinic
        public string name; // Name of the clinic
        public int departmentId; // ID of the department the clinic 
        public int branchId; // ID of the branch the clinic is located in

        public List<Doctor> doctors; // List of doctors assigned to the clinic

        // 2. Class Properties
        public int Id // Unique identifier for the clinic
        {
            get { return id; }
            set { id = value; }
        }
        public string Name // Name of the clinic
        {
            get { return name; }
            set { name = value; }
        }
        public int DepartmentId // ID of the department the clinic belongs to
        {
            get { return departmentId; }
            set { departmentId = value; }
        }
        public int BranchId // ID of the branch the clinic is located in
        {
            get { return branchId; }
            set { branchId = value; }
        }
        public List<Doctor> Doctors // List of doctors assigned to the clinic
        {
            get { return doctors; }
            set { doctors = value; }
        }

    }
}

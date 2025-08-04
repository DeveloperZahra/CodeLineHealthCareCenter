using CodeLineHealthCareCenter.Models;
using CodeLineHealthCareCenter.Utilities;
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
        public int branchDepartmentId { get; set; } // Unique identifier for the branch-department relationship
        public int FloorId { get; set; } // to track which floor the department is on in the branch
        public bool isActive { get; set; }
        public string branchName {  get; set; }
        private string departmentName {  get; set; }


        //2. =======================Storage the relationship =================================
        // Existing fields...
        public static List<BranchDepartment> branchDepartments = new List<BranchDepartment>();
        public List<Clinic> Clinics { get; set; } = new List<Clinic>();


        // Add a list of departments under this branch
        public static List<Department> Departments { get; set; } = new List<Department>();
        //3. ======================= Class constructor =========================================
        public BranchDepartment(int branchDepartmentId, int branchId, int departmentId,int FloorId, string branchName, string departmentName, bool isActive = true)
        {
            this.branchDepartmentId = branchDepartmentId; // Unique ID for the relationship
            this.branchId = branchId;
            this.departmentId = departmentId;
            this.FloorId = FloorId; //if you want to track the floor
            this.branchName = branchName;
            this.departmentName = departmentName;
            this.isActive = isActive;
        }
        //4. ======================= Class method ============================================
        /// Implement all methods in IBranchDepartmentService interface 
        //4.1 Adds a new department to a specific branch.
        public void AddDepartmentToBranch(int branchID)
        {
            Console.WriteLine("Enter Branch Department ID: ");
            int branchDepartmentId = int.Parse(Console.ReadLine());
            Console.Write("Enter Department ID: ");
            int departmentId = int.Parse(Console.ReadLine());
            Console.Write("Enter Floor ID: ");
            int FloorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the branch Name");
            string branchName = Console.ReadLine();
            Console.WriteLine("Enter the department name");
            string departmentName = Console.ReadLine();
            BranchDepartment newRelation = new BranchDepartment(branchDepartmentId,branchID, departmentId, FloorId, departmentName,branchName,true);
            branchDepartments.Add(newRelation);


            Console.WriteLine($" Department {departmentId} added to Branch {branchID}.");
        }

        //4.2 Displays all departments that belong to a specific branch.
        public void GetDepartmentsByBranch(int branchID)
        {
            var departments = branchDepartments.Where(bd => bd.branchId == branchID).ToList();

            if (departments.Count == 0)
            {
                Console.WriteLine("No departments found for this branch.");
                return;
            }

            Console.WriteLine($"Departments in Branch {branchID}:");
            foreach (var dep in departments)
            {
                Console.WriteLine($"Department ID: {dep.departmentId}, Status: {(dep.isActive ? "Active" : "Inactive")}");
            }
        }

        //4.3 Displays all branches that contain a specific department.
        public void GetBranchsByDepartment(int departmentId)
        {
            var branches = branchDepartments.Where(bd => bd.departmentId == departmentId).ToList();

            if (branches.Count == 0)
            {
                Console.WriteLine("No branches found for this department.");
                return;
            }

            Console.WriteLine($"Branches containing Department {departmentId}:");
            foreach (var br in branches)
            {
                Console.WriteLine($"➡ Branch ID: {br.branchId}, Status: {(br.isActive ? "Active" : "Inactive")}");
            }
        }

        // 4.4 Updates the department name in a specific branch-department relation.
        public void UpdateBranchDepartment(int branchId, int departmentId, string newDepartmentName)
        {
            BranchDepartment relation = branchDepartments.FirstOrDefault(bd => bd.branchId == branchId && bd.departmentId == departmentId);

            if (relation != null)
            {
                // update the name of department in the specific class 
                relation.departmentName = newDepartmentName;

                Console.WriteLine($"Department ID {departmentId} in Branch {branchId} updated to new name '{newDepartmentName}'.");
            
            }
            else
            {
                Console.WriteLine("Branch-Department relation not found.");
            }
        }

        // 4.5 Displays details of a specific branch-department relation.
        public void GetBranchDep(int departmentId, int branchId)
        {
            BranchDepartment relation = branchDepartments
                .FirstOrDefault(bd => bd.departmentId == departmentId && bd.branchId == branchId);

            if (relation != null)
            {
                Console.WriteLine($"Found: Branch {branchId}, Department {departmentId}, Status: {(relation.isActive ? "Active" : "Inactive")}");
            }
            else
            {
                Console.WriteLine("Relation not found.");
            }
        }
        // 4.6 Displays all departments in a branch by branch name.
        public void GetDepartmentsByBranchName(string branchName)
        {
            // Find all relations where the branch name matches (case-insensitive)
            var departments = branchDepartments
                .Where(bd => bd.branchName.Equals(branchName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // If no departments are found, show a warning message
            if (departments.Count == 0)
            {
                Console.WriteLine($" No departments found for branch '{branchName}'.");
                return;
            }

            //  Display all departments for the branch
            Console.WriteLine($"Departments in Branch '{branchName}':");
            foreach (var dep in departments)
            {
                Console.WriteLine($"Department ID: {dep.departmentId}, Name: {dep.departmentName}, Status: {(dep.isActive ? "Active" : "Inactive")}");
            }
        }

        // 4.7 Changes the active status of a specific branch-department relation.

        public void SetBranchDepartmentActiveStatus(int branchId, int departmentId, bool isActive)
        {
            BranchDepartment relation = branchDepartments.FirstOrDefault(bd => bd.branchId == branchId && bd.departmentId == departmentId);
            if (relation != null)
            {
                relation.isActive = isActive; // Update the active status
                Console.WriteLine($"Branch-Department relation updated: Branch {branchId}, Department {departmentId} is now {(isActive ? "Active" : "Inactive")}.");
            }
            else
            {
                Console.WriteLine("Branch-Department relation not found.");
            }

        }

        // 4.8 assigns a department to a specific a branch.
        public void AssignDepartmentsToBranch(int branchId)
        {
            // Check if branch exists
            Branch branch = Branch.branches.FirstOrDefault(b => b.BranchId == branchId);
            if (branch == null)
            {
                Console.WriteLine(" Branch not found.");
                return;
            }

            Console.WriteLine($"\nAssigning Departments to Branch: {branch.BranchName} (ID: {branch.BranchId})");

            bool addMore = true;

            while (addMore)
            {
                // Display all departments that are NOT yet assigned to this branch
                var alreadyAssignedIds = branchDepartments
                    .Where(bd => bd.branchId == branchId)
                    .Select(bd => bd.departmentId)
                    .ToList();

                var availableDepartments = Departments
                    .Where(d => !alreadyAssignedIds.Contains(d.DepartmentId))
                    .ToList();

                if (availableDepartments.Count == 0)
                {
                    Console.WriteLine("There is no department to assign.");
                    break;
                }

                Console.WriteLine("\n=== Available Departments ===");
                foreach (var dept in availableDepartments)
                {
                    Console.WriteLine($"ID: {dept.DepartmentId} | Name: {dept.DepartmentName}");
                }

                Console.Write("\nEnter Department ID to assign: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int deptId))
                {
                    Department dept = Departments.FirstOrDefault(d => d.DepartmentId == deptId);
                    if (dept == null)
                    {
                        Console.WriteLine(" Invalid Department ID.");
                    }
                    else
                    {
                        //  Create new BranchDepartment relationship
                        int newId = branchDepartments.Count + 1;
                        BranchDepartment newRelation = new BranchDepartment(
                            newId,
                            branchId,
                            deptId,
                            FloorId: 0, // You can ask user for floor input if needed
                            branchName: branch.BranchName,
                            departmentName: dept.DepartmentName,
                            isActive: true
                        );

                        branchDepartments.Add(newRelation);
                        Console.WriteLine($" Department '{dept.DepartmentName}' assigned to Branch '{branch.BranchName}'.");
                    }
                }
                else
                {
                    Console.WriteLine(" Invalid input. Please enter a valid number.");
                }

                // Ask if user wants to add another department
                Console.Write("\nDo you want to add another department? (yes/no): ");
                string choice = Console.ReadLine().Trim().ToLower();

                if (choice != "yes")
                    addMore = false;
            }

            Console.WriteLine("\n Department assignment process completed.");
        }

        // 4.9 
        //public  void AssignUserToBranchAndDepartment()
        //{
        //    Console.WriteLine("\n=== Assign Admin or Doctor to Specific Branch & Department ===");

        //    // ✅ 1. Display all branches
        //    if (Branch.branches.Count == 0)
        //    {
        //        Console.WriteLine("❌ No branches available.");
        //        return;
        //    }

        //    Console.WriteLine("\nAvailable Branches:");
        //    foreach (var branch in Branch.branches)
        //        Console.WriteLine($"ID: {branch.BranchId} | Name: {branch.BranchName}");

        //    // ✅ 2. Ask for Branch ID
        //    int branchId = UserData.EnterBranchId(Branch.branches);
        //    if (branchId == -1)
        //    {
        //        Console.WriteLine("❌ Invalid Branch ID.");
        //        return;
        //    }

        //    // ✅ 3. Display all departments in that branch
        //    var branchDepartments = BranchDepartment.branchDepartments
        //        .Where(bd => bd.branchId == branchId)
        //        .Select(bd => bd.departmentId)
        //        .ToList();

        //    if (branchDepartments.Count == 0)
        //    {
        //        Console.WriteLine("❌ No departments found for this branch.");
        //        return;
        //    }

        //    Console.WriteLine("\nDepartments in this Branch:");
        //    foreach (var deptId in branchDepartments)
        //    {
        //        var dept = BranchDepartment.Departments.FirstOrDefault(d => d.DepartmentId == deptId);
        //        if (dept != null)
        //            Console.WriteLine($"ID: {dept.DepartmentId} | Name: {dept.DepartmentName}");
        //    }

        //    // ✅ 4. Ask for Department ID
        //    int departmentId = UserData.EnterDepartmentId(BranchDepartment.Departments, branchId);
        //    if (departmentId == -1)
        //    {
        //        Console.WriteLine("❌ Invalid Department ID.");
        //        return;
        //    }

        //    // ✅ 5. Ask for user role
        //    Console.WriteLine("\nAssign which type of user?");
        //    Console.WriteLine("1. Doctor");
        //    Console.WriteLine("2. Admin");
        //    Console.Write("Choose (1 or 2): ");
        //    string choice = Console.ReadLine();

        //    if (choice == "1")
        //    {
        //        AssignDoctorToDepartment(branchId, departmentId);
        //    }
        //    else if (choice == "2")
        //    {
        //        AssignAdminToDepartment(branchId, departmentId);
        //    }
        //    else
        //    {
        //        Console.WriteLine("❌ Invalid choice.");
        //    }
        //}

        //private void AssignDoctorToDepartment(int branchId, int departmentId)
        //{
        //    if (Doctor.doctors.Count == 0)
        //    {
        //        Console.WriteLine("❌ No doctors available.");
        //        return;
        //    }

        //    Console.WriteLine("\nAvailable Doctors:");
        //    foreach (var doc in Doctor.doctors)
        //        Console.WriteLine($"ID: {doc.UserId} | Name: {doc.UserName} | Specialty: {doc.Specialty}");

        //    int doctorId = UserValidator.IntValidation("Enter Doctor ID");
        //    var doctor = Doctor.doctors.FirstOrDefault(d => d.UserId == doctorId);

        //    if (doctor == null)
        //    {
        //        Console.WriteLine("❌ Doctor not found.");
        //        return;
        //    }

        //    doctor.BranchId = branchId;
        //    doctor.DepartmentId = departmentId;

        //    Console.WriteLine($"✅ Doctor {doctor.UserName} assigned to Branch {branchId}, Department {departmentId}");
        //}

        //private void AssignAdminToDepartment(int branchId, int departmentId)
        //{
        //    if (Admin.Admins.Count == 0)
        //    {
        //        Console.WriteLine("❌ No admins available.");
        //        return;
        //    }

        //    Console.WriteLine("\nAvailable Admins:");
        //    foreach (var admin in Admin.Admins)
        //        Console.WriteLine($"ID: {admin.UserId} | Name: {admin.UserName} | Email: {admin.Email}");

        //    int adminId = UserValidator.IntValidation("Enter Admin ID");
        //    var adminUser = Admin.Admins.FirstOrDefault(a => a.UserId == adminId);

        //    if (adminUser == null)
        //    {
        //        Console.WriteLine("❌ Admin not found.");
        //        return;
        //    }

        //    adminUser.BranchId = branchId;
        //    adminUser.DepartmentId = departmentId;

        //    Console.WriteLine($"✅ Admin {adminUser.UserName} assigned to Branch {branchId}, Department {departmentId}");
        //}



    }
}

using CodeLineHealthCareCenter.Utilities;
using HospitalSystemTeamTask.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CodeLineHealthCareCenter
{
    // Represents a branch of the hospital, including its details and associated floors.
    public class Branch : IBranchService
    {
        // 1. ============================== Class Field and Property =====================================
        public int BranchId { get; set; }// Unique identifier for the branch. 
        public string BranchName { get; set; }// The name of the branch.
        public string BranchAddress { get; set; } //The address where the branch is located. 
        public string BranchPhoneNumber { get; set; }   // The phone number attribute for every branch 
        public bool BranchStatus { get; set; } // Indicates whether the branch is currently active (true = open, false = closed).
        public DateTime BranchEstablished { get; set; } // The date when the branch was established.
        public static int BranchCount = 0;// Keeps track of the total number of branches created.

        // A list to store all branches (acting as an in-memory database)
        public static List<Branch> branches = new List<Branch>();




        // 2. ===================================Class Constructors===============================
        public Branch() // Default constructor that increments the BranchCount.
        {
            BranchCount++;
            BranchId = BranchCount;
            BranchAddress = "Muscat";
            BranchName = BranchAddress + "CodeLine Health Care";
            BranchPhoneNumber = "Null";
            BranchStatus = false;
            BranchEstablished = DateTime.Now;
        }

        public Branch(string address, string phoneNumber) // Overloaded constructor to initialize branch details.
        {
            BranchId = BranchCount;
            BranchAddress = address;
            BranchName = BranchAddress + "CodeLine Health Care";
            BranchPhoneNumber = phoneNumber;
            BranchStatus = true;
            BranchEstablished = DateTime.Now;
            BranchCount++;
        }

        // 3. ===================================Class methods================================================

        /// implements IBranchService It provides all operations for managing branches
        // 3.1. Adds a new branch to the list.

        public static void AddBranch(string branchAddress, string phoneNumber)
        {
            Branch newBranch = new Branch(branchAddress, phoneNumber); // Create a new branch object
            branches.Add(newBranch); // Add it to the list

            SaveLoadingFile.SaveToFile(branches, SaveLoadingFile.BranchFile); // Save the updated list to a file

            Console.WriteLine($"Branch '{newBranch.BranchName}' added successfully!");
        }

        // 3.2 Displays all branches stored in the list.
        public void GetAllBranches()
        {
            // check if there is branch 
            if (branches.Count == 0)
            {
                Console.WriteLine("No branches found.");
                return;
            }
            // display all branches 
            Console.WriteLine(" List of all branches:");
            foreach (var branch in branches)
            {
                Console.WriteLine($"ID: {branch.BranchId}, Name: {branch.BranchName}, Address: {branch.BranchAddress}, Status: {(branch.BranchStatus ? "Open" : "Closed")}");
            }

        }

        // 3.3 Finds and displays details of a branch by its ID.
        public void GetBranchById(int branchId)
        {
            Branch branch = branches.FirstOrDefault(b => b.BranchId == branchId);
            if (branch != null)
            {
                Console.WriteLine($"Branch Found: ID={branch.BranchId}, Name={branch.BranchName}, Address={branch.BranchAddress}, Status={(branch.BranchStatus ? "Open" : "Closed")}");
            }
            else
            {
                Console.WriteLine("Branch not found.");
            }
        }

        //3.4 Finds and displays details of a branch by name OR ID.
        public void GetBranchDetails(string branchName, int branchId)
        {
            // check if branch object with the input name and branch id id found 
            Branch branch = branches.FirstOrDefault(b =>b.BranchId == branchId || b.BranchName.Equals(branchName, StringComparison.OrdinalIgnoreCase));

            if (branch != null)
            {
                Console.WriteLine($"Branch Details: ID={branch.BranchId}, Name={branch.BranchName}, Address={branch.BranchAddress}, Status={(branch.BranchStatus ? "Open" : "Closed")}");
            }
            else
            {
                Console.WriteLine("Branch not found.");
            }
        }

        // 3.5 Finds and displays details of a branch by its name only.
        public void GetBranchDetailsByBranchName(string branchName)
        {
            Branch branch = branches.FirstOrDefault(b => b.BranchName.Equals(branchName, StringComparison.OrdinalIgnoreCase));
            if (branch != null)
            {
                Console.WriteLine($"Branch Found: ID={branch.BranchId}, Name={branch.BranchName}, Address={branch.BranchAddress}");
            }
            else
            {
                Console.WriteLine("Branch not found.");
            }
        }

        //3.6 Gets and returns the name of a branch using its ID.
        public string GetBranchName(int branchId)
        {
            Branch branch = branches.FirstOrDefault(b => b.BranchId == branchId);
            if (branch != null)
                return branch.BranchName;
            else
                return "❌ Branch not found.";
        }

        //3.7 Changes the status of a branch (open/closed) using its ID.
        public void SetBranchStatus(int branchId, bool isActive)
        {
            Branch branch = branches.FirstOrDefault(b => b.BranchId == branchId);
            if (branch != null)
            {
                branch.BranchStatus = isActive;
                Console.WriteLine($" Branch '{branch.BranchName}' status updated to {(isActive ? "Open" : "Closed")}.");
            }
            else
            {
                Console.WriteLine("Branch not found.");
            }
        }

        // 3.8 Updates the details of a branch by its ID.
        public void UpdateBranch(int branchId)
        {
            Branch branch = branches.FirstOrDefault(b => b.BranchId == branchId);
            if (branch != null)
            {
                bool WantUpdate = false;
                while(WantUpdate == true)
                Console.WriteLine("Which data do you want to update:");
                Console.WriteLine("1. Branch Name");
                Console.WriteLine("2. Branch Address");
                Console.WriteLine("3. Branch Phone Number");
                Console.WriteLine("0. Cancel");

                char UpdateBranchDetail = Console.ReadKey().KeyChar;
                switch (UpdateBranchDetail)
                {
                    case '1':
                        Console.Write("Enter new branch name: ");
                        branch.BranchName = Console.ReadLine();
                        Console.WriteLine($"Branch Name updated successfully to{ branch.BranchName}!");
                        break;
                    case '2':
                        Console.Write("Enter new branch address: ");
                        branch.BranchAddress = Console.ReadLine();
                        Console.WriteLine($"Branch address updated successfully to{branch.BranchAddress}!");

                        break;
                    case '3':
                        Console.WriteLine("Enter new branch phone number:");
                        branch.BranchPhoneNumber = Console.ReadLine();
                        Console.WriteLine($"Branch phone number updated successfully to{branch.BranchPhoneNumber}!");

                        break;
                    case '0':
                        WantUpdate = false;
                        Console.WriteLine("Branch Detail Dose not Update");
                        break;
                }
                
            }
            else
            {
                Console.WriteLine("Branch not found.");
            }
        }











    }



}

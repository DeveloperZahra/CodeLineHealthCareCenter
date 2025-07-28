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
    class Branch : IBranchService
    {
        // 1. ============================== Class Field and Property =====================================
        public int BranchId { get; set; }// Unique identifier for the branch. 
        public string BranchName { get; set; }// The name of the branch.
        public string BranchAddress { get; set; } //The address where the branch is located. 
        public bool BranchStatus { get; set; } // Indicates whether the branch is currently active (true = open, false = closed).
        public DateTime BranchEstablished { get; set; } // The date when the branch was established.
        public static int BranchCount = 0;// Keeps track of the total number of branches created.

        // A list to store all branches (acting as an in-memory database)
        private List<Branch> branches = new List<Branch>();




        // 2. ===================================Class Constructors===============================
        public Branch() // Default constructor that increments the BranchCount.
        {
            BranchCount++;
            BranchId = BranchCount;
            BranchAddress = "Muscat";
            BranchName = BranchAddress + "CodeLine Health Care";
            BranchStatus = false;
            BranchEstablished = DateTime.Now;
        }

        public Branch(string address) // Overloaded constructor to initialize branch details.
        {
            BranchId = BranchCount;
            BranchAddress = address;
            BranchName = BranchAddress + "CodeLine Health Care";
            BranchStatus = true;
            BranchEstablished = DateTime.Now;
            BranchCount++;
        }

        // 3. ===================================Class methods================================================

        /// implements IBranchService It provides all operations for managing branches
        // 3.1. Adds a new branch to the list.

        public void AddBranch(string branchAddress)
        {
            Branch newBranch = new Branch(branchAddress); // Create a new branch object
            branches.Add(newBranch); // Add it to the list
            Console.WriteLine($"Branch '{newBranch.BranchName}' added successfully!");
        }

        // 3.2 Displays all branches stored in the list.
        public void GetAllBranches()
        {
          
        }








    }



}

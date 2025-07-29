using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    public class Floor
    {
        // ==============1. Class Fields ==============

        public int FloorId { get; set; } //Floor ID (e.g., 1, 2, 3)
        public int BranchId { get; set; } // The Branch ID this floor belongs to


        // Shared list to hold all floors in the system // A list to store all Floor (acting as an in-memory database)

        public static List<Floor> Floors = new List<Floor>();



        //===============2. Constructor=============

        // Constructor to create a floor with specified ID and Branch
        public Floor(int floorId, int branchId)
        {

            this.FloorId = floorId;
            this.BranchId = branchId;

        }

        //===============3. Methods===============

        // Method to add a floor after checking if it already exists in the branch
        public static void AddFloor(int floorId, int branchId)
        {
            // Check if floor already exists in this branch
            foreach (var floor in Floors)
            {
                if (floor.FloorId == floorId && floor.BranchId == branchId)
                {
                    Console.WriteLine("❌ This floor ID already exists in this branch.");
                    return;
                }
            }
        

        // If not exists, add the floor
        Floor newFloor = new Floor(floorId, branchId);
        Floors.Add(newFloor);
        Console.WriteLine($" ✅ Floor {newFloor.FloorId} added to Branch {branchId}.");
            
     }

        // Method to get and print all floors in a specific branch
        public void GetAllFloorInBranch (int branchId)
        {
            Console.WriteLine($"\n🏢 Floors in Branch {branchId}:");

            bool found = false;
            foreach (var floor in Floors)
            {
                if (floor.BranchId == branchId)
                {
                    Console.WriteLine($"- Floor ID: {floor.FloorId}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("❌ No floors found for this branch.");
            }
        }


    }
}

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
        
        public int FloorId {  get; set; } //Floor ID (e.g., 1, 2, 3)
        public int BranchId { get; set; } // The Branch ID this floor belongs to


        // Shared list to hold all floors in the system // A list to store all Floor (acting as an in-memory database)

        public List<Floor> Floors = new  List<Floor>();



        //===============2. Constructor=============

        // Constructor to create a floor with specified ID and Branch
        public Floor ( int floorId , int branchId)
        {
            
            this.FloorId = floorId; 
            this.BranchId = branchId;

        }

        //===============3. Methods===============

        // Method to add a floor after checking if it already exists in the branch
        public static void AddFloor(int floorId, int branchId)
        {
            Floor newFloor = new Floor (BranchId);

            Floors.Add(new Floor (BranchId));   
        }



        public void GetAllFloorInBranch (int BranchId)
        {

        }


    }
}

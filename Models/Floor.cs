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

        public Floor ( int BranchId)
        {
            FloorCount ++;
            FloorId = FloorCount; 
            this.BranchId = BranchId;

        }

        //3. ===============Class methods===============

        public void AddFloor(int BranchId)
        {
            Floor newFloor = new Floor (BranchId);

            Floors.Add(new Floor (BranchId));   
        }



        public void GetAllFloorInBranch (int BranchId)
        {

        }


    }
}

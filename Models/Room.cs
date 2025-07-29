using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    // ==============1. Class Fields ==============
    public class Room
    {
        public int RoomId;
        public string Name;
        public int FloorId;
        public int BranchId; 


        // list 
        public List<Room> Rooms=new List<Room>();



        //============2. Constructor============

        public Room(int roomId , int floorId , int branchId) 
        {
            this.RoomId = roomId;
            this.FloorId = floorId;
            this.BranchId = branchId;
        }

    }
}

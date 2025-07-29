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
        public int RoomId;  // Unique room identifier
        public string Name;  // Name of the room (optional field, you can use it later)
        public int FloorId; // The ID of the floor where the room is located
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

        // Methodes 

        public void AddRoom()
        {
            Console.WriteLine("Enter the room id :");
            int roomId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the branch id :");
            int branchId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Floor id:");
            int floorId = int.Parse(Console.ReadLine());


            Room newRoom = Rooms(roomId , floorId , branchId);
            {
                Rooms.Add(newRoom);

                Console.WriteLine("The room has been successfully added"
            }
        }


    }
}

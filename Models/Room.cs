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
        public int BranchId; // The ID of the branch this room belongs to


        //  Shared list to store all rooms (static so it belongs to the class, not object)
        public static  List<Room> Rooms=new List<Room>();



        //============2. Constructor============


        // Constructor to create a new Room object
        public Room(int roomId , int floorId , int branchId) 
        {
            this.RoomId = roomId;
            this.FloorId = floorId;
            this.BranchId = branchId;
        }


        // ============== 3. Methods ==============

        // Method to add a new room (reads input from user)
        public static  void AddRoom()
        {
            Console.WriteLine("Enter the Room ID:");
            int roomId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Branch ID:");
            int branchId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the Floor ID:");
            int floorId = int.Parse(Console.ReadLine());



            // Check if room with same ID already exists in this branch and floor
            foreach (var room in Rooms)
            {
                if (room.RoomId == roomId && room.BranchId == branchId && room.FloorId == floorId)
                {
                    Console.WriteLine("❌ This room already exists in the same floor and branch.");
                    return;
                }
            }

            // If not found, add new room
            Room newRoom = new Room(roomId, floorId, branchId);
            Rooms.Add(newRoom);

            Console.WriteLine("The room has been successfully added.");
        }


        // Optional: Display all rooms in a branch
        public static void GetAllRoomsInBranch(int branchId)
        {
            Console.WriteLine($"Rooms in Branch {branchId}:");
            bool found = false;

            foreach (var room in Rooms)
            {
                if (room.BranchId == branchId)
                {
                    Console.WriteLine($"Room ID: {room.RoomId}, Floor ID: {room.FloorId}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("❌ No rooms found in this branch.");
            }
        }


    }
}

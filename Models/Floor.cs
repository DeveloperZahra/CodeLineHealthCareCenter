using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    public class Floor
    {
        // 1.==============Class Field ==============
        public static int FloorCount = 0; 
        public int FloorId {  get; set; }
        public int BranchId { get; set; }

        // A list to store all Floor (acting as an in-memory database)

        public List<Floor> Floors = new  List<Floor>();



        //2. ===============class Constructor=============

        public Floor ( int BranchId)
        {
            FloorCount ++;
            FloorId = FloorCount; 
            this.BranchId = BranchId;

        }

    }
}

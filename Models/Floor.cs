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


        // List of floor 

        public List<Floor> Floors = new  List<Floor>();



    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    class Branch
    {
        // 1. Class Field...
        public int BranchId;// ID public attribute for every branch 
        public string BranchName;// Name public attribute for every branch
        public string BranchAddress; // address public attribute in class of branch 
        public bool BranchStatus; // current status of Branch; true represent is open, false represent close 
        public DateOnly BranchEstablished; // Establish Date OF Branch
        public static int BranchCount =0;
        public List<Floor> Floors = new List<Floor>();
        
        // 2. class property... 


        // 3. class method...

        // 4. Class Constructor...






    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    // Represents a branch of the hospital, including its details and associated floors.
    class Branch
    {
        // 1. Class Field...
        private int BranchId;// Unique identifier for the branch. 
        private string BranchName;// The name of the branch.
        private string BranchAddress; //The address where the branch is located. 
        private bool BranchStatus; // Indicates whether the branch is currently active (true = open, false = closed).
        private DateOnly BranchEstablished; // The date when the branch was established.
        private static int BranchCount =0; // Keeps track of the total number of branches created.
        private List<Floor> Floors = new List<Floor>(); //  List of floors that belong to this branch.

        // 2. class property... 


        // 3. class method...

        // 4. Class Constructor...






    }
}

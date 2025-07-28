using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter.Models
{
    // Doctor class inherits from the base class User
    public class Doctor : User
    {
        // The doctor's medical specialty (e.g., Cardiology, Pediatrics)
        public string Specialty { get; set; }



    }
}

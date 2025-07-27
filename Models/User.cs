using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    // Base class representing a general user in the system
    public class User
    {
        // Unique identifier for the user
        public int Id { get; set; }

        // User's full name
        public string FullName { get; set; }

        // User's email address (used for login or contact)
        public string Email { get; set; }

       
        // Virtual method to get the role of the user (can be overridden in derived classes)
        public virtual string GetRole()
        {
            // Default role for a basic user
            return "User";
        }

    }
}

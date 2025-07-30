using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter
{
    public static class UserValidator
    {
        public static void ValidateName(string name) 

        {
            if (string.IsNullOrWhiteSpace(name)) // Check if the name is null, empty, or consists only of whitespace
                throw new ArgumentException("Name cannot be empty.");
        }
    }
}

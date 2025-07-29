using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter.Services
{
    public interface IAdminServices
    {
        void AddAdmin(string name, string email, string password, string nationalId, string phoneNumber,string gender, int branchId, int departmentId);
    }
}

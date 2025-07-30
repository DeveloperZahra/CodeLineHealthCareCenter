using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalSystemTeamTask.Services;
using CodeLineHealthCareCenter.Models;


namespace CodeLineHealthCareCenter.Services
{
    public interface ISuperAdminSevices
    {
        void AddSuperAdmin(string name, string email, string password, string nationalId, string phoneNumber, string gender);
    }
}

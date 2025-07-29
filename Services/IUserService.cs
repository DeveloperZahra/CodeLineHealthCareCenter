//using HospitalSystemTeamTask.DTO_s;
using CodeLineHealthCareCenter.Models;
using HospitalSystemTeamTask.Services;


namespace HospitalSystemTeamTask.Services
{
    public interface IUserService
    {   
        bool AuthenticateUser(string email, string password, string Role);
        void DeactivateUser(string UserId, string role);
        bool EmailExists(string email, string role);
        void GetUserById(string UserId, string Role);
        void UpdatePassword(string UserId,string Role, string currentPassword, string newPassword);
        void UpdateUser(string UserId, string Role);
        void GetUsersByRole(string roleName);
    }
}
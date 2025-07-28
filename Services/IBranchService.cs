//using HospitalSystemTeamTask.Models;
using HospitalSystemTeamTask.Services;

namespace HospitalSystemTeamTask.Services
{
    public interface IBranchService
    {
        void AddBranch(string branchAddress, string phoneNumber);
        void GetAllBranches();
        void GetBranchById(int branchId);
        void GetBranchDetails(string branchName, int  branchId);
        void GetBranchDetailsByBranchName(string branchName);
        string GetBranchName(int branchId);
        void SetBranchStatus(int branchId, bool isActive);
        void UpdateBranch(int branchId);
    }
}
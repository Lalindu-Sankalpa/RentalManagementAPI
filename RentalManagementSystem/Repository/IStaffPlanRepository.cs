using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;

namespace RentalManagementSystem.Repository
{
    public interface IStaffPlanRepository
    {
        Task<List<StaffPlanModel>> GetAllStaffPlansAsync();
        Task<StaffPlanModel> GetStaffPlanByIdAsync(int staffPlanId);
        Task<long> AddStaffPlanAsync(StaffPlanModel staffPlanModel);
        Task UpdateStaffPlanAsync(int staffPlanId, StaffPlanModel staffPlanModel);
        Task DeleteStaffPlanAsync(int staffPlanId);
    }
}

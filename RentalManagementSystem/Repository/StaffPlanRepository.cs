using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RentalManagementSystem.Data;
using RentalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace RentalManagementSystem.Repository
{
    public class StaffPlanRepository : IStaffPlanRepository
    {
        private readonly RentalReservationContext _context;
        private readonly IMapper _mapper;
        public StaffPlanRepository(RentalReservationContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<StaffPlanModel>> GetAllStaffPlansAsync()
        {
            var records = await _context.Staffplans.ToListAsync();
            return _mapper.Map<List<StaffPlanModel>>(records); //Auto Map the record
        }

        public async Task<StaffPlanModel> GetStaffPlanByIdAsync(int staffPlanId)
        {
            var staffplan = await _context.Staffplans.FindAsync(staffPlanId);
            return _mapper.Map<StaffPlanModel>(staffplan);
        }

        public async Task<long> AddStaffPlanAsync(StaffPlanModel staffPlanModel)
        {
            var staffPlan = new Staffplan()
            {
                UserId = staffPlanModel.UserId,
                TimeFrom = staffPlanModel.TimeFrom,
                TimeTo = staffPlanModel.TimeTo,
                Break = staffPlanModel.Break,
                Point = staffPlanModel.Point
            };

            _context.Staffplans.Add(staffPlan);
            await _context.SaveChangesAsync();

            return staffPlan.StaffplanId;
        }
        public async Task UpdateStaffPlanAsync(int staffPlanId, StaffPlanModel staffPlanModel)
        {
            var staffPlan = new Staffplan()
            {
                StaffplanId = staffPlanId,
                UserId = staffPlanModel.UserId,
                TimeFrom = staffPlanModel.TimeFrom,
                TimeTo = staffPlanModel.TimeTo,
                Break = staffPlanModel.Break,
                Point = staffPlanModel.Point
            };

            _context.Staffplans.Update(staffPlan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStaffPlanAsync(int staffPlanId)
        {
            var staffPlan = new Staffplan()
            {
                StaffplanId = staffPlanId
            };

            _context.Staffplans.Remove(staffPlan);

            await _context.SaveChangesAsync();
        }
    }
}


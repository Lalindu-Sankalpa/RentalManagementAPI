using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;
using RentalManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace RentalManagementSystem.Controllers
{
    [Route("api/staffPlans")]
    [ApiController]
    public class StaffPlanController : ControllerBase
    {
        private readonly IStaffPlanRepository _staffPlanRepository;
        public StaffPlanController(IStaffPlanRepository staffPlanRepository)
        {
            _staffPlanRepository = staffPlanRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllStaffPlans()
        {
            var staffPlans = await _staffPlanRepository.GetAllStaffPlansAsync();
            return Ok(staffPlans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffPlanById([FromRoute] int id)
        {
            var staffPlan = await _staffPlanRepository.GetStaffPlanByIdAsync(id);
            if (staffPlan == null)
            {
                return NotFound();
            }
            return Ok(staffPlan);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddStaffPlan([FromBody] StaffPlanModel staffPlanModel)
        {
            var id = await _staffPlanRepository.AddStaffPlanAsync(staffPlanModel);
            return CreatedAtAction(nameof(GetStaffPlanById), new { id = id, controller = "StaffPlan" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaffPlan([FromBody] StaffPlanModel staffPlanModel, [FromRoute] int id)
        {
            await _staffPlanRepository.UpdateStaffPlanAsync(id, staffPlanModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffPlan([FromRoute] int id)
        {
            await _staffPlanRepository.DeleteStaffPlanAsync(id);
            return Ok();
        }

    }
}

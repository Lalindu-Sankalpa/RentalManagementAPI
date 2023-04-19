using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;
using RentalManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace RentalManagementSystem.Controllers
{
    [Route("api/lenses")]
    [ApiController]
    public class LenseController : ControllerBase
    {
        private readonly ILenseRepository _lenseRepository;
        public LenseController(ILenseRepository lenseRepository)
        {
            _lenseRepository = lenseRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllLenses()
        {
            var lenses = await _lenseRepository.GetAllLensesAsync();
            return Ok(lenses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLenseById([FromRoute] int id)
        {
            var lense = await _lenseRepository.GetLenseByIdAsync(id);
            if (lense == null)
            {
                return NotFound();
            }
            return Ok(lense);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddLense([FromBody] LenseModel lenseModel)
        {
            var id = await _lenseRepository.AddLenseAsync(lenseModel);
            return CreatedAtAction(nameof(GetLenseById), new { id = id, controller = "Lense" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLense([FromBody] LenseModel lenseModel, [FromRoute] int id)
        {
            await _lenseRepository.UpdateLenseAsync(id, lenseModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLense([FromRoute] int id)
        {
            await _lenseRepository.DeleteLenseAsync(id);
            return Ok();
        }

    }
}

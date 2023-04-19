using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;
using RentalManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace RentalManagementSystem.Controllers
{
    [Route("api/cameraTypes")]
    [ApiController]
    public class CameraTypeController : ControllerBase
    {
        private readonly ICameraTypeRepository _cameraTypeRepository;
        public CameraTypeController(ICameraTypeRepository cameraTypeRepository)
        {
            _cameraTypeRepository = cameraTypeRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCameraTypes()
        {
            var cameras = await _cameraTypeRepository.GetAllCameraTypesAsync();
            return Ok(cameras);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCameraTypeById([FromRoute] int id)
        {
            var camera = await _cameraTypeRepository.GetCameraTypeByIdAsync(id);
            if (camera == null)
            {
                return NotFound();
            }
            return Ok(camera);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddCameraType([FromBody] CameraTypeModel cameraTypeModel)
        {
            var id = await _cameraTypeRepository.AddCameraTypeAsync(cameraTypeModel);
            return CreatedAtAction(nameof(GetCameraTypeById), new { id = id, controller = "CameraType" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCameraType([FromBody] CameraTypeModel cameraTypeModel, [FromRoute] int id)
        {
            await _cameraTypeRepository.UpdateCameraTypeAsync(id, cameraTypeModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCameraType([FromRoute] int id)
        {
            await _cameraTypeRepository.DeleteCameraTypeAsync(id);
            return Ok();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;
using RentalManagementSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentalManagementSystem.Controllers
{
    [Route("api/cameras")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ICameraRepository _cameraRepository;
        public CameraController(ICameraRepository cameraRepository)
        {
            _cameraRepository = cameraRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCameras()
        {
            var cameras = await _cameraRepository.GetAllCamerasAsync();
            return Ok(cameras);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCameraById([FromRoute] int id)
        {
            var camera = await _cameraRepository.GetCameraByIdAsync(id);
            if (camera == null)
            {
                return NotFound();
            }
            return Ok(camera);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddCamera([FromBody] CameraModel cameraModel)
        {
            var id = await _cameraRepository.AddCameraAsync(cameraModel);
            return CreatedAtAction(nameof(GetCameraById), new { id = id, controller = "Camera" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCamera([FromBody] CameraModel cameraModel, [FromRoute] int id)
        {
            await _cameraRepository.UpdateCameraAsync(id, cameraModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCamera([FromRoute] int id)
        {
            await _cameraRepository.DeleteCameraAsync(id);
            return Ok();
        }

    }
}

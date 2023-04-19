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
    public class CameraRepository : ICameraRepository
    {
        private readonly RentalReservationContext _context;
        private readonly IMapper _mapper;
        public CameraRepository(RentalReservationContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CameraModel>> GetAllCamerasAsync()
        {
            var records = await _context.Cameras.ToListAsync();
            return _mapper.Map<List<CameraModel>>(records); //Auto Map the record
        }

        public async Task<CameraModel> GetCameraByIdAsync(int cameraId)
        {
            var camera = await _context.Cameras.FindAsync(cameraId);
            return _mapper.Map<CameraModel>(camera);
        }

        public async Task<long> AddCameraAsync(CameraModel cameraModel)
        {
            var camera = new Camera()
            {
                CameraNo = cameraModel.CameraNo,
                Price = cameraModel.Price,
                CameraStatus = cameraModel.CameraStatus,
                CameraTypeId = cameraModel.CameraTypeId,
                IsActive = cameraModel.IsActive
            };

            _context.Cameras.Add(camera);
            await _context.SaveChangesAsync();

            return camera.id;
        }
        public async Task UpdateCameraAsync(int cameraId, CameraModel cameraModel)
        {
            var camera = new Camera()
            {
                id = cameraId,
                CameraNo = cameraModel.CameraNo,
                Price = cameraModel.Price,
                CameraStatus = cameraModel.CameraStatus,
                CameraTypeId = cameraModel.CameraTypeId,
                IsActive = cameraModel.IsActive
            };

            _context.Cameras.Update(camera);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCameraAsync(int cameraId)
        {
            var camera = new Camera()
            {
                id = cameraId
            };

            _context.Cameras.Remove(camera);

            await _context.SaveChangesAsync();
        }
    }
}

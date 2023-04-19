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
    public class CameraTypeRepository : ICameraTypeRepository
    {
        private readonly RentalReservationContext _context;
        private readonly IMapper _mapper;
        public CameraTypeRepository(RentalReservationContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CameraTypeModel>> GetAllCameraTypesAsync()
        {
            var records = await _context.CameraTypes.ToListAsync();
            return _mapper.Map<List<CameraTypeModel>>(records); //Auto Map the record
        }

        public async Task<CameraTypeModel> GetCameraTypeByIdAsync(int cameraTypeId)
        {
            var cameraType = await _context.CameraTypes.FindAsync(cameraTypeId);
            return _mapper.Map<CameraTypeModel>(cameraType);
        }

        public async Task<long> AddCameraTypeAsync(CameraTypeModel cameraTypeModel)
        {
            var cameraType = new CameraType()
            {
                Name = cameraTypeModel.Name,
                Code = cameraTypeModel.Code
            };

            _context.CameraTypes.Add(cameraType);
            await _context.SaveChangesAsync();

            return cameraType.id;
        }
        public async Task UpdateCameraTypeAsync(int cameraTypeId, CameraTypeModel cameraTypeModel)
        {
            var cameraType = new CameraType()
            {
                id = cameraTypeId,
                Name = cameraTypeModel.Name,
                Code = cameraTypeModel.Code
            };

            _context.CameraTypes.Update(cameraType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCameraTypeAsync(int cameraTypeId)
        {
            var cameraType = new CameraType()
            {
                id = cameraTypeId
            };

            _context.CameraTypes.Remove(cameraType);

            await _context.SaveChangesAsync();
        }
    }
}


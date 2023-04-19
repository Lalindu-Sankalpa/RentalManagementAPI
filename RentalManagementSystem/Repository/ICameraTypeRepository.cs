using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;

namespace RentalManagementSystem.Repository
{
    public interface ICameraTypeRepository
    {
        Task<List<CameraTypeModel>> GetAllCameraTypesAsync();
        Task<CameraTypeModel> GetCameraTypeByIdAsync(int cameraTypeId);
        Task<long> AddCameraTypeAsync(CameraTypeModel cameraTypeModel);
        Task UpdateCameraTypeAsync(int cameraTypeId, CameraTypeModel cameraTypeModel);
        Task DeleteCameraTypeAsync(int cameraTypeId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;

namespace RentalManagementSystem.Repository
{
    public interface ICameraRepository
    {

        Task<List<CameraModel>> GetAllCamerasAsync();
        Task<CameraModel> GetCameraByIdAsync(int cameraId);
        Task<long> AddCameraAsync(CameraModel cameraModel);
        Task UpdateCameraAsync(int cameraId, CameraModel cameraModel);
        Task DeleteCameraAsync(int cameraId);

    }
}

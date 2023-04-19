using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;

namespace RentalManagementSystem.Repository
{
    public interface ILenseRepository
    {
        Task<List<LenseModel>> GetAllLensesAsync();
        Task<LenseModel> GetLenseByIdAsync(int lenseId);
        Task<long> AddLenseAsync(LenseModel lenseModel);
        Task UpdateLenseAsync(int lenseId, LenseModel lenseModel);
        Task DeleteLenseAsync(int lenseId);

    }
}

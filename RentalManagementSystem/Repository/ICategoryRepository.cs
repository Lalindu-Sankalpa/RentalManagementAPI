using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;

namespace RentalManagementSystem.Repository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> GetAllCategoriesAsync();
        Task<CategoryModel> GetCategoryByIdAsync(int categoryId);
        Task<long> AddCategoryAsync(CategoryModel categoryModel);
        Task UpdateCategoryAsync(int categoryId, CategoryModel categoryModel);
        Task DeleteCategoryAsync(int categoryId);
    }
}

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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RentalReservationContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(RentalReservationContext context, IMapper mapper) //Dependency Injection
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryModel>> GetAllCategoriesAsync()
        {
            var records = await _context.Categories.ToListAsync();
            return _mapper.Map<List<CategoryModel>>(records); //Auto Map the record
        }

        public async Task<CategoryModel> GetCategoryByIdAsync(int categoryId)
        {
            var feature = await _context.Categories.FindAsync(categoryId);
            return _mapper.Map<CategoryModel>(feature);
        }

        public async Task<long> AddCategoryAsync(CategoryModel categoryModel)
        {
            var category = new Category()
            {
                Name = categoryModel.Name,
                Code = categoryModel.Code
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category.CategoryId;
        }
        public async Task UpdateCategoryAsync(int categoryId, CategoryModel categoryModel)
        {
            var category = new Category()
            {
                CategoryId = categoryId,
                Name = categoryModel.Name,
                Code = categoryModel.Code
            };

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = new Category()
            {
                CategoryId = categoryId
            };

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();
        }
    }
}

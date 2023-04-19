using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentalManagementSystem.Models;
using RentalManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace RentalManagementSystem.Controllers
{
    
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categoriess = await _categoryRepository.GetAllCategoriesAsync();
            return Ok(categoriess);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryModel categoryModel)
        {
            var id = await _categoryRepository.AddCategoryAsync(categoryModel);
            return CreatedAtAction(nameof(GetCategoryById), new { id = id, controller = "Category" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryModel categoryModel, [FromRoute] int id)
        {
            await _categoryRepository.UpdateCategoryAsync(id, categoryModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            return Ok();
        }

    }
}


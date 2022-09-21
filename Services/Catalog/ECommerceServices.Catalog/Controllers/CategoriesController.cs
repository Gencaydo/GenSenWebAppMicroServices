using ECommerce.Shared.Dtos;
using ECommerceServices.Catalog.Dtos;
using ECommerceServices.Catalog.Models;
using ECommerceServices.Catalog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceServices.Catalog.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return ActionResultInstance(categories);
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return ActionResultInstance(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryDto categoryDto)
        {
            var response = await _categoryService.CreateAsync(categoryDto);
            return ActionResultInstance(response);
        }
    }
}

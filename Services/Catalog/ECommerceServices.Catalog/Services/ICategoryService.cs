using ECommerce.Shared.Dtos;
using ECommerceServices.Catalog.Dtos;
using ECommerceServices.Catalog.Models;

namespace ECommerceServices.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<Response<CategoryDto>> GetByIdAsync(string Id);
    }
}

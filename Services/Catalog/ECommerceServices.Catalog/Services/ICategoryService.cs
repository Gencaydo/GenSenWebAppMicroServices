using ECommerceServices.Catalog.Dtos;
using ECommerceServices.Catalog.Models;
using Venhancer.Shared.Dtos;

namespace ECommerceServices.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<Response<CategoryDto>> GetByIdAsync(string Id);
    }
}

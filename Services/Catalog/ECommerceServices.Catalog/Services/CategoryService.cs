using AutoMapper;
using ECommerce.Shared.Dtos;
using ECommerceServices.Catalog.AppSettings;
using ECommerceServices.Catalog.Dtos;
using ECommerceServices.Catalog.Models;
using MongoDB.Driver;

namespace ECommerceServices.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DBName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollection);
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(category);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string Id)
        {
            var category = await _categoryCollection.Find<Category>(x=> x.Id == Id).FirstOrDefaultAsync();
            if (category == null) Response<CategoryDto>.Fail(new ErrorDto("Category Not Found", true), 404);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}

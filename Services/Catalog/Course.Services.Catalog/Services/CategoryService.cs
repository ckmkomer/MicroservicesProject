using AutoMapper;
using Course.Services.Catalog.Dtos.CategoryDtos;
using Course.Services.Catalog.Model;
using Course.Services.Catalog.Settings;
using Course.Shared.Dtos;
using MongoDB.Driver;

namespace Course.Services.Catalog.Services
{
    public class CategoryService :ICategoryService
    {
        private readonly IMongoCollection<Category> _categories;
        private readonly IMapper _mapper;

        public CategoryService(IMongoCollection<Category> categories, IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categories = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }


        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categories.Find(category=>true).ToListAsync();

            return  Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<Response<CategoryDto>> CreateAsync(Category category)
        {
            await _categories.InsertOneAsync(category);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category),200);

        }


        public async Task<Response<CategoryDto>>GetByIdAsync (string id) 
        {
            var category = await _categories.Find<Category>(x=>x.Id==id).FirstOrDefaultAsync();
            if(category == null)
            {
                return Response<CategoryDto>.Fail("Category not found", 404);

            }
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category),200);
        }
    }
}

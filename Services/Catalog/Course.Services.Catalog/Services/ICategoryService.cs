using Course.Services.Catalog.Dtos.CategoryDtos;
using Course.Services.Catalog.Model;
using Course.Shared.Dtos;

namespace Course.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();

        Task<Response<CategoryDto>> CreateAsync(Category category);

        Task<Response<CategoryDto>> GetByIdAsync(string id);

    }
}

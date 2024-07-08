using Course.Services.Catalog.Dtos.CategoryDtos;
using Course.Services.Catalog.Dtos.CourseDtos;
using Course.Services.Catalog.Model;
using Course.Shared.Dtos;

namespace Course.Services.Catalog.Services
{
    public interface ICourseService
    {
        Task<Response<List< CourseDto>>> GetAllAsync();

        Task<Response<CourseDto>> CreateAsync(Courses courses);

        Task<Response<CourseDto>> GetByIdAsync(string id);
    }
}

using AutoMapper;
using Course.Services.Catalog.Dtos.CategoryDtos;
using Course.Services.Catalog.Dtos.CourseDtos;
using Course.Services.Catalog.Model;
using Course.Services.Catalog.Settings;
using Course.Shared.Dtos;
using MongoDB.Driver;

namespace Course.Services.Catalog.Services
{
    public class CourseService  :ICourseService
    {
        private readonly IMongoCollection<Courses> _courses;
        private readonly IMapper _mapper;

        public CourseService(IMongoCollection<Courses> courses, IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _courses = database.GetCollection<Courses>(databaseSettings.CourseCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courses.Find(category => true).ToListAsync();

            if (courses.Any())
            {
                foreach (var item in courses)
                {
                    item.
                }
            }

            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<Response<CourseDto>> CreateAsync(Courses courses)
        {
            await _courses.InsertOneAsync(courses);
            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(courses), 200);

        }


        public async Task<Response<CourseDto>> GetByIdAsync(string id)
        {
            var course = await _courses.Find<Courses>(x => x.Id == id).FirstOrDefaultAsync();
            if (course == null)
            {
                return Response<CourseDto>.Fail("Course not found", 404);

            }
            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        }
    }
}

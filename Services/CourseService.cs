using AutoMapper;
using LearningManagementSystemAPI.Entities;
using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystemAPI.Controllers
{
    public interface ICourseService
    {
        IEnumerable<CourseDto> GetAll();
        CourseDto Get(int id);
        int Create(CreateOrUpdateCourseDto course);
        bool Delete(int id);
        bool Update(CreateOrUpdateCourseDto courseDto, int id);
    }
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CourseService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<CourseDto> GetAll() 
        {
            var courses = _dbContext
                    .Courses
                    .Include(c => c.Participants)
                    .Include(c => c.Activities)
                    .ToList();
            
            var coursesDto = _mapper.Map<List<CourseDto>>(courses);
            return coursesDto;
        }

        public CourseDto Get(int id)
        {
            var course = GetById(id);

            var courseDto = _mapper.Map<CourseDto>(course);
            return courseDto;
        }

        public int Create(CreateOrUpdateCourseDto courseDto)
        {
            var course = new Course
            {
                Name = courseDto.Name,
                Description = courseDto.Description,

            }; //ToDo map the rest of properties
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return course.Id;
        }

        public bool Delete(int id)
        {
            var course = GetById(id);
            _dbContext.Courses.Remove(course);
            _dbContext.SaveChanges();

            if(course == null)
                return false;
            return true;
        }

        public bool Update(CreateOrUpdateCourseDto courseDto ,int id)
        {
            var course = GetById(id);
            if (course == null)
                return false;

            course.Name = courseDto.Name;
            course.Description = courseDto.Description;
            //course.PasswordHash = passwordHash ToDo passwordHash

            _dbContext.SaveChanges();
            return true;
        }

        private Course GetById(int id)
        {
            var course = _dbContext
                 .Courses
                 .Include(c => c.Participants)
                 .Include(c => c.Activities)
                 .FirstOrDefault(c => c.Id == id);

            if (course == null)
                return null;
            return course;
        }
    }
}

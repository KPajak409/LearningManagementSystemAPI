using AutoMapper;
using LearningManagementSystemAPI.Entities;
using LearningManagementSystemAPI.Middleware;
using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystemAPI.Services
{
    public interface IActivityService
    {
        ActivityDto Get(int id);
        int Create(int courseId, CreateOrUpdateActivityDto activityDto);
        int Update(CreateOrUpdateActivityDto activityDto, int id);
        void Delete(int id);

    }
    public class ActivityService : IActivityService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ActivityService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ActivityDto Get(int id)
        {
            var activity = GetById(id);
            return _mapper.Map<ActivityDto>(activity);
        }

        public int Create(int courseId, CreateOrUpdateActivityDto createActivityDto)
        {
            var course = _dbContext.Courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
                throw new NotFoundException("Course not found");

            var activityEntity = _mapper.Map<Activity>(createActivityDto); // Add Author mapping

            activityEntity.Course = course;
            _dbContext.Activities.Add(activityEntity);
            _dbContext.SaveChanges();
            return activityEntity.Id;
        }

        public int Update(CreateOrUpdateActivityDto activityDto, int id)
        {
            var activity = GetById(id);
            _mapper.Map(activityDto, activity);
            
            _dbContext.SaveChanges();
            return activity.Id;
        }

        public void Delete(int id)
        {
            var activity = GetById(id);

            _dbContext.Remove(activity);
            _dbContext.SaveChanges();
        }

        private Activity GetById(int id)
        {
            var activity = _dbContext
                .Activities
                .Include(a => a.Course)
                .Include(a => a.Author)
                .FirstOrDefault(a => a.Id == id);
            if (activity == null)
                throw new NotFoundException("Activity not found");
            return activity;
        }
    }
}

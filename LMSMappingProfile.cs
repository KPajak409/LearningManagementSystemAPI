using AutoMapper;
using LearningManagementSystemAPI.Entities;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI
{
    public class LMSMappingProfile : Profile
    {
        public LMSMappingProfile()
        {
            CreateMap<Course, CourseDto>();
            
            CreateMap<User, UserDto>();           
        }
    }
}

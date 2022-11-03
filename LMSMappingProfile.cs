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
            CreateMap<CreateOrUpdateActivityDto, Activity>();
            CreateMap<Activity, ActivityDto>()
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.Course.Id))
                .ForMember(dest => dest.Author, 
                    opt => opt.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName));
        }
    }
}

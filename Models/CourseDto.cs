using LearningManagementSystemAPI.Entities;

namespace LearningManagementSystemAPI.Models
{
    public class CourseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public ICollection<UserDto> Participants { get; set; }
        public ICollection<ActivityDto> Activities { get; set; }
    }
}

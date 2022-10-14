using LearningManagementSystemAPI.Entities;

namespace LearningManagementSystemAPI.Models
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public virtual ICollection<UserDto> Participants { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}

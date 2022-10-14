using LearningManagementSystemAPI.Entities;

namespace LearningManagementSystemAPI.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } 
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<CourseDto> Courses { get; set; }
    }
}

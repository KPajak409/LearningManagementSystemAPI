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
        public Role Role { get; set; }
        public ICollection<CourseDto> Courses { get; set; }
    }
}

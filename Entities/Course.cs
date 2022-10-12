using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string AuthorId { get; set; }
        public virtual ICollection<User> Participants { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}

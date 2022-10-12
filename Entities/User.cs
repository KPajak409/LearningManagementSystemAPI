using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningManagementSystemAPI.Entities
{
    public class User
    {              
        public Guid Id { get; set; } 
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } // ToDo send test email to verify user input
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}

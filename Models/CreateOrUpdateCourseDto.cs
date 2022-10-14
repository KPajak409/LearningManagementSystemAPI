using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.Models
{
    public class CreateOrUpdateCourseDto
    {
        [MaxLength(16)]
        public string Password { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        

    }
}
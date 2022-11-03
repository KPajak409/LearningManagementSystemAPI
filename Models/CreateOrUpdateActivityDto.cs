using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.Models
{
    public class CreateOrUpdateActivityDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Details { get; set; }
        public DateTime StartTime { get; set; } // ToDo validation of the rest properties
        public DateTime EndTime { get; set; }
        public int Points { get; set; }
    }
}

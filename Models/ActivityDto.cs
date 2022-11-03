using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.Models
{
    public class ActivityDto
    {           
        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Points { get; set; }
        public int CourseId { get; set; }
        public string Author { get; set; }
    }
}

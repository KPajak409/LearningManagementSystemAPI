namespace LearningManagementSystemAPI.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }        
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; } 
        public int Points { get; set; }
        public virtual Course Course { get; set; }
        public virtual User Author { get; set; }
     }
}

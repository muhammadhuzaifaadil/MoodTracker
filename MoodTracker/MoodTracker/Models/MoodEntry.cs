namespace MoodTracker.Models
{
    public class MoodEntry
    {
        public int Id { get; set; }
        public MoodType Mood { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Note { get; set; }
    }
}

using MoodTracker.Models;
using System.ComponentModel.DataAnnotations;

namespace MoodTracker.DTOs
{
    public class CreateMoodEntryRequest
    {
        [Required]
        public MoodType Mood { get; set; }

        [MaxLength(280)]
        public string? Note { get; set; }
    }
}

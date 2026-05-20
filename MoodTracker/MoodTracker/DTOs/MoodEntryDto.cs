using MoodTracker.Models;

namespace MoodTracker.DTOs
{
    public record MoodEntryDto(
      int Id,
      MoodType Mood,
      DateTime Timestamp,
      string? Note
  );
}

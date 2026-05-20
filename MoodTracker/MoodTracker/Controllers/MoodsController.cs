using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoodTracker.Context;
using MoodTracker.DTOs;
using MoodTracker.Models;

namespace MoodTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoodsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public MoodsController(AppDbContext db) => _db = db;


        [HttpPost]
        public async Task<ActionResult<MoodEntryDto>> Create(
            [FromBody] CreateMoodEntryRequest request,
            CancellationToken ct)
        {
            var entity = new MoodEntry
            {
                Mood = request.Mood,
                Note = request.Note,
                Timestamp = DateTime.UtcNow
            };

            _db.MoodEntries.Add(entity);
            await _db.SaveChangesAsync(ct);

            var dto = new MoodEntryDto(entity.Id, entity.Mood, entity.Timestamp, entity.Note);

            return Created(string.Empty, dto);
        }


        [HttpGet]
        public async Task<ActionResult<List<MoodEntryDto>>> GetLast7(
          CancellationToken ct,
          [FromQuery] int limit = 7)
        {
            limit = Math.Clamp(limit, 1, 7);

            var items = await _db.MoodEntries
                .AsNoTracking()
                .OrderByDescending(x => x.Timestamp)
                .Take(limit)
                .Select(x => new MoodEntryDto(x.Id, x.Mood, x.Timestamp, x.Note))
                .ToListAsync(ct);

            items.Reverse();

            return Ok(items);
        }

    }
}

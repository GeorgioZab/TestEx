using TestEx.Data;
using TestEx.DTOs;
using TestEx.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BiogenomNutritionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NutritionController : ControllerBase
    {
        private readonly NutritionDbContext _context;

        public NutritionController(NutritionDbContext context)
        {
            _context = context;
        }

        [HttpGet("latest")]
        public async Task<ActionResult<NutritionAssessmentDto>> GetLatestAssessment()
        {
            var latest = await _context.Assessments
                .Include(a => a.Answers)
                .OrderByDescending(a => a.CompletedAt)
                .FirstOrDefaultAsync();

            if (latest == null)
                return NotFound("Оценка качества питания не найдена.");

            return new NutritionAssessmentDto
            {
                CompletedAt = latest.CompletedAt,
                Summary = latest.Summary,
                Recommendation = latest.Recommendation,
                Answers = latest.Answers.Select(a => new AnswerDto
                {
                    QuestionId = a.QuestionId,
                    QuestionText = a.QuestionText,
                    Answer = a.Answer
                }).ToList()
            };
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadAssessment([FromBody] UploadAssessmentDto dto)
        {
            var existing = await _context.Assessments.Include(a => a.Answers).FirstOrDefaultAsync();
            if (existing != null)
            {
                _context.Assessments.Remove(existing);
                await _context.SaveChangesAsync();
            }

            var assessment = new NutritionAssessment
            {
                CompletedAt = DateTime.UtcNow,
                Summary = dto.Summary,
                Recommendation = dto.Recommendation,
                Answers = dto.Answers.Select(a => new AssessmentAnswer
                {
                    QuestionId = a.QuestionId,
                    QuestionText = a.QuestionText,
                    Answer = a.Answer
                }).ToList()
            };

            _context.Assessments.Add(assessment);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
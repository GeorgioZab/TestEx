namespace TestEx.DTOs
{
    public class NutritionAssessmentDto
    {
        public DateTime CompletedAt { get; set; }
        public string Summary { get; set; }
        public string Recommendation { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}

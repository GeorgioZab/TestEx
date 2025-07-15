namespace TestEx.Models
{
    public class NutritionAssessment
    {
        public int Id { get; set; }
        public DateTime CompletedAt { get; set; }
        public List<AssessmentAnswer> Answers { get; set; } = new();
        public string Summary { get; set; } = string.Empty;
        public string Recommendation { get; set; } = string.Empty;
    }
}

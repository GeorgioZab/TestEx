namespace TestEx.Models
{
    public class AssessmentAnswer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;

        public int NutritionAssessmentId { get; set; }
        public NutritionAssessment NutritionAssessment { get; set; }
    }
}

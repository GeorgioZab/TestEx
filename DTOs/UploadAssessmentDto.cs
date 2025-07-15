namespace TestEx.DTOs
{
    public class UploadAssessmentDto
    {
        public string Summary { get; set; } = string.Empty;
        public string Recommendation { get; set; } = string.Empty;
        public List<AnswerDto> Answers { get; set; } = new();
    }
}

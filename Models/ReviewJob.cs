public class ReviewJob
{
    public bool IsNew { get; set; }
    public object[] EvaluationMarks { get; set; }
    public bool IsKey { get; set; }
    public LearningResource[] LearningResources { get; set; }
    public object[] NeboTasks { get; set; }
    public object[] Skills { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public string GradeId { get; set; }
    public string Description { get; set; }
}

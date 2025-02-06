namespace ParseJobs.Models;

public class ReviewJobDto
{
    public bool IsKey { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public LearningResourceDto[] LearningResources { get; set; }

    public static ReviewJobDto FromReviewJob(ReviewJob job)
    {
        return new ReviewJobDto
        {
            IsKey = job.IsKey,
            Name = job.Name,
            Description = ConvertHtmlToFormattedPlainText(job.Description),
            LearningResources = job.LearningResources.Select(LearningResourceDto.FromLearningResource).ToArray()
        };
    }
}

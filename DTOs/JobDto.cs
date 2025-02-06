namespace ParseJobs.Models;

public class JobDto
{
    public PositionEnum JobLevel { get; set; }
    public ReviewJobDto[] ReviewJobs { get; set; }

    public static JobDto FromJob(Job job)
    {
        return new JobDto
        {
            JobLevel = Enum.Parse<PositionEnum>(job.JobLevelName.Split(' ')[0]),
            ReviewJobs = job.ReviewJobs.Select(ReviewJobDto.FromReviewJob).ToArray()
        };
    }
}

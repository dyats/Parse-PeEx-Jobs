public class Job
{
    public string JobLevelName { get; set; }
    public bool IsJobLevelNew { get; set; }
    public ReviewJob[] ReviewJobs { get; set; }
}

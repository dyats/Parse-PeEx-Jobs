namespace ParseJobs.Models;

public class CompetencyDto
{
    public string Name { get; set; }
    public string Description { get; set; }

    public JobDto[] Jobs { get; set; }

    public static CompetencyDto FromCompetency(Competency competency)
    {
        return new CompetencyDto
        {
            Name = competency.Name,
            Description = competency.Description,
            Jobs = competency.Jobs.Select(JobDto.FromJob).ToArray()
        };
    }
}

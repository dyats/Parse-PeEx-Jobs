namespace ParseJobs.Models;

public class Competency
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsNew { get; set; }
    public bool CompetencyHasSkills { get; set; }

    public Job[] Jobs { get; set; }

    public bool Exclude { get; set; }
}

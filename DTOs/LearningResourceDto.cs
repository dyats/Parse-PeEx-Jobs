namespace ParseJobs.Models;

public class LearningResourceDto
{
    public string Name { get; set; }
    public string Link { get; set; }

    public static LearningResourceDto FromLearningResource(LearningResource resource)
    {
        return new LearningResourceDto
        {
            Name = resource.Name,
            Link = resource.Link
        };
    }
}

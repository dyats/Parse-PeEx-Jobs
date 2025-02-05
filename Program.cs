using Newtonsoft.Json;
using ParseJobs.Models;

var peexJobs = JsonConvert.DeserializeObject<Job[]>(File.ReadAllText("jobs.json"));

var middleAndSeniorJobs = peexJobs.Where(x =>
    x.JobLevelName.Contains(PositionEnum.Middle.ToString()) ||
    x.JobLevelName.Contains(PositionEnum.Senior.ToString()));

foreach (var job in middleAndSeniorJobs.SelectMany(x => x.ReviewJobs))
{

    Console.WriteLine($"Key: {job.IsKey}");
    Console.WriteLine($"Name: {job.Name}");
    Console.WriteLine($"Description: {job.Description}");
    Console.WriteLine($"Learning resources");
    foreach (var res in job.LearningResources)
    {
        Console.WriteLine($"" +
            $"Resource: {res.Name}\n" +
            $"Link: {res.Link}");
    }
    Console.WriteLine($"");
}
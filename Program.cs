using HtmlAgilityPack;
using Newtonsoft.Json;

var peexJobs = JsonConvert.DeserializeObject<Job[]>(File.ReadAllText("jobs.json"));

foreach (var job in peexJobs)
{
    foreach (var subItem in job.ReviewJobs)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(subItem.Description);
        Console.WriteLine(doc.DocumentNode.InnerText.Trim());
        Console.WriteLine();
    }
}
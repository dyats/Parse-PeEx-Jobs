using Newtonsoft.Json;

var competencies = JsonConvert.DeserializeObject<Competency[]>(File.ReadAllText(@"Data\competencies.json"));

competencies = competencies.Where(x => !x.Exclude).ToArray();

foreach (var competency in competencies.Select((value, index) => new { Index = index + 1, Value = value }))
{
    var competencyJobs = JsonConvert.DeserializeObject<Job[]>(File.ReadAllText(@$"Data\jobs.competency{competency.Index}.json"));

    // Filter for middle & senior jobs
    competency.Value.Jobs = competencyJobs.Where(job => positionLevelFilterPredicate(job, (int)PositionEnum.Middle, (int)PositionEnum.Senior)).ToArray();
}

var serializedCompetencies = JsonConvert.SerializeObject(competencies.Select(CompetencyDto.FromCompetency), Formatting.Indented);
File.WriteAllText(@"Data\aggregated-jobs.json", serializedCompetencies);
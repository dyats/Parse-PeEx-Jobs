namespace ParseJobs;

public static class Predicates
{
    public static Func<Job, int, int, bool> positionLevelFilterPredicate = (job, startLevel, endLevel) =>
    {
        var levels = Enum.GetValues<PositionEnum>()
            .Cast<PositionEnum>()
            .ToArray()
            [startLevel..(endLevel + 1)];

        return levels.Any(l => job.JobLevelName.Contains(l.ToString()));
    };
}

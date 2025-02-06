using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ParseJobs.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum PositionEnum
{
    Trainee = 0,
    Junior  = 1,
    Middle  = 2,
    Senior  = 3,
    Lead    = 4
}

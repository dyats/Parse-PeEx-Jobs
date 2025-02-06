using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ParseJobs.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum PositionEnum
{
    Trainee,
    Junior,
    Middle,
    Senior,
    Lead
}

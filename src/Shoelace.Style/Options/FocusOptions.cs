using System.Text.Json.Serialization;

namespace Shoelace.Style.Options;

public class FocusOptions
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PreventScroll { get; set; }
}
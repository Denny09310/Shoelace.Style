using System.Text.Json.Serialization;

namespace Shoelace.Style.Options;

/// <summary>
/// Represents options for controlling focus behavior.
/// </summary>
public class FocusOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether to prevent scrolling when the element is focused.
    /// If set to <c>true</c>, scrolling will be prevented; otherwise, it allows scrolling. 
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PreventScroll { get; set; }
}

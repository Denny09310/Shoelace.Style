using System.Text.Json.Serialization;

namespace Shoelace.Style.Options;

/// <summary>
/// Represents the options for configuring a toast notification.
/// </summary>
public class ToastOptions
{
    /// <summary>
    /// Gets or sets the duration in milliseconds for which the toast notification should be displayed.
    /// If set to <c>null</c>, the default duration will be used.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Duration { get; set; }

    /// <summary>
    /// Gets or sets the icon to be displayed in the toast notification.
    /// If set to <c>null</c>, no icon will be displayed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Icon { get; set; }

    /// <summary>
    /// Gets or sets the variant of the toast notification, which can be used to style the notification (e.g., success, error, warning).
    /// If set to <c>null</c>, the default styling will be applied.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Variant { get; set; }
}

using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Outputs a localized time phrase relative to the current date and time.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/relative-time"/>
/// </remarks>
public partial class ShoelaceRelativeTime : ShoelaceComponentBase
{
    #region Properties

    /// <summary>
    /// The date from which to calculate time from.
    /// If not set, the current date and time will be used. When passing a string, 
    /// it’s strongly recommended to use the ISO 8601 format to ensure timezones are handled correctly
    /// </summary>
    [Parameter]
    public DateTime Date { get; set; }

    /// <summary>
    /// The formatting style to use.
    /// </summary>
    /// <remarks>
    /// Possible values are 'long' | 'short' | 'narrow'
    /// </remarks>
    [Parameter]
    public string? Format { get; set; }

    /// <summary>
    /// When auto, values such as “yesterday” and “tomorrow” will be shown when possible.
    /// When always, values such as “1 day ago” and “in 1 day” will be shown.
    /// </summary>
    /// <remarks>
    /// Possible values are 'always' | 'auto'
    /// </remarks>
    [Parameter]
    public string? Numeric { get; set; }

    /// <summary>
    /// Keep the displayed value up to date as time passes.	
    /// </summary>
    [Parameter]
    public bool Sync { get; set; }

    #endregion Properties
}
using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Formats a date/time using the specified locale and options.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/format-date"/>
/// </remarks>
public partial class ShoelaceFormatDate : ShoelaceComponentBase
{
    #region Properties

    /// <summary>
    /// The date/time to format. If not set, the current date and time will be used.
    /// When passing a string, it’s strongly recommended to use the ISO 8601 format
    /// to ensure timezones are handled correctly.
    /// </summary>
    [Parameter]
    public DateTime? Date { get; set; }

    /// <summary>
    /// The format for displaying the day.
    /// </summary>
    /// <remarks>
    /// Valid values are 'numeric' | '2-digit'
    /// </remarks>
    [Parameter]
    public string? Day { get; set; }

    /// <summary>
    /// The format for displaying the era.
    /// </summary>
    /// <remarks>
    /// Valid values are 'narrow' | 'short' | 'long'
    /// </remarks>
    [Parameter]
    public string? Era { get; set; }

    /// <summary>
    /// The format for displaying the hour.
    /// </summary>
    /// <remarks>
    /// Valid values are 'numeric' | '2-digit'
    /// </remarks>
    [Parameter]
    public string? Hour { get; set; }

    /// <summary>
    /// The format for displaying the hour.
    /// </summary>
    /// <remarks>
    /// Valid values are 'auto' | '12' | '24'
    /// </remarks>
    [Parameter]
    public string? HourFormat { get; set; }

    /// <summary>
    /// The format for displaying the minute.
    /// </summary>
    /// <remarks>
    /// Valid values are 'numeric' | '2-digit'
    /// </remarks>
    [Parameter]
    public string? Minute { get; set; }

    /// <summary>
    /// The format for displaying the month.
    /// </summary>
    /// <remarks>
    /// Valid values are 'numeric' | '2-digit' | 'narrow' | 'short' | 'long'
    /// </remarks>
    [Parameter]
    public string? Month { get; set; }

    /// <summary>
    /// The format for displaying the second.
    /// </summary>
    /// <remarks>
    /// Valid values are 'numeric' | '2-digit'
    /// </remarks>
    [Parameter]
    public string? Second { get; set; }

    /// <summary>
    /// The time zone to express the time in.
    /// </summary>
    [Parameter]
    public string? TimeZone { get; set; }

    /// <summary>
    /// The format for displaying the time.
    /// </summary>
    /// <remarks>
    /// Valid values are 'short' | 'long'
    /// </remarks>
    [Parameter]
    public string? TimeZoneName { get; set; }

    /// <summary>
    /// The format for displaying the weekday.
    /// </summary>
    /// <remarks>
    /// Valid values are 'narrow' | 'short' | 'long'
    /// </remarks>
    [Parameter]
    public string? Weekday { get; set; }

    /// <summary>
    /// The format for displaying the year.
    /// </summary>
    /// <remarks>
    /// Valid values are 'numeric' | '2-digit'
    /// </remarks>
    [Parameter]
    public string? Year { get; set; }

    #endregion Properties
}
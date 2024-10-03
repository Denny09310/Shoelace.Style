using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Formats a number as a human readable bytes value.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/format-bytes"/>
/// </remarks>
public partial class ShoelaceFormatBytes : ShoelaceComponentBase
{
    #region Properties

    /// <summary>
    /// Determines how to display the result, e.g. “100 bytes”, “100 b”, or “100b”.
    /// </summary>
    [Parameter]
    public string? Display { get; set; }

    /// <summary>
    /// The type of unit to display.
    /// </summary>
    /// <remarks>
    /// Possible values are 'byte' | 'bit'
    /// </remarks>
    [Parameter]
    public string? Unit { get; set; }

    /// <summary>
    /// The number to format in bytes.
    /// </summary>
    /// <remarks>
    /// Possible values are 'long' | 'short' | 'narrow'
    /// </remarks>
    [Parameter]
    public double? Value { get; set; }

    #endregion Properties
}

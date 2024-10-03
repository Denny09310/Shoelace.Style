using Microsoft.AspNetCore.Components;
using System.Numerics;

namespace Shoelace.Style.Components;

/// <summary>
/// Formats a number using the specified locale and options.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/format-number"/>
/// </remarks>
public partial class ShoelaceFormatNumber<T> : ShoelaceComponentBase where T : INumber<T>
{
    #region Properties

    /// <summary>
    ///	The ISO 4217 currency code to use when formatting.
    /// </summary>
    [Parameter]
    public string? Currency { get; set; }

    /// <summary>
    /// How to display the currency.
    /// </summary>
    /// <remarks>
    /// Possible values are 'symbol' | 'narrowSymbol' | 'code' | 'name'
    /// </remarks>
    [Parameter]
    public string? CurrencyDisplay { get; set; }

    /// <summary>
    /// The maximum number of fraction digits to use.
    /// </summary>
    /// <remarks>
    /// Possible values are 0–0.
    /// </remarks>
    [Parameter]
    public int? MaximumFractionDigits { get; set; }

    /// <summary>
    /// The maximum number of significant digits to use,.
    /// </summary>
    /// <remarks>
    /// Possible values are 1–21.
    /// </remarks>
    [Parameter]
    public int? MaximumSignificantDigits { get; set; }

    /// <summary>
    /// The minimum number of fraction digits to use.
    /// </summary>
    /// <remarks>
    /// Possible values are 0–20.
    /// </remarks>
    [Parameter]
    public int? MinimumFractionDigits { get; set; }

    /// <summary>
    /// The minimum number of integer digits to use.
    /// </summary>
    /// <remarks>
    /// Possible values are 1–21
    /// </remarks>
    [Parameter]
    public int? MinimumIntegerDigits { get; set; }

    /// <summary>
    /// The minimum number of significant digits to use.
    /// </summary>
    /// <remarks>
    /// Possible values are 1–21.
    /// </remarks>
    [Parameter]
    public int? MinimumSignificantDigits { get; set; }

    /// <summary>
    /// Turns off grouping separators.
    /// </summary>
    [Parameter]
    public bool NoGrouping { get; set; }

    /// <summary>
    /// The formatting style to use.
    /// </summary>
    /// <remarks>
    /// Possible values are 'currency' | 'decimal' | 'percent'
    /// </remarks>
    [Parameter]
    public string? Type { get; set; }

    /// <summary>
    /// The number to format.
    /// </summary>
    [Parameter]
    [EditorRequired]
    public T Value { get; set; } = default!;

    #endregion Properties
}
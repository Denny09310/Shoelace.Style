using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Options;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace Shoelace.Style.Components;

/// <summary>
/// Ranges allow the user to select a single value within a given range using a slider.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/range"/>
/// </remarks>
public partial class ShoelaceRange<TValue> : ShoelaceInputBase<TValue>, IFocusable
    where TValue : INumber<TValue>
{
    /// <summary>
    /// The range’s label.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// The maximum acceptable value of the range.
    /// </summary>
    [Parameter]
    public double? Max { get; set; }

    /// <summary>
    /// The minimum acceptable value of the range.
    /// </summary>
    [Parameter]
    public double? Min { get; set; }

    /// <summary>
    /// The interval at which the range will increase and decrease.
    /// </summary>
    [Parameter]
    public double? Step { get; set; }

    /// <summary>
    /// The preferred placement of the range’s tooltip.
    /// </summary>
    /// <remarks>
    /// Possible values are 'top' | 'bottom'
    /// </remarks>
    [Parameter]
    public string? Tooltip { get; set; }

    #endregion Properties

    private string? FormattedValue => Value switch
    {
        double @double => @double.ToString(CultureInfo.InvariantCulture),
        decimal @decimal => @decimal.ToString(CultureInfo.InvariantCulture),
        float @float => @float.ToString(CultureInfo.InvariantCulture),
        _ => Value?.ToString()
    };

    #region Events

    /// <inheritdoc/>
    public EventCallback OnBlur { get; set; }

    /// <inheritdoc/>
    public EventCallback OnFocus { get; set; }

    #endregion Events

    /// <summary>
    /// Handler for the OnBluer event.
    /// </summary>
    protected virtual Task BlurHandlerAsync() => OnBlur.InvokeAsync();

    /// <summary>
    /// Handler for the OnFocus event.
    /// </summary>
    protected virtual Task FocusHandlerAsync() => OnFocus.InvokeAsync();

    /// <inheritdoc/>
    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        if (BindConverter.TryConvertTo(value, CultureInfo.InvariantCulture, out result))
        {
            validationErrorMessage = null;
            return true;
        }
        else
        {
            validationErrorMessage = string.Format(CultureInfo.InvariantCulture, "The {0} field must be a number.", DisplayName ?? (FieldBound ? FieldIdentifier.FieldName : "(unknown)"));
            return false;
        }
    }

    #region Instance Properties

    /// <inheritdoc/>
    public ValueTask BlurAsync() => Element.InvokeVoidAsync("blur");

    /// <inheritdoc/>
    public ValueTask FocusAsync(FocusOptions options) => Element.InvokeVoidAsync("focus", options);

    #endregion Instance Properties
}
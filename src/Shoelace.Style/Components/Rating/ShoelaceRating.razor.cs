using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Events;
using Shoelace.Style.Options;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Shoelace.Style.Components;

/// <summary>
/// Ratings give users a way to quickly view and provide feedback.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/rating"/>
/// </remarks>
public partial class ShoelaceRating<TValue> : ShoelaceInputBase<TValue>, IFocusable
    where TValue : System.Numerics.INumber<TValue>
{
    #region Properties

    /// <summary>
    /// The highest rating to show.
    /// </summary>
    [Parameter]
    public double? Max { get; set; }

    /// <summary>
    /// The precision at which the rating will increase and decrease.
    /// For example, to allow half-star ratings, set this attribute to 0.5.
    /// </summary>
    [Parameter]
    public double? Precision { get; set; }

    /// <summary>
    /// Makes the rating readonly.
    /// </summary>
    [Parameter]
    public bool Readonly { get; set; }

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

    /// <summary>
    /// Emitted when the user hovers over a value.
    /// The phase property indicates when hovering starts, moves to a new value, or ends.
    /// The value property tells what the rating’s value would be if the user were to commit to the hovered value.
    /// </summary>
    [Parameter]
    public EventCallback<HoverEventArgs> OnHover { get; set; }

    #endregion Events

    /// <summary>
    /// Handler for the OnBlur event.
    /// </summary>
    protected virtual Task BlurHandlerAsync() => OnBlur.InvokeAsync();

    /// <summary>
    /// Handler for the OnFocus event.
    /// </summary>
    protected virtual Task FocusHandlerAsync() => OnFocus.InvokeAsync();

    /// <summary>
    /// Handler for the OnHover event.
    /// </summary>
    protected virtual Task HoverHandlerAsync(HoverEventArgs e) => OnHover.InvokeAsync(e);

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
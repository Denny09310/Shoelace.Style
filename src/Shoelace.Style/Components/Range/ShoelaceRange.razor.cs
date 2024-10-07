using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Options;

namespace Shoelace.Style.Components;

/// <summary>
/// Ranges allow the user to select a single value within a given range using a slider.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/range"/>
/// </remarks>
public partial class ShoelaceRange : ShoelaceInputBase<double>, IFocusable
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

    #region Events

    /// <inheritdoc/>
    public EventCallback OnBlur { get; set; }

    /// <inheritdoc/>
    public EventCallback OnFocus { get; set; }

    #endregion Events

    #region Instance Properties

    /// <inheritdoc/>
    public ValueTask BlurAsync() => Element.InvokeVoidAsync("blur");

    /// <inheritdoc/>
    public ValueTask FocusAsync(FocusOptions options) => Element.InvokeVoidAsync("focus", options);

    #endregion Instance Properties
}
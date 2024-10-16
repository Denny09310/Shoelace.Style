using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Options;

namespace Shoelace.Style.Components;

/// <summary>
/// Radios allow the user to select a single option from a group.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/radio"/>
/// </remarks>
/// <typeparam name="TValue">The type of the radio value</typeparam>
public partial class ShoelaceRadio<TValue> : ShoelaceComponentBase, IFocusable
{
    /// <summary>
    /// The radio’s label.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// Disables the radio.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// The radio’s size. When used inside a radio group,
    /// the size will be determined by the radio group’s size so this attribute can typically be omitted.
    /// </summary>
    /// <remarks>
    /// Possible values are 'small' | 'medium' | 'large'
    /// </remarks>
    [Parameter]
    public string? Size { get; set; }

    /// <summary>
    /// The radio’s value. When selected, the radio group will receive this value.
    /// </summary>
    [Parameter]
    [EditorRequired]
    public TValue Value { get; set; } = default!;

    #endregion Properties

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

    #region Instance Properties

    /// <inheritdoc/>
    public ValueTask BlurAsync() => Element.InvokeVoidAsync("blur");

    /// <inheritdoc/>
    public ValueTask FocusAsync(FocusOptions options) => Element.InvokeVoidAsync("focus", options);

    #endregion Instance Properties
}
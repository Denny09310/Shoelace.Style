using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Extensions;
using Shoelace.Style.Options;
using System.Diagnostics.CodeAnalysis;

namespace Shoelace.Style.Components;

/// <summary>
/// Selects allow you to choose items from a menu of predefined options.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/select"/>
/// </remarks>
/// <typeparam name="TValue">The type of the <see cref="ShoelaceSelect{T}"/> value</typeparam>
public partial class ShoelaceSelect<TValue> : ShoelaceInputBase<TValue>, IClearable, IPresentable, IFocusable
{
    /// <summary>
    /// The select main content.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <inheritdoc />
    [Parameter]
    public EventCallback<bool> OpenChanged { get; set; }

    #region Properties

    /// <inheritdoc />
    [Parameter]
    public bool Clearable { get; set; }

    /// <summary>
    /// Draws a filled select.
    /// </summary>
    [Parameter]
    public bool Filled { get; set; }

    /// <summary>
    /// Enable this option to prevent the listbox from being clipped
    /// when the component is placed inside a container with overflow: auto|scroll.
    /// Hoisting uses a fixed positioning strategy that works in many, but not all, scenarios.
    /// </summary>
    [Parameter]
    public bool Hoist { get; set; }

    /// <summary>
    /// The maximum number of selected options to show when multiple is true. After the maximum,
    /// ”+n” will be shown to indicate the number of additional items that are selected.
    /// Set to 0 to remove the limit.
    /// </summary>
    [Parameter]
    public int MaxOptionsVisible { get; set; }

    /// <summary>
    /// Allows more than one option to be selected.
    /// </summary>
    [Parameter]
    public bool Multiple { get; set; }

    /// <inheritdoc />
    [Parameter]
    public bool Open { get; set; }

    /// <summary>
    /// Draws a pill-style select with rounded edges.
    /// </summary>
    [Parameter]
    public bool Pill { get; set; }

    /// <summary>
    /// Placeholder text to show as a hint when the select is empty.
    /// </summary>
    [Parameter]
    public string? Placeholder { get; set; }

    /// <summary>
    /// The preferred placement of the select’s menu.
    /// Note that the actual placement may vary as needed to keep the listbox inside of the viewport.
    /// </summary>
    [Parameter]
    public string? Placement { get; set; }

    #endregion Properties

    #region Events

    /// <inheritdoc />
    [Parameter]
    public EventCallback OnAfterHide { get; set; }

    /// <inheritdoc />
    [Parameter]
    public EventCallback OnAfterShow { get; set; }

    /// <inheritdoc />
    [Parameter]
    public EventCallback OnBlur { get; set; }

    /// <inheritdoc />
    [Parameter]
    public EventCallback OnClear { get; set; }

    /// <inheritdoc />
    [Parameter]
    public EventCallback OnFocus { get; set; }

    /// <inheritdoc />
    [Parameter]
    public EventCallback OnHide { get; set; }

    /// <inheritdoc />
    [Parameter]
    public EventCallback OnShow { get; set; }

    #endregion Events

    /// <summary>
    /// Handler for the OnAfterHide event.
    /// </summary>
    protected virtual async Task AfterHideHandlerAsync()
    {
        Open = false;
        await OpenChanged.InvokeAsync(Open);

        await OnAfterHide.InvokeAsync();
    }

    /// <summary>
    /// Handler for the OnAfterShow event.
    /// </summary>
    protected virtual async Task AfterShowHandlerAsync()
    {
        Open = true;
        await OpenChanged.InvokeAsync(Open);

        await OnAfterShow.InvokeAsync();
    }

    /// <summary>
    /// Handler for the OnBlur event.
    /// </summary>
    protected virtual async Task BlurHandlerAsync() => await OnBlur.InvokeAsync();

    /// <summary>
    /// Handler for the OnClrar event.
    /// </summary>
    protected virtual async Task ClearHandlerAsync() => await OnClear.InvokeAsync();

    /// <summary>
    /// Handler for the OnFocus event.
    /// </summary>
    protected virtual async Task FocusHandlerAsync() => await OnFocus.InvokeAsync();

    /// <summary>
    /// Handler for the OnHide event.
    /// </summary>
    protected virtual async Task HideHandlerAsync() => await OnHide.InvokeAsync();

    /// <summary>
    /// Handler for the OnShow event.
    /// </summary>
    protected virtual async Task ShowHandlerAsync() => await OnShow.InvokeAsync();

    ///<inheritdoc/>
    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
        => this.TryParseSelectableValueFromString(value, out result, out validationErrorMessage);

    #region Instance Methods

    /// <inheritdoc />
    public ValueTask BlurAsync() => Element.InvokeVoidAsync("blur");

    /// <inheritdoc />
    public ValueTask FocusAsync(FocusOptions options) => Element.InvokeVoidAsync("focus", options);

    /// <inheritdoc />
    public ValueTask HideAsync() => Element.InvokeVoidAsync("hide");

    /// <inheritdoc />
    public ValueTask ShowAsync() => Element.InvokeVoidAsync("show");

    #endregion Instance Methods
}
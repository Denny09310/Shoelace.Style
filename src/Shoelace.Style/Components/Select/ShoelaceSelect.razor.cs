using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Options;

namespace Shoelace.Style.Components;

/// <summary>
/// Selects allow you to choose items from a menu of predefined options.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/select"/>
/// </remarks>
/// <typeparam name="T">The type of the <see cref="ShoelaceSelect{T}"/> value</typeparam>
public partial class ShoelaceSelect<T> : ShoelaceInputBase<T>, IClearable, IPresentable, IFocusable
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

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener("sl-blur", OnBlur);
            await AddEventListener("sl-clear", OnClear);

            await AddEventListener("sl-show", OnShow);
            await AddEventListener("sl-hide", OnHide);
            await AddEventListener("sl-after-show", OnAfterShow);
            await AddEventListener("sl-after-hide", OnAfterHide);

            await AddEventListener("sl-after-show", OpenChanged, converter: () => Open = true);
            await AddEventListener("sl-after-hide", OpenChanged, converter: () => Open = false);
        }
    }

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
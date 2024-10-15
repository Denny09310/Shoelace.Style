using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Shoelace.Style.Components;

/// <summary>
/// Base class for Shoelace presentables components (Eg. alerts, dialogs), extending <see cref="ShoelaceComponentBase"/>.
/// It provides support for handling additional HTML attributes, CSS classes, styles,
/// and event listeners on the component.
/// </summary>
public abstract class ShoelacePresentableBase : ShoelaceComponentBase, IPresentable
{
    /// <inheritdoc />
    [Parameter]
    public EventCallback<bool> OpenChanged { get; set; }

    #region Properties

    /// <inheritdoc />
    [Parameter]
    public bool Open { get; set; }

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
    /// Handler for the OnHide event.
    /// </summary>
    protected virtual async Task HideHandlerAsync() => await OnHide.InvokeAsync();

    /// <summary>
    /// Handler for the OnShow event.
    /// </summary>
    protected virtual async Task ShowHandlerAsync() => await OnShow.InvokeAsync();

    #region Instance Methods

    /// <inheritdoc />
    public virtual ValueTask HideAsync() => Element.InvokeVoidAsync("hide");

    /// <inheritdoc />
    public virtual ValueTask ShowAsync() => Element.InvokeVoidAsync("show");

    #endregion Instance Methods
}
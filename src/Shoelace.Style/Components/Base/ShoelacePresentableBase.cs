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

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
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
    public virtual ValueTask HideAsync() => Element.InvokeVoidAsync("hide");

    /// <inheritdoc />
    public virtual ValueTask ShowAsync() => Element.InvokeVoidAsync("show");

    #endregion Instance Methods
}
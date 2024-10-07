using Microsoft.AspNetCore.Components;
using Shoelace.Style.Events;

namespace Shoelace.Style.Components;

/// <summary>
/// The Resize Observer component offers a thin, declarative interface to the ResizeObserver API.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/resize-observer"/>
/// </remarks>
public partial class ShoelaceResizeObserver
{
    /// <summary>
    /// One or more elements to watch for resizing.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// Disables the observer.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    #endregion Properties

    #region Events

    /// <summary>
    /// Emitted when the element is resized.
    /// </summary>
    [Parameter]
    public EventCallback<ShoelaceResizeEvent> OnResize { get; set; }

    #endregion Events

    /// <inheritdoc/>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener("sl-resize", OnResize);
        }
    }
}
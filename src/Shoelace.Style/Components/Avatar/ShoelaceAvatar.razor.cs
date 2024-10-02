using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

public partial class ShoelaceAvatar : ShoelaceComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// The image source to use for the avatar.
    /// </summary>
    [Parameter]
    public string? Image { get; set; }

    /// <summary>
    /// Initials to use as a fallback when no image is available (1–2 characters max recommended).
    /// </summary>
    [Parameter]
    public string? Initials { get; set; }

    /// <summary>
    ///	A label to use to describe the avatar to assistive devices.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    /// Indicates how the browser should load the image.
    /// </summary>
    /// <remarks>
    /// Valid values are 'eager' | 'lazy'.
    /// </remarks>
    [Parameter]
    public string? Loading { get; set; }

    /// <summary>
    /// The shape of the avatar.
    /// </summary>
    /// <remarks>
    /// Valid values are 'circle' | 'square' | 'rounded'
    /// </remarks>
    [Parameter]
    public string? Shape { get; set; }

    #endregion Properties

    #region Events

    /// <summary>
    /// The image could not be loaded. 
    /// This may because of an invalid URL, a temporary network condition, or some unknown cause. 
    /// </summary>
    [Parameter]
    public EventCallback OnError { get; set; }

    #endregion Events

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener("sl-error", OnError);
        }
    }
}
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Shoelace.Style.Components;

/// <summary>
/// A component for displaying animated GIFs and WEBPs that play and pause on interaction.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/animated-image"/>
/// </remarks>
public partial class ShoelaceAnimatedImage : ShoelaceComponentBase
{
    /// <summary>
    /// Emitted when the play attribute value change.
    /// </summary>
    [Parameter]
    public EventCallback<bool> PlayChanged { get; set; }

    #region Properties

    /// <summary>
    /// A description of the image used by assistive devices.
    /// </summary>
    [Parameter]
    public string? Alt { get; set; }

    /// <summary>
    /// Plays the animation. When this attribute is removed, the animation will pause.
    /// </summary>
    [Parameter]
    public bool Play { get; set; }

    /// <summary>
    /// The path to the image to load.
    /// </summary>
    [Parameter]
    public string? Src { get; set; }

    #endregion Properties

    #region Events

    /// <summary>
    /// Emitted when the image loads successfully.
    /// </summary>
    [Parameter]
    public EventCallback OnError { get; set; }

    /// <summary>
    /// Emitted when the image fails to load.
    /// </summary>
    [Parameter]
    public EventCallback OnLoad { get; set; }

    #endregion Events

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener("sl-error", OnError);
            await AddEventListener("sl-load", OnLoad);
        }
    }

    private async Task HandleClick(MouseEventArgs e)
    {
        Play = await Element.GetPropertyAsync<bool>("play");
        await PlayChanged.InvokeAsync(Play);
    }
}
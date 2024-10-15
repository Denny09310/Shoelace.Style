using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Events;

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

    /// <summary>
    /// Handler for the OnError event
    /// </summary>
    /// <returns></returns>
    protected virtual async Task ErrorHandlerAsync() => await OnError.InvokeAsync();

    /// <summary>
    /// Handler for the OnLoad event
    /// </summary>
    /// <returns></returns>
    protected virtual async Task LoadHandlerAsync() => await OnLoad.InvokeAsync();

    private async Task PlayChangeHandlerAsync()
    {
        // TODO: Find out why the custom handler doesent work "@onplaychange"

        Play = await Element.GetPropertyAsync<bool>("play");
        await PlayChanged.InvokeAsync(Play);
    }
}
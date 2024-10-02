using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace Shoelace.Style.Components;

public partial class ShoelaceAnimatedImage : ShoelaceComponentBase
{
    [Parameter]
    public EventCallback<bool> PlayChanged { get; set; }

    #region Properties

    [Parameter]
    public string? Alt { get; set; }

    [Parameter]
    public bool Play { get; set; }

    [Parameter]
    public string? Src { get; set; }

    #endregion Properties

    #region Events

    [Parameter]
    public EventCallback OnError { get; set; }

    [Parameter]
    public EventCallback OnLoad { get; set; }

    #endregion Events

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
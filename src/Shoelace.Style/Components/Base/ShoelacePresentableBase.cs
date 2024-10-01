using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Shoelace.Style.Components;

public abstract class ShoelacePresentableBase : ShoelaceComponentBase
{
    #region Properties

    [Parameter]
    public bool Open { get; set; }

    [Parameter]
    public EventCallback<bool> OpenChanged { get; set; }

    #endregion Properties

    #region Events

    [Parameter]
    public EventCallback OnAfterHide { get; set; }

    [Parameter]
    public EventCallback OnAfterShow { get; set; }

    [Parameter]
    public EventCallback OnHide { get; set; }

    [Parameter]
    public EventCallback OnShow { get; set; }

    #endregion Events

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

    public ValueTask HideAsync() => Element.InvokeVoidAsync("hide");

    public ValueTask ShowAsync() => Element.InvokeVoidAsync("show");

    #endregion Instance Methods
}
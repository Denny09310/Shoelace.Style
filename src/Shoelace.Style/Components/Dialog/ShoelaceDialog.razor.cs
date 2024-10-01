using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Shoelace.Style.Components;

public partial class ShoelaceDialog : ShoelacePresentableBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    [Parameter]
    public string? Label { get; set; }

    [Parameter]
    public bool NoHeader { get; set; }

    #endregion Properties

    #region Events

    [Parameter]
    public EventCallback OnInitialFocus { get; set; }

    [Parameter]
    public EventCallback OnRequestClose { get; set; }

    #endregion Events

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener("sl-initial-focus", OnInitialFocus);
            await AddEventListener("sl-request-close", OnRequestClose);
        }
    }

    #region Instance Methods

    public async ValueTask<Modal> ModalAsync() => new Modal(await Element.GetPropertyAsync<IJSObjectReference>("modal"));

    #endregion Instance Methods
}

public class Modal(IJSObjectReference reference)
{
    private readonly IJSObjectReference _reference = reference;

    public ValueTask ActivateExternalAsync() => _reference.InvokeVoidAsync("activateExternal");

    public ValueTask DeactivateExternalAsync() => _reference.InvokeVoidAsync("deactivateExternal");
}
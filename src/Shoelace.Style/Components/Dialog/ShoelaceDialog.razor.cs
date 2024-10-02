using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Events;

namespace Shoelace.Style.Components;

public partial class ShoelaceDialog : ShoelacePresentableBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [CascadingParameter]
    public ShoelaceDialogProvider? Provider { get; set; }

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
    public EventCallback<ShoelaceRequestCloseEvent> OnRequestClose { get; set; }

    #endregion Events

    public ValueTask CloseAsync()
    {
        return CloseAsync(DialogResult.Ok<object?>(null));
    }

    public ValueTask CloseAsync<T>(T value)
    {
        return CloseAsync(DialogResult.Ok(value));
    }

    public async ValueTask CloseAsync(DialogResult result)
    {
        if (Id is null || Id == Guid.Empty)
        {
            throw new ArgumentException("The Id should be a valid GUID");
        }
        
        await SetOpen(false);
        await Task.Delay(125);

        Provider?.DismissInstance(Id.Value, result);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddEventListener("sl-initial-focus", OnInitialFocus);
            await AddEventListener("sl-request-close", OnRequestClose);

            await AddEventListener("sl-request-close", CloseAsync);

            if (Provider is not null)
            {
                await Task.Delay(125);
                await SetOpen(true);
            }
        }
    }

    private async Task SetOpen(bool open)
    {
        Open = open;
        await OpenChanged.InvokeAsync(open);
        await InvokeAsync(StateHasChanged);
    }

    #region Instance Methods

    public override ValueTask HideAsync()
    {
        CloseAsync();
        return base.HideAsync();
    }

    public async ValueTask<Modal> ModalAsync() => new Modal(await Element.GetPropertyAsync<IJSObjectReference>("modal"));

    #endregion Instance Methods
}

public class Modal(IJSObjectReference reference)
{
    private readonly IJSObjectReference _reference = reference;

    public ValueTask ActivateExternalAsync() => _reference.InvokeVoidAsync("activateExternal");

    public ValueTask DeactivateExternalAsync() => _reference.InvokeVoidAsync("deactivateExternal");
}
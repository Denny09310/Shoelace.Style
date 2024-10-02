using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Events;
using Shoelace.Style.Services;

namespace Shoelace.Style.Components;

/// <summary>
/// Dialogs, sometimes called “modals”, appear above the page and require the user’s immediate attention.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/dialog"/>
/// </remarks>
public partial class ShoelaceDialog : ShoelacePresentableBase
{
    /// <summary>
    /// The content of the dialog.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// The optional provider when the dialog is instantiated from the <see cref="IDialogService"/>
    /// </summary>
    [CascadingParameter]
    public ShoelaceDialogProvider? Provider { get; set; }

    #region Properties

    /// <summary>
    /// The dialog’s label as displayed in the header. 
    /// You should always include a relevant label even when using no-header, as it is required for proper accessibility.
    /// If you need to display HTML, use the label slot instead.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    /// Disables the header. This will also remove the default close button, 
    /// so please ensure you provide an easy, accessible way for users to dismiss the dialog.
    /// </summary>
    [Parameter]
    public bool NoHeader { get; set; }

    #endregion Properties

    #region Events

    /// <summary>
    /// Emitted when the dialog opens and is ready to receive focus. 
    /// Calling event.preventDefault() will prevent focusing and allow you to set it on a different element, such as an input.
    /// </summary>
    [Parameter]
    public EventCallback OnInitialFocus { get; set; }

    /// <summary>
    /// Emitted when the user attempts to close the dialog by clicking the close button, 
    /// clicking the overlay, or pressing escape. 
    /// Calling event.preventDefault() will keep the dialog open. 
    /// Avoid using this unless closing the dialog will result in destructive behavior such as data loss.
    /// </summary>
    [Parameter]
    public EventCallback<ShoelaceRequestCloseEvent> OnRequestClose { get; set; }

    #endregion Events

    /// <summary>
    /// Close the dialog and return a default value to the caller
    /// </summary>
    /// <remarks>
    /// Valid only if the modal is instantiated from the <see cref="IDialogService"/>
    /// </remarks>
    public ValueTask CloseAsync()
    {
        return CloseAsync(DialogResult.Ok<object?>(null));
    }

    /// <summary>
    /// Close the dialog and return a some <typeparamref name="T"/> value to the caller
    /// </summary>
    /// <remarks>
    /// Valid only if the modal is instantiated from the <see cref="IDialogService"/>
    /// </remarks>
    public ValueTask CloseAsync<T>(T value)
    {
        return CloseAsync(DialogResult.Ok(value));
    }

    /// <summary>
    /// Close the dialog and return a <see cref="DialogResult"/> to the caller
    /// </summary>
    /// <remarks>
    /// Valid only if the modal is instantiated from the <see cref="IDialogService"/>
    /// </remarks>
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

    /// <inheritdoc />
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

    /// <inheritdoc />
    public override async ValueTask HideAsync()
    {
        await CloseAsync();
        await base.HideAsync();
    }

    /// <summary>
    /// Exposes the internal modal utility that controls focus trapping. 
    /// To temporarily disable focus trapping and allow third-party modals spawned from an active Shoelace modal,
    /// call modal.activateExternal() when the third-party modal opens. 
    /// Upon closing, call modal.deactivateExternal() to restore Shoelace’s focus trapping.
    /// </summary>
    /// <returns>The internal structure to manage the Modal</returns>
    public async ValueTask<Modal> ModalAsync() => new Modal(await Element.GetPropertyAsync<IJSObjectReference>("modal"));

    #endregion Instance Methods
}


#pragma warning disable CS1591

public class Modal(IJSObjectReference reference)
{
    private readonly IJSObjectReference _reference = reference;

    public ValueTask ActivateExternalAsync() => _reference.InvokeVoidAsync("activateExternal");

    public ValueTask DeactivateExternalAsync() => _reference.InvokeVoidAsync("deactivateExternal");
}

#pragma warning restore CS1591
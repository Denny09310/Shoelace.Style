﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Events;
using Shoelace.Style.Services;
using System.Diagnostics;

namespace Shoelace.Style.Components;

/// <summary>
/// Dialogs, sometimes called “modals”, appear above the page and require the user’s immediate attention.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/dialog"/>
/// </remarks>
public partial class ShoelaceDialog : ShoelacePresentableBase, IAsyncDisposable
{
    private const string ScriptModule = "./_content/Shoelace.Style/scripts/shoelace-dialog-interop.js";

    private DotNetObjectReference<ShoelaceDialog>? _instance;
    private IJSObjectReference? _reference;
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
    public EventCallback<RequestCloseContext> OnRequestClose { get; set; }

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
        if (string.IsNullOrWhiteSpace(Id))
        {
            throw new ArgumentException("The Id should be a valid GUID");
        }

        await SetOpen(false);
        await Task.Delay(125);

        Provider?.DismissInstance(Id, result);
    }
    
    /// <inheritdoc/>
    public async ValueTask DisposeAsync()
    {
        _instance?.Dispose();

        if (_reference != null)
        {
            await _reference.DisposeAsync();
        }

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Handler for <see cref="OnRequestClose"/> event.
    /// </summary>
    /// <remarks>
    /// This substitute the @onslrequestclose directly on the component 
    /// with a js controlled one
    /// </remarks>
    [DebuggerHidden]
    [JSInvokable("request-close-callback")]
    public virtual async ValueTask<bool> RequestCloseHandlerAsync(RequestCloseEventArgs e)
    {
        var context = new RequestCloseContext(e);
        await OnRequestClose.InvokeAsync(context);

        if (Provider != null)
        {
            await CloseAsync(DialogResult.Cancel());
        }

        return context.Prevented;
    }

    /// <summary>
    /// Handler for <see cref="OnInitialFocus"/> event.
    /// </summary>
    /// <returns></returns>
    protected virtual Task InitialFocusHandlerAsync() => OnInitialFocus.InvokeAsync();

    /// <inheritdoc />
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", ScriptModule);

            _instance = DotNetObjectReference.Create(this);
            _reference = await module.InvokeAsync<IJSObjectReference>("init", Element, _instance);

            await module.DisposeAsync();

            if (Provider != null)
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

public class RequestCloseContext(RequestCloseEventArgs e)
{
    public RequestCloseEventArgs Event { get; } = e;
    public bool Prevented { get; private set; }
    public void PreventDefault()
    {
        Prevented = true;
    }
}

#pragma warning restore CS1591
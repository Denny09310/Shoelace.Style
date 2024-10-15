using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shoelace.Style.Events;

namespace Shoelace.Style.Components;

/// <summary>
/// Drawers slide in from a container to expose additional options and information.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/drawer/"/>
/// </remarks>
public partial class ShoelaceDrawer : ShoelacePresentableBase
{
    /// <summary>
    /// The drawer’s main content.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// By default, the drawer slides out of its containing block (usually the viewport).
    /// To make the drawer slide out of its parent element,
    /// set this attribute and add position: relative to the parent.
    /// </summary>
    [Parameter]
    public bool Contained { get; set; }

    /// <summary>
    /// The drawer’s label as displayed in the header.
    /// You should always include a relevant label even when using no-header,
    /// as it is required for proper accessibility.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    /// Removes the header. This will also remove the default close button,
    /// so please ensure you provide an easy, accessible way for users to dismiss the drawer.
    /// </summary>
    [Parameter]
    public bool NoHeader { get; set; }

    /// <summary>
    /// The direction from which the drawer will open.
    /// </summary>
    /// <remarks>
    /// Possible values are 'top' | 'end' | 'bottom' | 'start'
    /// </remarks>
    [Parameter]
    public string? Placement { get; set; }

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
    public EventCallback<RequestCloseEventArgs> OnRequestClose { get; set; }

    #endregion Events

    /// <summary>
    /// Handler for OnInitialFocuse event.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task InitialFocusHandlerAsync() => await OnInitialFocus.InvokeAsync();

    /// <summary>
    /// Handler for OnRequestClose event.
    /// </summary>
    /// <returns></returns>
    protected virtual async Task RequestCloseHandlerAsync(RequestCloseEventArgs e) => await OnRequestClose.InvokeAsync(e);

    #region Instance Methods

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
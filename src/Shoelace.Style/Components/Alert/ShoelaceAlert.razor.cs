using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Shoelace.Style.Components;

/// <summary>
/// Alerts are used to display important messages inline or as toast notifications.
/// </summary>
/// <remarks>
/// <see href="https://shoelace.style/components/alert"/>
/// </remarks>
public partial class ShoelaceAlert : ShoelacePresentableBase
{
    /// <summary>
    /// The content of the alert.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #region Properties

    /// <summary>
    /// Enables a close button that allows the user to dismiss the alert.
    /// </summary>
    [Parameter]
    public bool Closable { get; set; }

    /// <summary>
    /// Enables a countdown that indicates the remaining time the alert will be displayed. 
    /// Typically used to indicate the remaining time before a whole app refresh.
    /// </summary>
    [Parameter]
    public string? Countdown { get; set; }

    /// <summary>
    /// The length of time, in milliseconds, the alert will show before closing itself. 
    /// If the user interacts with the alert before it closes (e.g. moves the mouse over it), 
    /// the timer will restart.
    /// </summary>
    /// <remarks>
    /// Defaults to Infinity, meaning the alert will not close on its own.
    /// </remarks>
    [Parameter]
    public double? Duration { get; set; }

    /// <summary>
    /// The alert’s theme variant.
    /// </summary>
    /// <remarks>
    /// Possible values are 'primary' | 'success' | 'neutral' | 'warning' | 'danger'
    /// </remarks>
    [Parameter]
    public string? Variant { get; set; }

    #endregion Properties

    #region Instance Methods

    /// <summary>
    /// Displays the alert as a toast notification. 
    /// This will move the alert out of its position in the DOM and, when dismissed, 
    /// it will be removed from the DOM completely. By storing a reference to the alert, 
    /// you can reuse it by calling this method again. 
    /// </summary>
    /// <remarks>
    /// The returned <see cref="ValueTask"/> will resolve after the alert is hidden.
    /// </remarks>
    public ValueTask ToastAsync() => Element.InvokeVoidAsync("toast");

    #endregion Instance Methods
}
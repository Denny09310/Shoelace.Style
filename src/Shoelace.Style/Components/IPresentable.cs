using Microsoft.AspNetCore.Components;
using System.Xml.Linq;

namespace Shoelace.Style.Components;

/// <summary>
/// Abstraction for any element that needs presentation
/// </summary>
public interface IPresentable
{
    /// <summary>
    /// Emitted after the alert closes and all animations are complete.
    /// </summary>
    public EventCallback OnAfterHide { get; set; }

    /// <summary>
    /// Emitted after the alert opens and all animations are complete.
    /// </summary>
    public EventCallback OnAfterShow { get; set; }

    /// <summary>
    /// Emitted when the alert closes.
    /// </summary>
    public EventCallback OnHide { get; set; }

    /// <summary>
    /// Emitted when the alert opens.
    /// </summary>
    public EventCallback OnShow { get; set; }

    /// <summary>
    /// Indicates whether or not the alert is open.
    /// You can toggle this attribute to show and hide the alert,
    /// or you can use the <see cref="ShowAsync"/> and <see cref="HideAsync" /> methods
    /// and this attribute will reflect the alert’s open state.
    /// </summary>
    public bool Open { get; set; }

    /// <summary>
    /// Emitted when the attribute open changes.
    /// </summary>
    public EventCallback<bool> OpenChanged { get; set; }

    /// <summary>
    /// Hides the alert
    /// </summary>
    public ValueTask HideAsync();

    /// <summary>
    /// Shows the alert.
    /// </summary>
    public ValueTask ShowAsync();
}
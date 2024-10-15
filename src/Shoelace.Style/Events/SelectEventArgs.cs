namespace Shoelace.Style.Events;

/// <summary>
/// Provides data for the <c>sl-select</c> event.
/// </summary>
/// <remarks>
/// This event is typically triggered when a selection is made in a sl-menu component, passing the selected value to event handlers.
/// </remarks>
public class SelectEventArgs : EventArgs
{
    /// <summary>
    /// Gets the selected value from the event.
    /// </summary>
    public string Value { get; set; } = default!;

    /// <summary>
    /// Gets the checked state of the selected value
    /// </summary>
    public bool Checked { get; set; }
}
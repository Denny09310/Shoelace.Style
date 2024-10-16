namespace Shoelace.Style.Events;

/// <summary>
/// Provides data for the event that occurs when a tab is hidden.
/// </summary>
/// <remarks>
/// This event is typically raised when a user switches to a different tab or when the tab group programmatically hides a tab.
/// </remarks>
public class TabHideEventArgs : EventArgs
{
    /// <summary>
    /// Gets or sets the name of the tab that was hidden.
    /// </summary>
    /// <value>
    /// A string representing the name of the tab that was hidden.
    /// </value>
    public string Name { get; set; } = default!;
}

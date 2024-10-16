namespace Shoelace.Style.Events;

/// <summary>
/// Provides data for the event that occurs when a tab is shown.
/// </summary>
/// <remarks>
/// This event is typically raised when a user selects a tab or when the tab group programmatically shows a tab.
/// </remarks>
public class TabShowEventArgs : EventArgs
{
    /// <summary>
    /// Gets or sets the name of the tab that was shown.
    /// </summary>
    /// <value>
    /// A string representing the name of the tab that was shown.
    /// </value>
    public string Name { get; set; } = default!;
}

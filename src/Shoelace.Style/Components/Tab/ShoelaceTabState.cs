namespace Shoelace.Style.Components;

/// <summary>
/// Manages the state of tabs in a <see cref="ShoelaceTabGroup"/>.
/// This includes tracking the number of tabs and which tab is currently active.
/// </summary>
public class ShoelaceTabState
{
    /// <summary>
    /// Gets or sets the index of the currently active tab.
    /// </summary>
    public int ActiveIndex { get; set; }

    /// <summary>
    /// Gets or sets the name of the currently active tab.
    /// </summary>
    public string ActiveName { get; set; } = "";

    /// <summary>
    /// Indicates whether the active tab is the first tab in the group.
    /// </summary>
    public bool IsFirstActive => ActiveIndex == 0;

    /// <summary>
    /// Indicates whether the active tab is the last tab in the group.
    /// </summary>
    public bool IsLastActive => ActiveIndex == TabsCount - 1;

    /// <summary>
    /// Gets or sets the total number of tabs in the tab group.
    /// </summary>
    public int TabsCount { get; set; }
}
namespace Shoelace.Style.Events;

/// <summary>
/// Represents an event that requests the closing of a Shoelace dialog.
/// </summary>
public class RequestCloseEventArgs : EventArgs
{
    /// <summary>
    /// Gets or sets the source of the close request.
    /// This property indicates where the request originated from, such as a button click or other user action.
    /// </summary>
    public string Source { get; set; } = default!;
}

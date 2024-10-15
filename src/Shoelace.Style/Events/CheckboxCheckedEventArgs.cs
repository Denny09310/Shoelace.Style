namespace Shoelace.Style.Events;

/// <inheritdoc/>
public class CheckboxChangeEventArgs : EventArgs
{
    /// <inheritdoc/>
    public bool? Checked { get; set; }

    /// <inheritdoc/>
    public bool? Indeterminate { get; set; }
}

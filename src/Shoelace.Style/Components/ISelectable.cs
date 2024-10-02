namespace Shoelace.Style.Components;

/// <summary>
/// Abstraction for any element that needs text selection
/// </summary>
public interface ISelectable
{
    /// <summary>
    /// Selects all the text in the input.
    /// </summary>
    public ValueTask SelectAsync();

    /// <summary>
    /// Replaces a range of text with a new string.
    /// </summary>
    /// <param name="replacement">The string to replace with</param>
    /// <param name="start">The start index</param>
    /// <param name="end">The end index</param>
    /// <param name="selectMode">The selection mode. Valid values are 'select' | 'start' | 'end' | 'preserve'</param>
    /// <returns></returns>
    public ValueTask SetRangeTextAsync(string replacement, int start, int end, string selectMode);

    /// <summary>
    /// Sets the start and end positions of the text selection (0-based).
    /// </summary>
    /// <param name="selectionStart">The start index of the selection</param>
    /// <param name="selectionEnd">The end index of the selection</param>
    /// <param name="selectionDirection">The selection direction. Valid values are 'forward' | 'backward' | 'none'</param>
    /// <returns></returns>
    public ValueTask SetSelectionRangeAsync(int selectionStart, int selectionEnd, string selectionDirection);
}
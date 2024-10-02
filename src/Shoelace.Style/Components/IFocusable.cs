using Microsoft.AspNetCore.Components;
using Shoelace.Style.Options;

namespace Shoelace.Style.Components;

/// <summary>
/// Abstraction for any element that needs focus
/// </summary>
public interface IFocusable
{
    /// <summary>
    /// Emitted when the element loses focus.
    /// </summary>
    public EventCallback OnBlur { get; set; }

    /// <summary>
    /// Emitted when the element gains focus.
    /// </summary>
    public EventCallback OnFocus { get; set; }

    /// <summary>
    /// Removes focus from the element.
    /// </summary>
    /// <returns></returns>
    public ValueTask BlurAsync();

    /// <summary>
    /// Sets focus on the element.
    /// </summary>
    /// <param name="options">The options to apply to the focus event</param>
    public ValueTask FocusAsync(FocusOptions options);
}
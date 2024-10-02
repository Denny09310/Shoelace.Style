using Microsoft.AspNetCore.Components;

namespace Shoelace.Style.Components;

/// <summary>
/// Abstraction for any element that needs validation
/// </summary>
public interface IValidatable
{
    /// <summary>
    /// Emitted when the form control has been checked for validity and its constraints aren’t satisfied.
    /// </summary>
    public EventCallback OnInvalid { get; set; }

    /// <summary>
    /// Checks for validity but does not show a validation message
    /// </summary>
    /// <remarks>
    /// Returns true when valid and false when invalid.
    /// </remarks>
    public ValueTask CheckValidityAsync();

    /// <summary>
    /// Checks for validity and shows the browser’s validation message if the control is invalid.
    /// </summary>
    public ValueTask ReportValidityAsync();

    /// <summary>
    /// Sets a custom validation message. Pass an empty string to restore validity.
    /// </summary>
    /// <param name="message">The message to show on invalid</param>
    public ValueTask SetCustomValidityAsync(string message);
}
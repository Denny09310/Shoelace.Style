using Microsoft.JSInterop;

namespace Shoelace.Style.Events;

/// <summary>
/// Represents an event triggered by a hover action in the Shoelace styling framework.
/// This event contains details about the phase of the hover and a numeric value associated with the event.
/// </summary>
public class ShoelaceHoverEvent : JSEvent
{
    /// <summary>
    /// Gets or sets the phase of the hover event. 
    /// Possible values may include "start", "move", "end", etc., indicating different phases of a hover interaction.
    /// </summary>
    public string Phase { get; set; } = default!;

    /// <summary>
    /// Gets or sets a numeric value associated with the hover event. 
    /// This could represent duration, intensity, or any other metric tied to the hover interaction.
    /// </summary>
    public double Number { get; set; }
}

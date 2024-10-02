using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace Shoelace.Style.Events;

/// <summary>
/// Represents the event arguments for a Shoelace change event, providing information about the target of the change.
/// </summary>
/// <typeparam name="T">The type of the value being changed.</typeparam>
public class ShoelaceChangeEventArgs<T> : JSEvent
{
    /// <summary>
    /// Gets or sets the target element of the change event, containing the changed value and its state.
    /// </summary>
    [JsonPropertyName("target")]
    public ChangeEventTarget<T> Target { get; set; } = default!;
}

/// <summary>
/// Represents the target of a change event, holding the state and value of the change.
/// </summary>
/// <typeparam name="T">The type of the value being changed.</typeparam>
public sealed class ChangeEventTarget<T>
{
    /// <summary>
    /// Gets or sets a value indicating whether the target is checked.
    /// </summary>
    [JsonPropertyName("checked")]
    public bool Checked { get; set; }

    /// <summary>
    /// Gets or sets the value associated with the change event target.
    /// </summary>
    [JsonPropertyName("value")]
    public T Value { get; set; } = default!;
}

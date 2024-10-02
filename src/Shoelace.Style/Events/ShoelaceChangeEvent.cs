using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace Shoelace.Style.Events;

public class ShoelaceChangeEventArgs<T> : JSEvent
{
    [JsonPropertyName("target")]
    public ChangeEventTarget<T> Target { get; set; } = default!;
}

public sealed class ChangeEventTarget<T>
{
    [JsonPropertyName("checked")]
    public bool Checked { get; set; }

    [JsonPropertyName("value")]
    public T Value { get; set; } = default!;
}
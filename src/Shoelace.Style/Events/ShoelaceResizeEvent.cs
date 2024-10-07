using System.Text.Json.Serialization;

namespace Shoelace.Style.Events;

/// <summary>
/// Represents a single entry for a resize observation. 
/// Contains size details about the observed element's border box and content box.
/// </summary>
public class ResizeObserverEntry
{
    /// <summary>
    /// Gets or sets the collection of sizes representing the element's border box size.
    /// </summary>
    [JsonPropertyName("borderBoxSize")]
    public IReadOnlyCollection<ResizeObserverSize> BorderBoxSize { get; set; } = [];

    /// <summary>
    /// Gets or sets the collection of sizes representing the element's content box size.
    /// </summary>
    [JsonPropertyName("contentBoxSize")]
    public IReadOnlyCollection<ResizeObserverSize> ContentBoxSize { get; set; } = [];
}

/// <summary>
/// Internal class used for handling Shoelace component resize events.
/// Contains an array of resize observation entries.
/// </summary>
public class ShoelaceResizeEvent
{
    /// <summary>
    /// Gets or sets the array of entries representing resize events of observed elements.
    /// </summary>
    public ResizeObserverEntry[] Entries { get; set; } = [];
}

/// <summary>
/// Represents the size of an element in terms of block and inline dimensions.
/// Block size is typically the height, and inline size is the width, depending on layout direction.
/// </summary>
public class ResizeObserverSize
{
    /// <summary>
    /// Gets or sets the block size of the observed element (height in most writing modes).
    /// </summary>
    [JsonPropertyName("blockSize")]
    public double BlockSize { get; set; }

    /// <summary>
    /// Gets or sets the inline size of the observed element (width in most writing modes).
    /// </summary>
    [JsonPropertyName("inlineSize")]
    public double InlineSize { get; set; }
}

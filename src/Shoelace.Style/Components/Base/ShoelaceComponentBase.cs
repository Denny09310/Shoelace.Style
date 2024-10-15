using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Concurrent;

namespace Shoelace.Style.Components;

/// <summary>
/// Base class for Shoelace components, extending <see cref="ComponentBase"/>.
/// It provides support for handling additional HTML attributes, CSS classes, styles,
/// and event listeners on the component.
/// </summary>
public abstract class ShoelaceComponentBase : ComponentBase
{
    /// <summary>
    /// Gets or sets a collection of additional attributes that will be applied to the created element.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public virtual IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    /// Optional CSS class names. If given, these will be included in the class attribute of the component.
    /// </summary>
    [Parameter]
    public virtual string? Class { get; set; }

    /// <summary>
    /// Used to attach any user data object to the component.
    /// </summary>
    [Parameter]
    public virtual object? Data { get; set; }

    /// <summary>
    /// Represents a reference to the underlying HTML element associated with the component.
    /// </summary>
    public ElementReference Element { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the component.
    /// The value will be used as the HTML <see href="https://developer.mozilla.org/en-US/docs/Web/HTML/Global_attributes/id">global id attribute</see>.
    /// </summary>
    [Parameter]
    public string? Id { get; set; }

    /// <summary>
    /// Optional in-line styles. If given, these will be included in the style attribute of the component.
    /// </summary>
    [Parameter]
    public virtual string? Style { get; set; }
}
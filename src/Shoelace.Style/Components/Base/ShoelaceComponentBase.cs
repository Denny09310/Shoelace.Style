using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Concurrent;

namespace Shoelace.Style.Components;

/// <summary>
/// Base class for Shoelace components, extending <see cref="ComponentBase"/>.
/// It provides support for handling additional HTML attributes, CSS classes, styles,
/// and event listeners on the component.
/// </summary>
public abstract class ShoelaceComponentBase : ComponentBase, IAsyncDisposable
{
    // Stores the event callback types and their corresponding JavaScript listener IDs.
    private readonly ConcurrentDictionary<string, string> _callbacks = new();

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

    /// <summary>
    /// Asynchronously disposes the component and removes any attached event listeners.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        // Removes existing JavaScript event listeners associated with this component
        await RemoveExistingCallbacks();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Adds an event listener to the component for a specified event type.
    /// </summary>
    /// <param name="type">The type of the event (e.g., "click", "mouseover").</param>
    /// <param name="callback">The <see cref="EventCallback"/> to be invoked when the event occurs.</param>
    protected async Task AddEventListener(string type, EventCallback callback)
    {
        if (!callback.HasDelegate || Element.Context is null)
        {
            return;
        }

        // Adds the event listener via JSInterop and stores the callback ID
        var callbackId = await Element.AddEventListenerAsync(type, () => callback.InvokeAsync());
        _callbacks.TryAdd(type, callbackId);
    }

    /// <summary>
    /// Adds an event listener to the component for a specified event type with an event argument.
    /// </summary>
    /// <typeparam name="T">The type of event argument (e.g., MouseEventArgs, KeyboardEventArgs).</typeparam>
    /// <param name="type">The type of the event (e.g., "click", "input").</param>
    /// <param name="callback">The <see cref="EventCallback{T}"/> to be invoked with an argument when the event occurs.</param>
    protected async Task AddEventListener<T>(string type, EventCallback<T> callback)
    {
        if (!callback.HasDelegate || Element.Context is null)
        {
            return;
        }

        // Adds the event listener via JSInterop with a typed argument and stores the callback ID
        var callbackId = await Element.AddEventListenerAsync<T>(type, (e) => callback.InvokeAsync(e));
        _callbacks.TryAdd(type, callbackId);
    }

    /// <summary>
    /// Removes all existing event listeners from the component.
    /// </summary>
    private async Task RemoveExistingCallbacks()
    {
        if (Element.Context is null)
        {
            return;
        }

        Console.WriteLine("Disposing callback of {0}", GetType().Name);

        // Loops through all stored event listeners and removes them via JSInterop
        foreach (var callback in _callbacks)
        {
            await Element.RemoveEventListenerAsync(callback.Key, callback.Value);
        }
    }
}
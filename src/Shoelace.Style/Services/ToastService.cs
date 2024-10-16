using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Shoelace.Style.Options;

namespace Shoelace.Style.Services;

/// <summary>
/// Provides methods for displaying toast notifications with various types and options.
/// </summary>
public interface IToastService
{
    /// <summary>
    /// Disposes of the service and any associated resources asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous dispose operation.</returns>
    ValueTask DisposeAsync();

    /// <summary>
    /// Displays an error toast notification with the specified message.
    /// </summary>
    /// <param name="message">The error message to display.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ErrorAsync(string message);

    /// <summary>
    /// Displays an informational toast notification with the specified message.
    /// </summary>
    /// <param name="message">The informational message to display.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task InfoAsync(string message);

    /// <summary>
    /// Displays a success toast notification with the specified message.
    /// </summary>
    /// <param name="message">The success message to display.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task SuccessAsync(string message);

    /// <summary>
    /// Displays a toast notification with a message and optional customization.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="variant">The variant (e.g., success, error) of the toast. Defaults to null.</param>
    /// <param name="icon">The icon to display with the toast. Defaults to null.</param>
    /// <param name="duration">The duration of the toast in milliseconds. Defaults to null.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ToastAsync(string message, string? variant = null, string? icon = null, double? duration = null);

    /// <summary>
    /// Displays a toast notification with a message and optional <see cref="ToastOptions"/>.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="options">Additional options to customize the toast notification.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ToastAsync(string message, ToastOptions? options = null);

    /// <summary>
    /// Displays a warning toast notification with the specified message.
    /// </summary>
    /// <param name="message">The warning message to display.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task WarningAsync(string message);
}

/// <summary>
/// Provides an implementation of <see cref="IToastService"/> using JavaScript interop to display toast notifications.
/// </summary>
public class ToastService(IJSRuntime js) : IToastService, IAsyncDisposable
{
    private const string ScriptPath = "./_content/Shoelace.Style/scripts/shoelace-alert-interop.js";

    private readonly Lazy<ValueTask<IJSObjectReference>> _module = new(() => js.InvokeAsync<IJSObjectReference>(ScriptPath));

    /// <summary>
    /// Disposes of the <see cref="ToastService"/> asynchronously, releasing JavaScript resources.
    /// </summary>
    /// <returns>A task that represents the asynchronous dispose operation.</returns>
    public async ValueTask DisposeAsync()
    {
        if (_module.IsValueCreated)
        {
            var module = await _module.Value;
            await module.DisposeAsync();
        }
    }

    /// <inheritdoc />
    public async Task ErrorAsync(string message)
    {
        await ToastAsync(message, new ToastOptions { Variant = "danger", Icon = "x-circle" });
    }

    /// <inheritdoc />
    public async Task InfoAsync(string message)
    {
        await ToastAsync(message, new ToastOptions { Variant = "primary", Icon = "info-circle" });
    }

    /// <inheritdoc />
    public async Task SuccessAsync(string message)
    {
        await ToastAsync(message, new ToastOptions { Variant = "success", Icon = "check-circle" });
    }

    /// <inheritdoc />
    public async Task ToastAsync(string message, string? variant = null, string? icon = null, double? duration = null)
    {
        var module = await _module.Value;
        await module.InvokeVoidAsync("toast", message, new ToastOptions { Variant = variant, Duration = duration, Icon = icon });
    }

    /// <inheritdoc />
    public async Task ToastAsync(string message, ToastOptions? options = null)
    {
        var module = await _module.Value;
        await module.InvokeVoidAsync("toast", message, options);
    }

    /// <inheritdoc />
    public async Task WarningAsync(string message)
    {
        await ToastAsync(message, new ToastOptions { Variant = "warning", Icon = "exclamation-triangle" });
    }
}

/// <summary>
/// Provides extension methods for adding the <see cref="ToastService"/> to the service collection.
/// </summary>
public static class ToastServiceExtensions
{
    /// <summary>
    /// Adds the <see cref="ToastService"/> to the service collection as a scoped service.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddToastService(this IServiceCollection services)
        => services.AddScoped<IToastService, ToastService>();
}
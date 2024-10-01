using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Shoelace.Style.Options;

namespace Shoelace.Style.Services;

public interface IToastService
{
    ValueTask DisposeAsync();

    Task ErrorAsync(string message);

    Task InfoAsync(string message);

    Task SuccessAsync(string message);

    Task ToastAsync(string message, string? variant = null, string? icon = null, double? duration = null);

    Task ToastAsync(string message, ToastOptions? options = null);

    Task WarningAsync(string message);
}

public class ToastService(IJSRuntime js) : IToastService, IAsyncDisposable
{
    private const string ScriptPath = "./_content/Shoelace.Style/scripts/shoelace-alert-interop.js";

    private IJSObjectReference? module;

    public async ValueTask DisposeAsync()
    {
        if (module is not null)
        {
            await module.DisposeAsync();
        }
    }

    public async Task ErrorAsync(string message)
    {
        await ToastAsync(message, new ToastOptions { Variant = "danger", Icon = "x-circle" });
    }

    public async Task InfoAsync(string message)
    {
        await ToastAsync(message, new ToastOptions { Variant = "info", Icon = "info-circle" });
    }

    public async Task SuccessAsync(string message)
    {
        await ToastAsync(message, new ToastOptions { Variant = "success", Icon = "check-circle" });
    }

    public async Task ToastAsync(string message, string? variant = null, string? icon = null, double? duration = null)
    {
        await (await ImportModuleAsync()).InvokeVoidAsync("toast", message, new ToastOptions { Variant = variant, Duration = duration, Icon = icon });
    }

    public async Task ToastAsync(string message, ToastOptions? options = null)
    {
        await (await ImportModuleAsync()).InvokeVoidAsync("toast", message, options);
    }

    public async Task WarningAsync(string message)
    {
        await ToastAsync(message, new ToastOptions { Variant = "warning", Icon = "exclamation-triangle" });
    }

    private async Task<IJSObjectReference> ImportModuleAsync()
    {
        return module ??= await js.InvokeAsync<IJSObjectReference>("import", ScriptPath);
    }
}

public static class ToastServiceExtensions
{
    public static IServiceCollection AddToastService(this IServiceCollection services)
        => services.AddScoped<IToastService, ToastService>();
}
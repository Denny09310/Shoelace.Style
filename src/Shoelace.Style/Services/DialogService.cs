using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Shoelace.Style.Options;

namespace Shoelace.Style.Services;

public interface IDialogService
{
    event Action<DialogOptions>? DialogInstanceAdded;

    Task<DialogResult> ShowAsync<T>(string label, Dictionary<string, object>? parameters = null) where T : ComponentBase;
}

public class DialogService : IDialogService
{
    public event Action<DialogOptions>? DialogInstanceAdded;

    public async Task<DialogResult> ShowAsync<T>(string label, Dictionary<string, object>? parameters = null) where T : ComponentBase
    {
        var tcs = new TaskCompletionSource<DialogResult>();
        var content = BuildContent<T>(parameters);

        var dialogOptions = new DialogOptions(label, content, tcs);

        // Notify the provider to render the dialog
        DialogInstanceAdded?.Invoke(dialogOptions);

        // Await the result (OK/Cancel or any other user-defined result)
        var result = await tcs.Task;

        // Cast and return the result to the expected type
        return new DialogResult
        {
            IsCancelled = result.IsCancelled,
            Data = (T?)result.Data
        };
    }

    private static RenderFragment BuildContent<T>(Dictionary<string, object>? parameters) where T : ComponentBase => builder =>
    {
        int i = 0;
        builder.OpenComponent<T>(i++);
        if (parameters != null)
        {
            foreach (var parameter in parameters)
            {
                builder.AddComponentParameter(i++, parameter.Key, parameter.Value);
            }
        }
        builder.CloseComponent();
    };
}

public static class DialogServiceExtensions
{
    public static IServiceCollection AddDialogService(this IServiceCollection services)
        => services.AddScoped<IDialogService, DialogService>();
}
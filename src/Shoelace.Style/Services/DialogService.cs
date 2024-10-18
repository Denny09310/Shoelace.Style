using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Shoelace.Style.Components;
using Shoelace.Style.Utilities;
using System.Diagnostics.CodeAnalysis;

namespace Shoelace.Style.Services;

/// <summary>
/// A service for managing <see cref="ShoelaceDialog"/> components.
/// </summary>
/// <remarks>
/// This service requires a <see cref="ShoelaceDialogProvider"/> in your layout page.
/// </remarks>
public interface IDialogService
{
    /// <summary>
    /// The event to manage the added dialogs
    /// </summary>
    event Func<IDialogReference, Task>? DialogInstanceAddedAsync;

    /// <summary>
    /// The event to manage the closed dialogs
    /// </summary>
    event Action<IDialogReference, DialogResult?>? OnDialogCloseRequested;

    /// <summary>
    /// Hides an existing dialog.
    /// </summary>
    /// <param name="dialog">The reference of the dialog to hide.</param>
    void Close(IDialogReference dialog);

    /// <summary>
    /// Hides an existing dialog.
    /// </summary>
    /// <param name="dialog">The reference of the dialog to hide.</param>
    /// <param name="result">The result to include.</param>
    void Close(IDialogReference dialog, DialogResult? result);

    /// <summary>
    /// Creates a reference to a dialog.
    /// </summary>
    /// <returns>The dialog reference.</returns>
    IDialogReference CreateReference();

    /// <summary>
    /// Displays a dialog.
    /// </summary>
    /// <typeparam name="TComponent">The type of dialog to display.</typeparam>
    /// <returns>A reference to the dialog.</returns>
    IDialogReference Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>() where TComponent : IComponent;

    /// <summary>
    /// Displays a dialog with a custom title.
    /// </summary>
    /// <typeparam name="TComponent">The type of dialog to display.</typeparam>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    IDialogReference Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>(string? title) where TComponent : IComponent;

    /// <summary>
    /// Displays a dialog with a custom title and options.
    /// </summary>
    /// <typeparam name="TComponent">The type of dialog to display.</typeparam>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <param name="options">The custom display options for the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    IDialogReference Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>(string? title, DialogOptions options) where TComponent : IComponent;

    /// <summary>
    /// Displays a dialog with custom parameters.
    /// </summary>
    /// <typeparam name="TComponent">The type of dialog to display.</typeparam>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <param name="parameters">The custom parameters to set within the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    IDialogReference Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>(string? title, DialogParameters parameters) where TComponent : IComponent;

    /// <summary>
    /// Displays a dialog with custom options and parameters.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <param name="parameters">The custom parameters to set within the dialog.</param>
    /// <param name="options">The custom display options for the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    IDialogReference Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>(string? title, DialogParameters parameters, DialogOptions? options) where TComponent : IComponent;

    /// <summary>
    /// Displays a dialog.
    /// </summary>
    /// <param name="component">The type of dialog to display.</param>
    /// <returns>A reference to the dialog.</returns>
    IDialogReference Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component);

    /// <summary>
    /// Displays a dialog with a custom title.
    /// </summary>
    /// <param name="component">The type of dialog to display.</param>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    IDialogReference Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title);

    /// <summary>
    /// Displays a dialog with a custom title and options.
    /// </summary>
    /// <param name="component">The type of dialog to display.</param>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <param name="options">The custom display options for the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    IDialogReference Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title, DialogOptions options);

    /// <summary>
    /// Displays a dialog with a custom title and options.
    /// </summary>
    /// <param name="component">The type of dialog to display.</param>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <param name="parameters">The custom parameters to set within the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    IDialogReference Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title, DialogParameters parameters);

    /// <summary>
    /// Displays a dialog with a custom title, parameters, and options.
    /// </summary>
    /// <param name="component">The type of dialog to display.</param>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <param name="parameters">The custom parameters to set within the dialog.</param>
    /// <param name="options">The custom display options for the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    IDialogReference Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title, DialogParameters parameters, DialogOptions options);

    /// <summary>
    /// Displays a dialog.
    /// </summary>
    /// <typeparam name="TComponent">The dialog to display.</typeparam>
    /// <returns>A reference to the dialog.</returns>
    Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>() where TComponent : IComponent;

    /// <summary>
    /// Displays a dialog with a custom title.
    /// </summary>
    /// <typeparam name="TComponent">The dialog to display.</typeparam>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>(string? title) where TComponent : IComponent;

    /// <summary>
    /// Displays a dialog with a custom title and options.
    /// </summary>
    /// <typeparam name="TComponent">The dialog to display.</typeparam>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <param name="options">The custom display options for the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>(string? title, DialogOptions options) where TComponent : IComponent;

    /// <summary>
    /// Displays a dialog with a custom title and parameters.
    /// </summary>
    /// <typeparam name="TComponent">The dialog to display.</typeparam>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <param name="parameters">The custom parameters to set within the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>(string? title, DialogParameters parameters) where TComponent : IComponent;

    /// <summary>
    /// Displays a dialog with a custom title, parameters, and options.
    /// </summary>
    /// <typeparam name="TComponent">The dialog to display.</typeparam>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <param name="parameters">The custom parameters to set within the dialog.</param>
    /// <param name="options">The custom display options for the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>(string? title, DialogParameters parameters, DialogOptions? options) where TComponent : IComponent;

    /// <summary>
    /// Displays a dialog.
    /// </summary>
    /// <param name="component">The dialog to display.</param>
    /// <returns>A reference to the dialog.</returns>
    Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component);

    /// <summary>
    /// Displays a dialog with a custom title.
    /// </summary>
    /// <param name="component">The dialog to display.</param>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title);

    /// <summary>
    /// Displays a dialog with a custom title and options.
    /// </summary>
    /// <param name="component">The dialog to display.</param>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <param name="options">The custom display options for the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title, DialogOptions options);

    /// <summary>
    /// Displays a dialog with a custom title and parameters.
    /// </summary>
    /// <param name="component">The dialog to display.</param>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <param name="parameters">The custom parameters to set within the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title, DialogParameters parameters);

    /// <summary>
    /// Displays a dialog with a custom title, parameters, and options.
    /// </summary>
    /// <param name="component">The dialog to display.</param>
    /// <param name="title">The text at the top of the dialog.</param>
    /// <param name="parameters">The custom parameters to set within the dialog.</param>
    /// <param name="options">The custom display options for the dialog.</param>
    /// <returns>A reference to the dialog.</returns>
    Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title, DialogParameters parameters, DialogOptions options);
}

/// <summary>
/// A service for managing <see cref="ShoelaceDialog"/> components.
/// </summary>
/// <remarks>
/// This service requires a <see cref="ShoelaceDialogProvider"/> in your layout page.
/// </remarks>
public class DialogService : IDialogService
{
    /// <inheritdoc />
    public event Func<IDialogReference, Task>? DialogInstanceAddedAsync;

    /// <inheritdoc />
    public event Action<IDialogReference, DialogResult?>? OnDialogCloseRequested;

    /// <inheritdoc />
    public void Close(IDialogReference dialog)
    {
        Close(dialog, DialogResult.Ok<object?>(null));
    }

    /// <inheritdoc />
    public virtual void Close(IDialogReference dialog, DialogResult? result)
    {
        OnDialogCloseRequested?.Invoke(dialog, result);
    }

    /// <inheritdoc />
    public virtual IDialogReference CreateReference()
    {
        return new DialogReference(Identifier.NewId(), this);
    }

    /// <inheritdoc />
    public IDialogReference Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>() where T : IComponent
    {
        return Show<T>(string.Empty, DialogParameters.Default, DialogOptions.Default);
    }

    /// <inheritdoc />
    public IDialogReference Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string? title) where T : IComponent
    {
        return Show<T>(title, DialogParameters.Default, DialogOptions.Default);
    }

    /// <inheritdoc />
    public IDialogReference Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string? title, DialogOptions options) where T : IComponent
    {
        return Show<T>(title, DialogParameters.Default, options);
    }

    /// <inheritdoc />
    public IDialogReference Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string? title, DialogParameters parameters) where T : IComponent
    {
        return Show<T>(title, parameters, DialogOptions.Default);
    }

    /// <inheritdoc />
    public IDialogReference Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string? title, DialogParameters parameters, DialogOptions? options)
        where T : IComponent
    {
        return Show(typeof(T), title, parameters, options ?? DialogOptions.Default);
    }

    /// <inheritdoc />
    public IDialogReference Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component)
    {
        return Show(component, string.Empty, DialogParameters.Default, DialogOptions.Default);
    }

    /// <inheritdoc />
    public IDialogReference Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title)
    {
        return Show(component, title, DialogParameters.Default, DialogOptions.Default);
    }

    /// <inheritdoc />
    public IDialogReference Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title, DialogOptions options)
    {
        return Show(component, title, DialogParameters.Default, options);
    }

    /// <inheritdoc />
    public IDialogReference Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title, DialogParameters parameters)
    {
        return Show(component, title, parameters, DialogOptions.Default);
    }

    /// <inheritdoc />
    public IDialogReference Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title, DialogParameters parameters, DialogOptions options)
    {
        if (!typeof(IComponent).IsAssignableFrom(component))
        {
            throw new ArgumentException($"{component?.FullName} must be a Blazor IComponent");
        }

        var dialogReference = CreateReference();

        var dialogContent = DialogHelperComponent.Wrap(new RenderFragment(builder =>
        {
            var i = 0;
            builder.OpenComponent(i++, component);
            foreach (var parameter in parameters)
            {
                builder.AddAttribute(i++, parameter.Key, parameter.Value);
            }

            builder.AddComponentReferenceCapture(i, inst => { dialogReference.InjectDialog(inst); });
            builder.CloseComponent();
        }));

        var dialogInstance = new RenderFragment(builder =>
        {
            builder.OpenComponent<ShoelaceDialog>(0);
            builder.SetKey(dialogReference.Id);
            builder.AddAttribute(1, nameof(ShoelaceDialog.Label), title);
            builder.AddAttribute(2, nameof(ShoelaceDialog.NoHeader), options.NoHeader);
            builder.AddAttribute(2, nameof(ShoelaceDialog.Class), options.Class);
            builder.AddAttribute(2, nameof(ShoelaceDialog.Style), options.Style);
            builder.AddAttribute(3, nameof(ShoelaceDialog.ChildContent), dialogContent);
            builder.AddAttribute(4, nameof(ShoelaceDialog.Id), dialogReference.Id);
            builder.CloseComponent();
        });
        dialogReference.InjectRenderFragment(dialogInstance);
        DialogInstanceAddedAsync?.Invoke(dialogReference);

        return dialogReference;
    }

    /// <inheritdoc />
    public Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>() where T : IComponent
    {
        return ShowAsync<T>(string.Empty, DialogParameters.Default, DialogOptions.Default);
    }

    /// <inheritdoc />
    public Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string? title) where T : IComponent
    {
        return ShowAsync<T>(title, DialogParameters.Default, DialogOptions.Default);
    }

    /// <inheritdoc />
    public Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string? title, DialogOptions options) where T : IComponent
    {
        return ShowAsync<T>(title, DialogParameters.Default, options);
    }

    /// <inheritdoc />
    public Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string? title, DialogParameters parameters) where T : IComponent
    {
        return ShowAsync<T>(title, parameters, DialogOptions.Default);
    }

    /// <inheritdoc />
    public Task<IDialogReference> ShowAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string? title, DialogParameters parameters, DialogOptions? options) where T : IComponent
    {
        return ShowAsync(typeof(T), title, parameters, options ?? DialogOptions.Default);
    }

    /// <inheritdoc />
    public Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component)
    {
        return ShowAsync(component, string.Empty, DialogParameters.Default, DialogOptions.Default);
    }

    /// <inheritdoc />
    public Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title)
    {
        return ShowAsync(component, title, DialogParameters.Default, DialogOptions.Default);
    }

    /// <inheritdoc />
    public Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title, DialogOptions options)
    {
        return ShowAsync(component, title, DialogParameters.Default, options);
    }

    /// <inheritdoc />
    public Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title, DialogParameters parameters)
    {
        return ShowAsync(component, title, parameters, DialogOptions.Default);
    }

    /// <inheritdoc />
    public async Task<IDialogReference> ShowAsync([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string? title, DialogParameters parameters, DialogOptions options)
    {
        var dialogReference = Show(component, title, parameters, options);

        var token = new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token;
        await using (token.Register(() => dialogReference.RenderCompleteTaskCompletionSource.TrySetResult(false)))
        {
            await dialogReference.RenderCompleteTaskCompletionSource.Task;
            return dialogReference;
        }
    }

    private sealed class DialogHelperComponent : BaseHelperComponent<DialogHelperComponent>;
}

/// <summary>
/// Provides extension methods for adding dialog services to the service collection.
/// </summary>
public static class DialogServiceExtensions
{
    /// <summary>
    /// Adds the dialog service to the specified service collection as a scoped service.
    /// </summary>
    /// <param name="services">The service collection to add the dialog service to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddDialogService(this IServiceCollection services)
        => services.AddScoped<IDialogService, DialogService>();

    /// <summary>
    /// Shows a default messagebox.
    /// </summary>
    /// <param name="service"></param>
    /// <param name="message"></param>
    /// <param name="title"></param>
    /// <returns></returns>
    public static Task<IDialogReference> ShowMessageBoxAsync(this IDialogService service, string message, string title = "")
    {
        var parameters = new DialogParameters
        {
            [nameof(ShoelaceMessageBox.Message)] = message,
        };

        return service.ShowAsync<ShoelaceMessageBox>(title, parameters);
    }

    private sealed class ShoelaceMessageBox : ShoelaceComponentBase
    {
        [CascadingParameter]
        public ShoelaceDialog Dialog { get; set; } = default!;

        [Parameter]
        public string Message { get; set; } = default!;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int i = 0;

            builder.OpenElement(i++, "p");
            builder.AddContent(i++, Message);
            builder.CloseElement();

            builder.OpenElement(i++, "div");
            builder.AddAttribute(i++, "style", "display: flex; align-items: center; justify-content: end; gap: 1rem;");

            builder.OpenComponent<ShoelaceButton>(i++);
            builder.AddComponentParameter(i++, nameof(Style), "min-width: 5rem;");
            builder.AddComponentParameter(i++, nameof(ShoelaceButton.Variant), "primary");
            builder.AddComponentParameter(i++, nameof(ShoelaceButton.ChildContent), GetButtonContent("Yes"));
            builder.AddAttribute(i++, "onclick", EventCallback.Factory.Create(this, Submit));
            builder.CloseComponent();

            builder.OpenComponent<ShoelaceButton>(i++);
            builder.AddComponentParameter(i++, nameof(Style), "min-width: 5rem;");
            builder.AddComponentParameter(i, nameof(ShoelaceButton.ChildContent), GetButtonContent("No"));
            builder.AddAttribute(i, "onclick", EventCallback.Factory.Create(this, Cancel));
            builder.CloseComponent();

            builder.CloseElement();
        }

        private static RenderFragment GetButtonContent(string content)
        {
            return new RenderFragment(builder =>
            {
                int i = 0;
                builder.AddContent(i, content);
            });
        }

        private async Task Cancel() => await Dialog.CloseAsync(DialogResult.Cancel());

        private async Task Submit() => await Dialog.CloseAsync(DialogResult.Ok(true));
    }
}
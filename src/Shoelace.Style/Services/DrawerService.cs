using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Shoelace.Style.Components;
using System.Diagnostics.CodeAnalysis;

namespace Shoelace.Style.Services;

/// <summary>
/// A service for managing <see cref="ShoelaceDrawer"/> components.
/// </summary>
/// <remarks>
/// This service requires a <see cref="ShoelaceDrawerProvider"/> in your layout page.
/// </remarks>
public interface IDrawerService
{
    /// <summary>
    /// The event to manage the Drawer
    /// </summary>
    event Action<DrawerOptions>? DrawerInstanceOpen;

    /// <summary>
    /// The event to manage the closed Drawers
    /// </summary>
    event Action? OnDrawerCloseRequested;

    /// <summary>
    /// Hides an existing Drawer.
    /// </summary>
    void Close();

    /// <summary>
    /// Displays a Drawer with a custom label.
    /// </summary>
    /// <typeparam name="TComponent">The type of Drawer to display.</typeparam>
    /// <param name="label">The text at the top of the Drawer.</param>
    /// <returns>A reference to the Drawer.</returns>
    void Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>(string label) where TComponent : IComponent;

    /// <summary>
    /// Displays a Drawer with a custom label and options.
    /// </summary>
    /// <typeparam name="TComponent">The type of Drawer to display.</typeparam>
    /// <param name="label">The text at the top of the Drawer.</param>
    /// <param name="options">The custom display options for the Drawer.</param>
    /// <returns>A reference to the Drawer.</returns>
    void Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>(string label, DrawerOptions options) where TComponent : IComponent;

    /// <summary>
    /// Displays a Drawer with custom parameters.
    /// </summary>
    /// <typeparam name="TComponent">The type of Drawer to display.</typeparam>
    /// <param name="label">The text at the top of the Drawer.</param>
    /// <param name="parameters">The custom parameters to set within the Drawer.</param>
    /// <returns>A reference to the Drawer.</returns>
    void Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>(string label, DrawerParameters parameters) where TComponent : IComponent;

    /// <summary>
    /// Displays a Drawer with custom options and parameters.
    /// </summary>
    /// <typeparam name="TComponent"></typeparam>
    /// <param name="label">The text at the top of the Drawer.</param>
    /// <param name="parameters">The custom parameters to set within the Drawer.</param>
    /// <param name="options">The custom display options for the Drawer.</param>
    /// <returns>A reference to the Drawer.</returns>
    void Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>(string label, DrawerParameters parameters, DrawerOptions? options) where TComponent : IComponent;

    /// <summary>
    /// Displays a Drawer with a custom label.
    /// </summary>
    /// <param name="component">The type of Drawer to display.</param>
    /// <param name="label">The text at the top of the Drawer.</param>
    /// <returns>A reference to the Drawer.</returns>
    void Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string label);

    /// <summary>
    /// Displays a Drawer with a custom label and options.
    /// </summary>
    /// <param name="component">The type of Drawer to display.</param>
    /// <param name="label">The text at the top of the Drawer.</param>
    /// <param name="options">The custom display options for the Drawer.</param>
    /// <returns>A reference to the Drawer.</returns>
    void Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string label, DrawerOptions options);

    /// <summary>
    /// Displays a Drawer with a custom label and options.
    /// </summary>
    /// <param name="component">The type of Drawer to display.</param>
    /// <param name="label">The text at the top of the Drawer.</param>
    /// <param name="parameters">The custom parameters to set within the Drawer.</param>
    /// <returns>A reference to the Drawer.</returns>
    void Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string label, DrawerParameters parameters);

    /// <summary>
    /// Displays a Drawer with a custom label, parameters, and options.
    /// </summary>
    /// <param name="component">The type of Drawer to display.</param>
    /// <param name="label">The text at the top of the Drawer.</param>
    /// <param name="parameters">The custom parameters to set within the Drawer.</param>
    /// <param name="options">The custom display options for the Drawer.</param>
    /// <returns>A reference to the Drawer.</returns>
    void Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string label, DrawerParameters parameters, DrawerOptions options);
}

/// <summary>
/// A service for managing <see cref="ShoelaceDrawer"/> components.
/// </summary>
/// <remarks>
/// This service requires a <see cref="ShoelaceDrawerProvider"/> in your layout page.
/// </remarks>
public class DrawerService : IDrawerService
{
    /// <inheritdoc />
    public event Action<DrawerOptions>? DrawerInstanceOpen;

    /// <inheritdoc />
    public event Action? OnDrawerCloseRequested;

    /// <inheritdoc/>
    public void Close()
    {
        OnDrawerCloseRequested?.Invoke();
    }

    /// <inheritdoc />
    public void Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string label) where T : IComponent
    {
        Show<T>(label, DrawerParameters.Default, DrawerOptions.Default);
    }

    /// <inheritdoc />
    public void Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string label, DrawerOptions options) where T : IComponent
    {
        Show<T>(label, DrawerParameters.Default, options);
    }

    /// <inheritdoc />
    public void Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string label, DrawerParameters parameters) where T : IComponent
    {
        Show<T>(label, parameters, DrawerOptions.Default);
    }

    /// <inheritdoc />
    public void Show<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string label, DrawerParameters parameters, DrawerOptions? options)
        where T : IComponent
    {
        Show(typeof(T), label, parameters, options ?? DrawerOptions.Default);
    }

    /// <inheritdoc />
    public void Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string label)
    {
        Show(component, label, DrawerParameters.Default, DrawerOptions.Default);
    }

    /// <inheritdoc />
    public void Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string label, DrawerOptions options)
    {
        Show(component, label, DrawerParameters.Default, options);
    }

    /// <inheritdoc />
    public void Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string label, DrawerParameters parameters)
    {
        Show(component, label, parameters, DrawerOptions.Default);
    }

    /// <inheritdoc />
    public void Show([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] Type component, string label, DrawerParameters parameters, DrawerOptions options)
    {
        if (!typeof(IComponent).IsAssignableFrom(component))
        {
            throw new ArgumentException($"{component?.FullName} must be a Blazor IComponent");
        }

        var drawerContent = DrawerHelperComponent.Wrap(new RenderFragment(builder =>
        {
            var i = 0;
            builder.OpenComponent(i++, component);
            foreach (var parameter in parameters)
            {
                builder.AddAttribute(i++, parameter.Key, parameter.Value);
            }
            builder.CloseComponent();
        }));

        options.Label = label;
        options.RenderFragment = drawerContent;

        DrawerInstanceOpen?.Invoke(options);
    }

    private sealed class DrawerHelperComponent : BaseHelperComponent<DrawerHelperComponent>;
}

/// <summary>
/// Provides extension methods for adding dialog services to the service collection.
/// </summary>
public static class DrawerServiceExtensions
{
    /// <summary>
    /// Adds the dialog service to the specified service collection as a scoped service.
    /// </summary>
    /// <param name="services">The service collection to add the dialog service to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddDrawerService(this IServiceCollection services)
        => services.AddScoped<IDrawerService, DrawerService>();
}
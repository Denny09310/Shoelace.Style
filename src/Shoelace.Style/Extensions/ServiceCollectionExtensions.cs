using Microsoft.Extensions.DependencyInjection;
using Shoelace.Style.Services;

namespace Shoelace.Style;

/// <summary>
/// Provides extension methods for adding Shoelace style services to the service collection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Shoelace style services, including the toast and dialog services, to the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddShoelaceStyle(this IServiceCollection services)
        => services.AddToastService().AddDialogService();
}
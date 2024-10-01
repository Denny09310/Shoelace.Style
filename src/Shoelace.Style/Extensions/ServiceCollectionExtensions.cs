using Microsoft.Extensions.DependencyInjection;
using Shoelace.Style.Services;

namespace Shoelace.Style;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddShoelaceStyle(this IServiceCollection services)
        => services.AddToastService();
}

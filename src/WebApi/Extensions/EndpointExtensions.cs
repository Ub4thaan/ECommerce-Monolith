using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.WebApi.Attributes;
using Phoenix.WebApi.Endpoints;
using System.Reflection;

namespace Phoenix.WebApi.Extensions;

public static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        var assembly = typeof(EndpointExtensions).Assembly;

        foreach (var type in assembly.GetTypes())
        {
            if (!type.IsClass || type.IsAbstract)
                continue;

            if (typeof(IEndpoint).IsAssignableFrom(type))
                services.AddSingleton(typeof(IEndpoint), type);

            if (typeof(IEndpointGroup).IsAssignableFrom(type))
                services.AddSingleton(typeof(IEndpointGroup), type);
        }

        return services;
    }

    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        var serviceProvider = app.ServiceProvider;

        var groups = serviceProvider
            .GetServices<IEndpointGroup>()
            .Where(g => g.GetType().GetCustomAttribute<TagAttribute>() is null);

        foreach (var group in groups)
            group.MapEndpoints(app);

        var endpoints = serviceProvider
            .GetServices<IEndpoint>()
            .Where(e => e.GetType().GetCustomAttribute<TagAttribute>() is null);

        foreach (var endpoint in endpoints)
            endpoint.MapEndpoint(app);

        return app;
    }
}

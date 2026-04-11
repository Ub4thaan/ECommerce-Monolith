using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.WebApi.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Phoenix.WebApi.Endpoints;

public abstract class EndpointGroup : IEndpointGroup
{
    private static readonly ConcurrentDictionary<string, (IEndpointGroup[] Groups, IEndpoint[] Endpoints)> TagCache = new();

    public abstract string Tag { get; }

    public virtual void MapEndpoints(IEndpointRouteBuilder app)
    {
        var serviceProvider = app.ServiceProvider;

        var group = app.MapGroup(Tag).WithTags(Tag);

        var (cachedGroups, cachedEndpoints) = TagCache.GetOrAdd(Tag, tag =>
        {
            var groups = serviceProvider
                .GetServices<IEndpointGroup>()
                .Where(g => g.GetType().GetCustomAttribute<TagAttribute>()?.Tag == tag)
                .ToArray();

            var endpoints = serviceProvider
                .GetServices<IEndpoint>()
                .Where(e => e.GetType().GetCustomAttribute<TagAttribute>()?.Tag == tag)
                .ToArray();

            return (groups, endpoints);
        });

        foreach (var endpointGroup in cachedGroups)
        {
            if (endpointGroup != this)
                endpointGroup.MapEndpoints(group);
        }

        foreach (var endpoint in cachedEndpoints)
            endpoint.MapEndpoint(group);
    }
}

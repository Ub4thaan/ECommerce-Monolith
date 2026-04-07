using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.WebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Phoenix.WebApi.Endpoints;

public abstract class EndpointGroup : IEndpointGroup
{
    public abstract string Tag { get; }

    public virtual void MapEndpoints(IEndpointRouteBuilder app)
    {
        var serviceProvider = app.ServiceProvider;

        var group = app.MapGroup(Tag).WithTags(Tag);
        var endpintGroups = serviceProvider
            .GetServices<IEndpointGroup>()
            .Where(g => g != this && g.GetType().IsClass && !g.GetType().IsAbstract && g.GetType().GetCustomAttribute<TagAttribute>()?.Tag == Tag);

        foreach (var endpointGroup in endpintGroups)
            endpointGroup.MapEndpoints(group);

        var endpints = serviceProvider
            .GetServices<IEndpoint>()
            .Where(e => e.GetType().IsClass && !e.GetType().IsAbstract && e.GetType().GetCustomAttribute<TagAttribute>()?.Tag == Tag);

        foreach (var endpoint in endpints)
            endpoint.MapEndpoint(group);
    }
}

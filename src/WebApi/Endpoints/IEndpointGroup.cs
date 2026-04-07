using Microsoft.AspNetCore.Routing;

namespace Phoenix.WebApi.Endpoints;

internal interface IEndpointGroup
{
    string Tag { get; }
    void MapEndpoints(IEndpointRouteBuilder app);
}

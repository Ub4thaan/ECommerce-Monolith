using Microsoft.AspNetCore.Routing;

namespace Phoenix.WebApi.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}

namespace Application.Behaviors;

using Application.Results;
using MediatR;
using Microsoft.Extensions.Logging;

public sealed class LoggingBehavior<TRequest, TResponse>(
    ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        string requestName = typeof(TRequest).Name;

        logger.LogInformation("Processing request {RequestName}", requestName);

        TResponse result = await next();

        if (result.IsFailure)
        {
            logger.LogWarning(
                "Request {RequestName} completed with error: {ErrorCode} - {ErrorDescription}",
                requestName,
                result.Error.Code,
                result.Error.Description);
        }
        else
        {
            logger.LogInformation("Request {RequestName} completed successfully", requestName);
        }

        return result;
    }
}

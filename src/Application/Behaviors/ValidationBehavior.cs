namespace Application.Behaviors;

using Application.Errors;
using Application.Results;
using FluentValidation;
using MediatR;

public sealed class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        Error[] errors = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f is not null)
            .Select(f => new Error(f.PropertyName, f.ErrorMessage))
            .Distinct()
            .ToArray();

        if (errors.Length != 0)
        {
            var validationError = new ValidationError(errors);

            return ResultFactory.CreateFailure<TResponse>(validationError);
        }

        return await next();
    }
}

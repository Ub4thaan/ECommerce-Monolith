namespace Application.Behaviors;

using Application.Errors;
using Application.Results;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

public sealed class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : Result
{
    private readonly IValidator<TRequest>[] _validators = validators as IValidator<TRequest>[] ?? validators.ToArray();

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators.Length == 0)
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        ValidationResult[] validationResults;

        if (_validators.Length == 1)
        {
            validationResults = [await _validators[0].ValidateAsync(context, cancellationToken)];
        }
        else
        {
            var tasks = new Task<ValidationResult>[_validators.Length];
            for (int i = 0; i < _validators.Length; i++)
            {
                tasks[i] = _validators[i].ValidateAsync(context, cancellationToken);
            }
            validationResults = await Task.WhenAll(tasks);
        }

        var errorSet = new HashSet<Error>();
        foreach (var result in validationResults)
        {
            foreach (var failure in result.Errors)
            {
                if (failure is not null)
                {
                    errorSet.Add(new Error(failure.PropertyName, failure.ErrorMessage, ErrorType.Validation));
                }
            }
        }

        if (errorSet.Count != 0)
        {
            var errors = new Error[errorSet.Count];
            errorSet.CopyTo(errors);
            var validationError = new ValidationError(errors);

            return ResultFactory.CreateFailure<TResponse>(validationError);
        }

        return await next();
    }
}

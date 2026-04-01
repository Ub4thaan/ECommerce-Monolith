namespace Application.Errors;

using System.Reflection;

internal static class ResultFactory
{
    public static TResponse CreateFailure<TResponse>(Error error)
        where TResponse : Result
    {
        if (typeof(TResponse) == typeof(Result))
        {
            return (TResponse)(object)Result.Failure(error);
        }

        Type valueType = typeof(TResponse).GetGenericArguments()[0];

        MethodInfo failureMethod = typeof(Result)
            .GetMethod(nameof(Result.Failure), 1, [typeof(Error)])
            ?? throw new InvalidOperationException(
                $"Could not find {nameof(Result)}.{nameof(Result.Failure)}<T>({nameof(Error)}) method.");

        object result = failureMethod
            .MakeGenericMethod(valueType)
            .Invoke(null, [error])
            ?? throw new InvalidOperationException(
                $"{nameof(Result)}.{nameof(Result.Failure)}<T>({nameof(Error)}) returned null.");

        return (TResponse)result;
    }
}

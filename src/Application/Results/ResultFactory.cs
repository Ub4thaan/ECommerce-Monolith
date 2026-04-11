using Application.Errors;

namespace Application.Results;

using System.Collections.Concurrent;
using System.Reflection;

internal static class ResultFactory
{
    private static readonly ConcurrentDictionary<Type, Func<Error, Result>> FailureFactoryCache = new();

    private static readonly MethodInfo GenericFailureMethod =
        typeof(Result).GetMethod(nameof(Result.Failure), 1, [typeof(Error)])
        ?? throw new InvalidOperationException(
            $"Could not find {nameof(Result)}.{nameof(Result.Failure)}<T>({nameof(Error)}) method.");

    public static TResponse CreateFailure<TResponse>(Error error)
        where TResponse : Result
    {
        if (typeof(TResponse) == typeof(Result))
        {
            return (TResponse)(object)Result.Failure(error);
        }

        var factory = FailureFactoryCache.GetOrAdd(typeof(TResponse), static responseType =>
        {
            Type valueType = responseType.GetGenericArguments()[0];
            MethodInfo method = GenericFailureMethod.MakeGenericMethod(valueType);
            return (Error err) => (Result)method.Invoke(null, [err])!;
        });

        return (TResponse)factory(error);
    }
}

namespace Application.Queries.Abstractions;

using Application.Errors;
using MediatR;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;

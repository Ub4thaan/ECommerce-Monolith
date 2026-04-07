namespace Application.Queries.Abstractions;

using Application.Results;
using MediatR;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;

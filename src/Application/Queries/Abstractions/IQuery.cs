namespace Application.Queries.Abstractions;

using Application.Errors;
using MediatR;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;

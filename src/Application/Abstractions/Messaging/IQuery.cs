namespace Application.Abstractions.Messaging;

using Application.Errors;
using MediatR;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;

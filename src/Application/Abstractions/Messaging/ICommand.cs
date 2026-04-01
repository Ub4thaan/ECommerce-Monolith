namespace Application.Abstractions.Messaging;

using Application.Errors;
using MediatR;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;

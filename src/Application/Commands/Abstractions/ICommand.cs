namespace Application.Commands.Abstractions;

using Application.Results;
using MediatR;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;

using MediatR;
using UserService.Domain.Abstractions;

namespace UserService.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
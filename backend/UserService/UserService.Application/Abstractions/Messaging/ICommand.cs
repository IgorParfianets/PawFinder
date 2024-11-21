using MediatR;
using UserService.Domain.Abstractions;

namespace UserService.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}

public interface IBaseCommand //TODO: maybe it's unnecessary interface
{
}
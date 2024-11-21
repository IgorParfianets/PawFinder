using UserService.Application.Abstractions.Messaging;
using UserService.Domain.Abstractions;
using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.Users;
using UserService.Domain.Users.ValueObjects;

namespace UserService.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle( RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(
            new FirstName(request.FirstName),
            new LastName(request.LastName),
            new Email(request.Email));
        
        _userRepository.Add(user, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
using UserService.Application.Abstractions.Messaging;

namespace UserService.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : ICommand<Guid>;
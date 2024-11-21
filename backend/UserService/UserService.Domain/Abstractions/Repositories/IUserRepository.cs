using UserService.Domain.Users;

namespace UserService.Domain.Abstractions.Repositories;

public interface IUserRepository
{
    User Add(User entity, CancellationToken cancellationToken = default);
    
    Task<User> AddAsync(User entity, CancellationToken cancellationToken = default);
}
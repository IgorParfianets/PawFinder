using UserService.Domain.Abstractions.Repositories;
using UserService.Domain.Users;

namespace UserService.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
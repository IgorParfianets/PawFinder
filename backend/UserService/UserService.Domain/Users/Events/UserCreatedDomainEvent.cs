using UserService.Domain.Abstractions;

namespace UserService.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
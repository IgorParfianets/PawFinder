using System.Reflection;
using UserService.Application.Abstractions.Messaging;
using UserService.Domain.Abstractions;
using UserService.Infrastructure;

namespace UserService.ArchitectureTests.Base;

public class AssemblyLayers
{
    protected static readonly Assembly ApplicationAssembly = typeof(IBaseCommand).Assembly;
    
    protected static readonly Assembly DomainAssembly = typeof(Entity).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(ApplicationDbContext).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
}
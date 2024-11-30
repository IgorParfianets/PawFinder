using FluentAssertions;
using NetArchTest.Rules;
using UserService.ArchitectureTests.Base;

namespace UserService.ArchitectureTests.Layers;

public class LayerTests : AssemblyLayers
{
    [Fact]
    public void DomainLayer_ShouldNotHaveDependencyOn_AnyLayer()
    {
        var result = Types.InAssembly(DomainAssembly)
            .Should()
            .NotHaveDependencyOnAny(
                ApplicationAssembly.GetName().Name,
                InfrastructureAssembly.GetName().Name,
                PresentationAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void ApplicationLayer_ShouldHaveDependencyOn_DomainLayer() // имеет ссылку по крайней мере на Result из Domain поэтому тест не проходит
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .Should()
            .HaveDependencyOn(DomainAssembly.GetName().Name)
            .GetResult();
        
        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .Should()
            .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOn_PresentationLayer()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .Should()
            .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void InfrastructureLayer_ShouldNotHaveDependencyOn_PresentationLayer()
    {
        var result = Types.InAssembly(InfrastructureAssembly)
            .Should()
            .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}
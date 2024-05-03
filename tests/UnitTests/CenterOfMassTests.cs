using ContainerPlacementCalculator;
using FluentAssertions;

namespace ContainerPlacementUnitTests;

public class CenterOfMassTests
{
    [Fact]
    public void TestDumbAllocateBySequence1()
    {
        var containers = ContainerGenerator.RandomGenerate(27,10,0f);
        var vessel= Vessel.Build(5f, 3, 3, 3);
        ContainerAllocator.DumbAllocateBySequence(vessel, containers);
        var centerOfMass = CenterOfMassCalculator.Calculate(vessel);
        centerOfMass.X.Should().BeApproximately(7.5f, 0.01f);
        centerOfMass.Y.Should().BeApproximately(7.5f, 0.01f);
        centerOfMass.Z.Should().BeApproximately(7.5f, 0.01f);
    }

    [Fact]
    public void TestDumbAllocateBySequence2()
    {
        var containers = ContainerGenerator.RandomGenerate(64, 100, 0f);
        var vessel = Vessel.Build(50f, 4, 4, 4);
        ContainerAllocator.DumbAllocateBySequence(vessel, containers);
        var centerOfMass = CenterOfMassCalculator.Calculate(vessel);
        var expected = 50f * 4 / 2;
        centerOfMass.X.Should().BeApproximately(expected, 0.01f);
        centerOfMass.Y.Should().BeApproximately(expected, 0.01f);
        centerOfMass.Z.Should().BeApproximately(expected, 0.01f);
    }

   

}
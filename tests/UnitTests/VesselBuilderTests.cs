using ContainerPlacementCalculator;
using FluentAssertions;

namespace ContainerPlacementUnitTests;

public class VesselBuilderTests
{
   
    [Fact]
    public void BuildVesselOk()
    {
        var size = 0.1f;
        var lengthX = 3;
        var lengthY = 5;
        var lengthZ = 7;
        var x = Vessel.Build(size, lengthX, lengthY, lengthZ);
        x.Should().NotBeNull(); 
        x.Slots.GetLength(0).Should().Be(3);
        x.Slots.GetLength(1).Should().Be(5);
        x.Slots.GetLength(2).Should().Be(7);
        x.Slots[0,0,0].Should().NotBeNull();
        x.Slots[0, 0, 0].Position.X.Should().BeApproximately(size / 2, size/1000);
        x.Slots[0, 0, 0].Position.Y.Should().BeApproximately(size / 2, size / 1000);
        x.Slots[0, 0, 0].Position.Y.Should().BeApproximately(size / 2, size / 1000);

        x.Slots[2, 4, 6].Position.X.Should().BeApproximately(size /2 + size * (lengthX-1), size / 1000);
        x.Slots[2, 4, 6].Position.Y.Should().BeApproximately(size / 2 + size * (lengthY - 1), size / 1000);
        x.Slots[2, 4, 6].Position.Z.Should().BeApproximately(size / 2 + size * (lengthZ - 1), size / 1000);

    }

    [Fact]
    public void BuildVesselKOWrongSize()
    {
        var size = 0f;
        var lengthX = 3;
        var lengthY = 5;
        var lengthZ = 7;
        Action act = () => Vessel.Build(size, lengthX, lengthY, lengthZ);
        act.Should().Throw<ArgumentException>().Where(e=> e.Message.Contains("containerSize must be greater then 0, found 0"));


    }
    [Fact]
    public void BuildVesselKOWrongLengthX()
    {
        var size = 0.1f;
        var lengthX = 0;
        var lengthY = 5;
        var lengthZ = 7;
        Action act = () => Vessel.Build(size, lengthX, lengthY, lengthZ);
        act.Should().Throw<ArgumentException>().Where(e => e.Message.Contains("lengthX must be greater then 0, found 0"));


    }
    [Fact]
    public void BuildVesselKOWrongLengthY()
    {
        var size = 0.1f;
        var lengthX = 1;
        var lengthY = 0;
        var lengthZ = 7;
        Action act = () => Vessel.Build(size, lengthX, lengthY, lengthZ);
        act.Should().Throw<ArgumentException>().Where(e => e.Message.Contains("lengthY must be greater then 0, found 0"));


    }
    [Fact]
    public void BuildVesselKOWrongLengthZ()
    {
        var size = 0.1f;
        var lengthX = 1;
        var lengthY = 1;
        var lengthZ = 0;
        Action act = () => Vessel.Build(size, lengthX, lengthY, lengthZ);
        act.Should().Throw<ArgumentException>().Where(e => e.Message.Contains("lengthZ must be greater then 0, found 0"));


    }

      
}
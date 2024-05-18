using ContainerPlacementCalculator;
using FluentAssertions;
using System.Numerics;

namespace ContainerPlacementUnitTests;

public class SmartAllocationTests
{
    [Fact]
    public void TestSmart1AgainstDumb()
    {
        var slotWidth = 50f;
        int n = 4; //small change to simplify the tests (it is based on the text ‘NX NY NZ’)” 
        var numX = n;
        var numY = n;
        var numZ = n;
        var totalWidthX = slotWidth * numX;
        var totalWidthY = slotWidth * numY;

        // you might want to work on a fixed distribution of container weight 
        var containers = ContainerGenerator.RandomGenerate(n*n*n, 100, 0.1f);
        var vesselDumb = Vessel.Build(slotWidth, numX, numY, numZ);
        ContainerAllocator.DumbAllocateBySequence(vesselDumb, containers);
        var dumbCenterOfMass = CenterOfMassCalculator.Calculate(vesselDumb);

        var vesselSmart = Vessel.Build(slotWidth, numX, numY, numZ);

        ContainerAllocator.SmartAllocate1(vesselSmart, containers);
        var smartCenterOfMass = CenterOfMassCalculator.Calculate(vesselSmart);

    

        // here we check that the smart logic of distributing containers to minimize center of mass
        // is better than dumb logic that places them only by order in the provided containers list
        // that is, it is closer to the ideal center of mass

        var idealCenterOfMass = new Vector3(totalWidthX/2, totalWidthY/2, 0);
        var dumbCenterOfMassRelativeToIdealPosition = dumbCenterOfMass - idealCenterOfMass;
        var smartCenterOfMassRelativeToIdealPosition = smartCenterOfMass - idealCenterOfMass;

      

        Math.Abs(smartCenterOfMassRelativeToIdealPosition.X).Should().BeLessThan(Math.Abs(dumbCenterOfMassRelativeToIdealPosition.X));
        Math.Abs(smartCenterOfMassRelativeToIdealPosition.Y).Should().BeLessThan(Math.Abs(dumbCenterOfMassRelativeToIdealPosition.Y));
        Math.Abs(smartCenterOfMassRelativeToIdealPosition.Z).Should().BeLessThan(Math.Abs(dumbCenterOfMassRelativeToIdealPosition.Z));


    }
}
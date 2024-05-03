using System.Numerics;

namespace ContainerPlacementCalculator;

public static class CenterOfMassCalculator
{ 
    public static  Vector3 Calculate(Vessel vessel)
    {
        ArgumentNullException.ThrowIfNull(vessel);
        ArgumentNullException.ThrowIfNull(vessel.Slots);
        var lengthX = vessel.Slots.GetLength(0);
        var lengthY = vessel.Slots.GetLength(1);
        var lengthZ = vessel.Slots.GetLength(2);
        Vector3 centerOfMass= Vector3.Zero;
        float totalWeight =0f;
        for (var z = 0; z < lengthZ; z++)
        {
            for (var y = 0; y < lengthY; y++)
            {
                for (var x = 0; x < lengthX; x++)
                {
                    var slot = vessel.Slots[x, y, z];
                    var container = slot.Container;
                    if (container != null)
                    {
                        totalWeight += container.Weight;
                        centerOfMass += slot.Position * container.Weight;
                    }
                }
            }
        }
        if(totalWeight==0)
        {
            throw new ArgumentException("No container found in the slots or all containers have zero weight");
        }
        var ret = centerOfMass / totalWeight;
        return ret;
    }
}
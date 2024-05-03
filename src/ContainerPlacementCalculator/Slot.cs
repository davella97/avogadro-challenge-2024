using System.Numerics;

namespace ContainerPlacementCalculator;

public class Slot
{
    public Vector3 Position { get; init; }
    public Container? Container { get; set; }
}

public class Container
{
    public float Weight{ get; init; }
}
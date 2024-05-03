using System.Numerics;

namespace ContainerPlacementCalculator
{
    public static class ContainerAllocator
    {
        // implement this method 
        public static void SmartAllocate1(Vessel vessel, List<Container> containers)
        {
            // replace with your implementation 
            throw new NotImplementedException();    
        }
        // Do not touch this code 
        public static void DumbAllocateBySequence(Vessel vessel, List<Container> containers)
        {
            var slotsNumber = vessel.Slots.GetLength(0) * vessel.Slots.GetLength(1) * vessel.Slots.GetLength(2);
            if (containers.Count!= slotsNumber)
            {
                throw new ArgumentException($"number of containers is {containers.Count} number of slots {slotsNumber}. They are supposed ot be the same");
            }
            var lengthX = vessel.Slots.GetLength(0);
            var lengthY = vessel.Slots.GetLength(1);
            var lengthZ = vessel.Slots.GetLength(2);
            int i = 0;
            for (var z = 0; z < lengthZ; z++)
            {
                for (var y = 0; y < lengthY; y++)
                {
                    for (var x = 0; x < lengthX; x++)
                    {
                        vessel.Slots[x, y, z].Container = containers[i];    
                        i++;
                    }
                }
            }
        }
    }
}

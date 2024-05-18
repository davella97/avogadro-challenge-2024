using System.Numerics;

namespace ContainerPlacementCalculator
{
    public static class ContainerAllocator
    {
        //legend :
        //variables without '_' in front are local variables, 
        //variables with '_' in front are function parameters, 
        //variables with '__' in front are global variables.
        private static List<Container> ContainersSorter(List<Container> _containers) {
            //method that allows sorting the containers in order of weight from highest to lowest
            int nCont = _containers.Count;
            bool swap;
            do
            {
                swap = false;
                for (int i = 0; i < nCont - 1; i++)
                {
                    if (_containers[i].Weight < _containers[i + 1].Weight)
                    {
                        var temp = _containers[i];
                        _containers[i] = _containers[i + 1];
                        _containers[i + 1] = temp;

                        swap = true;
                    }
                }
                nCont--; 
            } while (swap);
            return _containers;
        }
        //DONE : implement this method
        public static void SmartAllocate1(Vessel _vessel, List<Container> _containers)
        {
            List<Container> orderedConteiners = ContainersSorter(_containers);
            var slotsNumber = _vessel.Slots.GetLength(0) * _vessel.Slots.GetLength(1) * _vessel.Slots.GetLength(2);
            if (orderedConteiners.Count != slotsNumber)
            {
                throw new ArgumentException($"number of containers is {_containers.Count} number of slots {slotsNumber}. They are supposed ot be the same");
            }
            var lengthX = _vessel.Slots.GetLength(0);
            var lengthY = _vessel.Slots.GetLength(1);
            var lengthZ = _vessel.Slots.GetLength(2);
            //DONE : generalize algorithm 
            int index = 0;
            int startCoordinate = (int) Math.Ceiling(((double) lengthX / 2) - 1);
            int lastCoordinate = lengthY / 2;
            //logic :
            //we proceed in rings from the inside (center) to the outside (outermost ring),
            //we place the heaviest boxes in the current upper left corner and then
            //the following box in the current lower right corner.
            for (int z = 0; z < lengthZ; z++) 
            {
                for (int repetition = 1; repetition < (lengthY / 2) + 1; repetition++)
                {
                    int actualSquareSide = 2 * repetition;
                    int i = 0;
                    int y1 = startCoordinate - repetition + 1;
                    int y2 = lastCoordinate + repetition - 1;
                    for (int x = 0; x < actualSquareSide && x < lengthX; x++) 
                    {
                        _vessel.Slots[(startCoordinate - repetition + 1) + i, y1,  z].Container = orderedConteiners[index];
                        index++;
                        _vessel.Slots[(lastCoordinate + repetition - 1) - i, y2, z].Container = orderedConteiners[index];
                        index++;
                        i++;
                    }
                    i = 1;
                    int x1 = startCoordinate - repetition + 1;
                    int x2 = lastCoordinate + repetition - 1;
                    for (int y = 0; y < actualSquareSide - 2 && y < lengthY; y++) 
                    {
                        _vessel.Slots[x1, (startCoordinate - repetition + 1) + i, z].Container = orderedConteiners[index];
                        index++;
                        _vessel.Slots[x2, (lastCoordinate + repetition - 1) - i, z].Container = orderedConteiners[index];
                        index++;
                        i++;
                    }
                }
            }
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

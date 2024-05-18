using System.Numerics;

namespace ContainerPlacementCalculator
{
    public static class ContainerAllocator
    {
<<<<<<< HEAD
        
        private static List<Container> containersSorter(List<Container> containers){
            Container swapContainer;
            for(int i = 0; i < containers.Count; i++){
                bool swap = false;
                for(int j = 0; j < containers.Count-i; j++){
                    if (containers[j].Weight < containers[j + 1].Weight){
                        swapContainer = containers[j];
                        containers[j] = containers[j + 1];
                        containers[j + 1] = swapContainer;
                        swap = true;
                    }
                    if (swap)
                        break;
                }
            }
            return containers;
        }
        // implement this method 
        public static void SmartAllocate1(Vessel vessel, List<Container> containers)
        {
            List<Container> orderedConteiners = containersSorter(containers);
            int lengthX = vessel.Slots.GetLength(0);
            int lengthY = vessel.Slots.GetLength(1);
            int lengthZ = vessel.Slots.GetLength(2);
            var slotsNumber = lengthX * lengthY * lengthZ;
            if (containers.Count != slotsNumber){
                throw new ArgumentException($"number of containers is {containers.Count} number of slots {slotsNumber}. They are supposed to be the same");
            }
            int maxLevelCapacity = lengthX * lengthY;
            //TODO : controllo forma (rettangolo)
            //TODO : controllo centro forma (dimensione -es 2x2 o 1x1- e coordinate)
            //TODO : algoritmo per posizionare i container. Logica pensata : 
            //       I container più pesanti al centro, si fa a strato di cipolla, si parte dal centro, si sviluppa in verticale e poi si passa ad uno strato più esterno.
            int index = 0;
                int startCoordinate = (lengthX / 2) - 1;
                int lastCoordinate = lengthY / 2;
                for(int z = 0; z < lengthZ; z++) //anello attuale preso in considerazione, da interno verso esterno 
                {
                    for (int repetition = 1; repetition < (lengthY / 2) + 1; repetition++)
                    {
                        int actualSquareSide = 2 * repetition;
                        int i = 0;
                        int y1 = startCoordinate - repetition + 1;
                        int y2 = lastCoordinate + repetition - 1;
                        for (int x = 0; x < actualSquareSide; x++) //deve fare tutti i container sulle x (sia al fondo che all'inizio)
                        {
                            vessel.Slots[z, y1, (startCoordinate - repetition + 1) + i].Container = orderedConteiners[index];
                            index++;
                            vessel.Slots[z, y2, (lastCoordinate + repetition - 1) - i].Container = orderedConteiners[index];
                            index++;
                            i++;
                        }
                        i = 1;
                        int x1 = startCoordinate - repetition + 1;
                        int x2 = lastCoordinate + repetition - 1;
                        for (int y = 0; y < actualSquareSide-2; y++) //deve fare tutti i container sulle x (sia al fondo che all'inizio)
                        {
                            vessel.Slots[z, (startCoordinate - repetition + 1) + i, x1] .Container = orderedConteiners[index];
                            index++;
                            vessel.Slots[z, (lastCoordinate + repetition - 1) - i, x2].Container = orderedConteiners[index];
                            index++;
                            i++;
                        }
                    }
                }
            

            /*    int index = 0;
                for(int i = 0; i < orderedConteiners.Capacity; i++)
                {
                    Console.WriteLine(orderedConteiners[i].Weight);
                }
                for (var z = 0; z < lengthZ; z++){
    
                    for (int x = 0; x < lengthX / 2; x++)
                    {
                        for (int y = 0; y < lengthY; y++)
                        {
                            vessel.Slots[x, y, z].Container = orderedConteiners[index];
                            index += 2;
                        }
                    }
                    index = orderedConteiners.Capacity-1;
                    for (int x = lengthX / 2; x < lengthX; x++)
                    {
                        for (int y = 0; y < lengthY; y++)
                        {
                            vessel.Slots[x, y, z].Container = orderedConteiners[index];
                            index -= 2;
                        }
                    }
                }  */
=======
        private static List<Container> containersSorter(List<Container> containers){
    Container swapContainer;
    for(int i = 0; i < containers.Count; i++){
        bool swap = false;
        for(int j = 0; j < containers.Count; j++){
            if (containers[j].Weight < containers[j + 1].Weight){
                swapContainer = containers[j];
                containers[j] = containers[j + 1];
                containers[j + 1] = swapContainer;
                swap = true;
            }
            if (swap)
                break;
>>>>>>> 55b9e43560f578e8ca2e297568d758a514443f37
        }
    }
    return containers;
}
public static void SmartAllocate1(Vessel vessel, List<Container> containers)
{
    List<Container> orderedConteiners = containersSorter(containers);
    int lengthX = vessel.Slots.GetLength(0);
    int lengthY = vessel.Slots.GetLength(1);
    int lengthZ = vessel.Slots.GetLength(2);
    var slotsNumber = lengthX * lengthY * lengthZ;
    if (containers.Count != slotsNumber){
        throw new ArgumentException($"number of containers is {containers.Count} number of slots {slotsNumber}. They are supposed to be the same");
    }
    int maxLevelCapacity = lengthX * lengthY;
    //TODO : controllo forma (rettangolo)
    //TODO : controllo centro forma (dimensione -es 2x2 o 1x1- e coordinate)
    //TODO : generalizzare algoritmo
    //TODO : algoritmo per posizionare i container. Logica pensata : 
    //       I container più pesanti al centro, si fa a strato di cipolla, si parte dal centro, si sviluppa in verticale e poi si passa ad uno strato più esterno.
    int flagForm = 1;
    int index = 0;
    int startCoordinate = Math.Ceiling(lengthX / 2) ;
    int lastCoordinate = Math.Ceiling(lengthY / 2);
    if (lengthX % 2 == 0 && lengthY % 2 == 0) //controllo se il centro è un 2x2 o un 1x1
    {
        int startCoordinate = (lengthX / 2) - 1;
        int lastCoordinate = lengthY / 2;
    }
    if(flagForm == 0)
    {
        int startCoordinate = (lengthX / 2) - 1;
        int lastCoordinate = lengthY / 2;
        for(int z = 0; z < lengthZ; z++) //anello attuale preso in considerazione, da interno verso esterno 
        {
            for (int repetition = 1; repetition < (lengthY/2)+1; repetition++ ) {
                int actualSquareSide = 2 * repetition;
                int i = 0;
                for (int x = 0; x < actualSquareSide || x < lengthX; x++) //deve fare tutti i container sulle x (sia al fondo che all'inizio)
                {
                    int y1 = startCoordinate - repetition + 1;
                    int y2 = lastCoordinate + repetition - 1;
                    vessel.Slots[(startCoordinate-repetition+1)+i, y1, z].Container = orderedConteiners[index];
                    index++;
                    vessel.Slots[(lastCoordinate+repetition-1)-i, y2, z].Container = orderedConteiners[index];
                    index++;
                    i++;
                }
                i = 1;
                for (int y = 0; y < actualSquareSide-2 || y < lengthY; y++) //deve fare tutti i container sulle y (sia al fondo che all'inizio)
                {
                    int x1 = startCoordinate - repetition + 1;
                    int x2 = lastCoordinate + repetition - 1;
                    vessel.Slots[x1 + i, (startCoordinate - repetition + 1) + i, z].Container = orderedConteiners[index];
                    index++;
                    vessel.Slots[x2 - i, (lastCoordinate + repetition - 1) - i, z].Container = orderedConteiners[index];
                    index++;
                    i++;
                }
            }
        }
    }

    /*    int index = 0;
        for(int i = 0; i < orderedConteiners.Capacity; i++)
        {
            Console.WriteLine(orderedConteiners[i].Weight);
        }
        for (var z = 0; z < lengthZ; z++){
    
            for (int x = 0; x < lengthX / 2; x++)
            {
                for (int y = 0; y < lengthY; y++)
                {
                    vessel.Slots[x, y, z].Container = orderedConteiners[index];
                    index += 2;
                }
            }
            index = orderedConteiners.Capacity-1;
            for (int x = lengthX / 2; x < lengthX; x++)
            {
                for (int y = 0; y < lengthY; y++)
                {
                    vessel.Slots[x, y, z].Container = orderedConteiners[index];
                    index -= 2;
                }
            }
        }  */
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

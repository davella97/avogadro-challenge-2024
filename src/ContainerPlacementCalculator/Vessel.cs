using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ContainerPlacementCalculator
{
    public class Vessel
    {
        private Vessel() { }
        public Slot[,,] Slots { get; private init; } = new Slot[0, 0, 0];
        public static Vessel Build(float containerSize, int lengthX, int lengthY, int lengthZ)
        {
            if(containerSize<=0)
            {
                throw new ArgumentException($"containerSize must be greater then 0, found {containerSize}");
            }
            if (lengthX <= 0)
            {
                throw new ArgumentException($"lengthX must be greater then 0, found {lengthX}");
            }
            if (lengthY <= 0)
            {
                throw new ArgumentException($"lengthY must be greater then 0, found {lengthY}");
            }
            if (lengthZ <= 0)
            {
                throw new ArgumentException($"lengthZ must be greater then 0, found {lengthZ}");
            }
            var vessel = new Vessel
            {
                Slots = new Slot[lengthX, lengthY, lengthZ]
            };
            for (var z = 0; z < lengthZ; z++)
            {
                for (var y = 0; y < lengthY; y++)
                {
                    for (var x = 0; x < lengthX; x++)
                    {
                        vessel.Slots[x, y, z] = new Slot
                        {
                            Position = new Vector3(containerSize / 2 + x * containerSize
                            , containerSize / 2 + y * containerSize
                            , containerSize / 2 + z * containerSize),
                        };
                    }
                }
            }
            return vessel;
        }
        
    }
}

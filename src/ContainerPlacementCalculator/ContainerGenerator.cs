using System;

namespace ContainerPlacementCalculator;

public static class ContainerGenerator
{
    private static Random  _random = new ();
    public static List<Container> RandomGenerate(int totalNumber, float averageWeight, float percentageVariationAcrossAverageWeight)
    {
        List<Container> containers = new ();
        for(int c = 0; c < totalNumber;c++)
        {
            var relativeRange = percentageVariationAcrossAverageWeight / 2;
            var absoluteRange = (int)(relativeRange * averageWeight);
            containers.Add(new Container { Weight = averageWeight + _random.Next(-1 * absoluteRange, absoluteRange + 1)});   
        }
        return containers;
    }
}
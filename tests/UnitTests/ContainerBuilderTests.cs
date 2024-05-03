using ContainerPlacementCalculator;
using FluentAssertions;

namespace ContainerPlacementUnitTests
{
    public class ContainerBuilderTests
    {
        [Fact]
        public void BuildContainerSet()
        {
            var containers = ContainerGenerator.RandomGenerate(50, 100, 0.1f);
            containers.Should().NotBeNull();
            containers.Should().HaveCount(50);
            var range = 100 * 0.1f / 2;
            containers.Any(c => c.Weight > 100 + range + 1).Should().BeFalse();
            containers.Any(c => c.Weight < 100 - (range + 1)).Should().BeFalse();
            containers.Where(c => c.Weight == 20).Should().NotHaveCount(50);


        }
    }
}

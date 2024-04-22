using ContainerPlacementCalculator;
using FluentAssertions;

namespace UnitTests
{
    public class UnitTestExample
    {
        [Fact]
        public void Test1()
        {
            var x = new Calculator();
            var response = x.MakeUpper("a");
            response.Should().Be("A");  
        }
    }
}
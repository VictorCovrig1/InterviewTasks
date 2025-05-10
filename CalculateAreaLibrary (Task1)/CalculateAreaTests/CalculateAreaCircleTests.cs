using CalculateAreaLibrary.Abstraction;
using CalculateAreaLibrary.Implementation;

namespace CalculateAreaTests
{
    public class CalculateAreaCircleTests
    {
        [Fact]
        public void ShouldGetCorrectArea()
        {
            IAreaCalculator circle = new CircleAreaCalculator(4);
            double area = circle.CalculateArea(2);

            Assert.Equal(50.24, area, 2);
        }

        [Theory]
        [InlineData(-6)] // Case when radius is negative
        [InlineData(0)] // Case when radius is 0
        public void ShouldThrowArgumentExceptionIfRadiusIsNegativeOr0(int radius)
            => Assert.Throws<ArgumentException>(() => new CircleAreaCalculator(radius));
    }
}

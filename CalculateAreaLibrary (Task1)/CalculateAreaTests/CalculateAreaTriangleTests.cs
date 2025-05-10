using CalculateAreaLibrary.Abstraction;
using CalculateAreaLibrary.Implementation;

namespace CalculateAreaTests
{
    public class CalculateAreaTriangleTests
    {
        [Theory]
        [InlineData(3, 3, 3, 3.9, 1)] // Case when triangle is equilateral
        [InlineData(10, 7, 12.2, 35, 0)] // Case when triangle is right
        [InlineData(3, 10, 10, 14.83, 2)] // Case when triangle has 2 bigger sides equal
        [InlineData(3, 4, 5, 6, 0)] // Case when triangle is not equilateral and not right
        public void ShouldGetCorrectArea
            (double side1, double side2, double side3, double expected, int precision)
        {
            IAreaCalculator circle = new TriangleAreaCalculator(side1, side2, side3);
            double area = circle.CalculateArea(precision);

            Assert.Equal(expected, area, precision);
        }

        [Theory]
        [InlineData(-6, 1, 3)] // Case when one of the sides is negative
        [InlineData(4, 0, 3)] // Case when one of the sides is 0
        [InlineData(1, 1, 2)] // Case when the sides can't form a triangle
        public void ShouldThrowArgumentExceptionIfTheSidesAreInvalid(int side1, int side2, int side3)
            => Assert.Throws<ArgumentException>(() => new TriangleAreaCalculator(side1, side2, side3));
    }
}

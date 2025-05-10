using CalculateAreaLibrary.Abstraction;

namespace CalculateAreaLibrary.Implementation
{
    public class TriangleAreaCalculator : IAreaCalculator
    {
        // Declare sides as list, for simplicity of work
        private List<double> _sides { get; set; }

        // Introduce sides as separate arguments, to avoid passing more or less than 3 sides
        public TriangleAreaCalculator(double side1, double side2, double side3)
        {
            // In case at least one of sides is negative or zero, should throw exception
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
                throw new ArgumentException("Triangle sides should be positive.");

            // In case the passed arguments can't form a triangle, should throw exception
            if (side1 + side2 <= side3 || side2 + side3 <= side1 || side1 + side3 <= side2)
                throw new ArgumentException("Triangle should be valid.");

            _sides = new List<double>() { side1, side2, side3 };
        }

        public double CalculateArea(int precision = 0)
        {
            double area = 0;

            // Check if triangle is equilateral
            if (_sides[0] == _sides[1] && _sides[1] == _sides[2]) 
            {
                // In that case area should be calculated using the formula: sqrt(3) / 4 * side ^ 2
                area = Math.Sqrt(3) / 4 * Math.Pow(_sides[0], 2);

                // Return the area using the precision passed as argument
                return Math.Round(area, precision);
            }

            // Check if triangle is right
            // Sort the sides list to determine hypotenuse and adjacent sides
            _sides.Sort();

            // In case we have 2 bigger sides that are equal (ex. 1, 3, 3) the triangle is not right
            if (_sides[1] != _sides[2])
            {
                // Calculate sum of square root of adjacent sides and square root of hypotenuse
                // (assuming that side1 and side2 are adjacent sides)
                double adjacentSquaresSum = Math.Pow(_sides[0], 2) + Math.Pow(_sides[1], 2);
                double hypotenuseSquare = Math.Pow(_sides[2], 2);

                // Verify that triangle is right by applying the Pythagoras theorem
                if (Math.Round(adjacentSquaresSum, precision) == Math.Round(hypotenuseSquare, precision))
                {
                    // Area in that case is side1 * side2 / 2
                    area = _sides[0] * _sides[1] / 2;
                    return Math.Round(area, precision);
                }
            }

            // In case if the triangle is not equilateral and is not right applying Heron's formula
            double semiperimeter = _sides.Sum() / 2;
            area = Math.Sqrt(semiperimeter * (semiperimeter - _sides[0]) *
                (semiperimeter - _sides[1]) * (semiperimeter - _sides[2]));

            return Math.Round(area, precision);
        }
    }
}

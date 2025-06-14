using CalculateAreaLibrary.Abstraction;

namespace CalculateAreaLibrary.Implementation
{
    public class CircleAreaCalculator : IAreaCalculator
    {
        // The private property "radius" is declared with double, to allow both integer and floating-pointed numbers
        private double _radius { get; set; }

        public CircleAreaCalculator(double radius)
        {
            // In case radius is negative (invalid data) should throw exception
            if (radius <= 0)
                throw new ArgumentException("Radius should be positive.");;

            // Initiate radius with the value passed from constructor
            _radius = radius;
        }

        public double CalculateArea(int precision = 0)
        {
            // Circle area is calculated from formula: pi * radius ^ 2 
            double area = Math.Pow(_radius, 2) * Constants.PI;
            // The result is returned rounded with precision passed as argument 
            return Math.Round(area, precision);
        }
    }
}

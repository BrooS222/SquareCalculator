using System;
using NUnit.Framework;
using SquareCalculator.Figures;

namespace Tests
{
    public class CircleTest
    {
        private const double Epsilon = 1.0e-6d;

        [TestCase(0d)]
        [TestCase(-1d)]
        public void InvalidRadiusTest(double radius)
        {
            Assert.Catch<ArgumentException>((() => new Circle(radius)));
        }
        
        [Test]
        public void SquareTest()
        {
            double radius = 10d;
            double expectedSquare = Math.PI * (radius * radius);
            Circle circle = new Circle(radius);
            
            var square = circle.GetSquare();
            
            Assert.Less(Math.Abs(square - expectedSquare), Epsilon);
        }
    }
}
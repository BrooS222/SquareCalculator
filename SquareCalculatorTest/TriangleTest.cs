using System;
using SquareCalculator.Figures;
using NUnit.Framework;

namespace Tests
{
    public class TriangleTest
    {
        private const double Epsilon = 1.0e-6d;

        [TestCase(0, 0, 0)]
        [TestCase(-1, 0, 0)]
        [TestCase(0, -1, 0)]
        [TestCase(0, 0, -1)]
        public void InvalidArgumentTest(double a, double b, double c)
        {
            Assert.Catch<ArgumentException>((() => new Triangle(a, b, c)));
        }

        [Test]
        public void SquareTest()
        {
            double edgeA = 3d, edgeB = 4d, edgeC = 5d;
            double expectedSquare = 6d;
            Triangle triangle = new Triangle(edgeA, edgeB, edgeC);

            var square = triangle.GetSquare();

            Assert.Less(Math.Abs(square - expectedSquare), Epsilon);
        }

        [TestCase(3d, 4d, 5d, ExpectedResult = TriangleType.Right)]
        [TestCase(7d, 8d, 12d, ExpectedResult = TriangleType.Obtuse)]
        [TestCase(8d, 10d, 12d, ExpectedResult = TriangleType.Acute)]
        public TriangleType TriangleTypeTest(double a, double b, double c)
        {
            Triangle triangle = new Triangle(a, b, c);

            var result = triangle.Type;

            return result;
        }
    }
}
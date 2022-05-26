namespace SquareCalculator.Figures
{
    public class Circle : IGeometryFigure
    {
        public static double MinRadius = 1.0e-4d;
        public double Radius { get; private set; }

        public Circle(double radius)
        {
            if (radius < MinRadius)
                throw new ArgumentException("Указан неверный радиус.", nameof(radius));
            
            Radius = radius;
        }
        
        public double GetSquare()
        {
            return Math.PI * (Radius * Radius);
        }
    }
}
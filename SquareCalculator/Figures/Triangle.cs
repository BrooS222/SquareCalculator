namespace SquareCalculator.Figures
{
    public class Triangle : IGeometryFigure
    {
        private const double Epsilon = 1.0e-4d;
        
        public double EdgeA { get; }
        public double EdgeB { get; }
        public double EdgeC { get; }
        public TriangleType Type { get; private set; }
        
        public Triangle(double edgeA, double edgeB, double edgeC)
        {
            if (edgeA < Epsilon)
                throw new ArgumentException("Неверно указана длина стороны.", nameof(edgeA));

            if (edgeB < Epsilon)
                throw new ArgumentException("Неверно указана длина стороны.", nameof(edgeB));

            if (edgeC < Epsilon)
                throw new ArgumentException("Неверно указана длина стороны.", nameof(edgeC));
            
            
            double maxEdge = edgeA;

            if (edgeB > maxEdge)
                (maxEdge, edgeB) = (edgeB, maxEdge);

            if (edgeC > maxEdge)
                (maxEdge, edgeC) = (edgeC, maxEdge);

            EdgeA = maxEdge;
            EdgeB = edgeB;
            EdgeC = edgeC;
            
            InitializeTriangleType();
        }
        
        public bool IsRight => Type == TriangleType.Right;
        public bool IsAcute => Type == TriangleType.Acute;
        public bool IsObtuse => Type == TriangleType.Obtuse;
        
        public double GetSquare()
        {
            double halfPerimeter = (EdgeA + EdgeB + EdgeC) * .5d;
            double square = Math.Sqrt(halfPerimeter
                                      * (halfPerimeter - EdgeA)
                                      * (halfPerimeter - EdgeB) 
                                      * (halfPerimeter - EdgeC));

            return square;
        }
        
        private void InitializeTriangleType()
        {
            if (Math.Abs((EdgeA * EdgeA) - ((EdgeB * EdgeB) + (EdgeC * EdgeC))) < Epsilon)
                Type = TriangleType.Right;
            else if ((EdgeA * EdgeA) < (EdgeB * EdgeB) + (EdgeC * EdgeC))
                Type = TriangleType.Acute;
            else
                Type = TriangleType.Obtuse;
        }
    }

    public enum TriangleType
    {
        Right,
        Acute,
        Obtuse
    }
}
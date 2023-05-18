namespace Geometry
{
    /// \brief Class for calculating the perimeter of a triangle
	///	\version b0.1
	///	\date May 15 2023
    /// \warning This class is for educational purposes only!
    /// 
    /// \details This class is created to calculate the perimeter with the following methods:
    ///             1 . On three sides.
    ///             2. If it`s rights triangle


    public class Triangle : ITriangle
    {
        private double eps = Constants.CalculationAccuracy; ///< Mathematical_precision_constant

        ///Основной метод класса
        public Triangle(double edgeA, double edgeB, double edgeC)
        {
            if (edgeA < eps)
                throw new ArgumentException("Side specified incorrectly.", nameof(edgeA));

            if (edgeB < eps)
                throw new ArgumentException("Side specified incorrectly.", nameof(edgeB));

            if (edgeC < eps)
                throw new ArgumentException("Side specified incorrectly.", nameof(edgeC));

            var maxEdge = Math.Max(edgeA, Math.Max(edgeB, edgeC));
            var perimeter = edgeA + edgeB + edgeC;
            if ((perimeter - maxEdge) - maxEdge < Constants.CalculationAccuracy)
                throw new ArgumentException("The longest side of the triangle must be less than the sum of the other sides.");

            EdgeA = edgeA;
            EdgeB = edgeB;
            EdgeC = edgeC;

            _isRightTriangle = new Lazy<bool>(GetIsRightTriangle);
        }

        public double EdgeA { get; }
        public double EdgeB { get; }
        public double EdgeC { get; }

        private readonly Lazy<bool> _isRightTriangle;
        public bool IsRightTriangle => _isRightTriangle.Value;

        private bool GetIsRightTriangle()
        {
            double maxEdge = EdgeA, b = EdgeB, c = EdgeC;
            if (b - maxEdge > Constants.CalculationAccuracy)
                Utils.Swap(ref maxEdge, ref b);

            if (c - maxEdge > Constants.CalculationAccuracy)
                Utils.Swap(ref maxEdge, ref c);

            return Math.Abs(Math.Pow(maxEdge, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) < Constants.CalculationAccuracy;
        }

        public double GetSquare()
        {
            var halfP = (EdgeA + EdgeB + EdgeC) / 2;
            return Math.Sqrt(halfP * (halfP - EdgeA) * (halfP - EdgeB) * (halfP - EdgeC));
        }
    }
}
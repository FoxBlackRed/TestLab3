namespace Geometry
{
    /// \brief Circumscribed circle class
    ///	\version b0.1
    ///	\date May 16 2023
    /// \warning This class is for educational purposes only!

    public class Circle : IFigure
    {
        public const double MinRadius = 1e-6;

        public Circle(double radius)
        {
            if (radius - MinRadius < Constants.CalculationAccuracy)
                throw new ArgumentException("Invalid circle radius.", nameof(radius));
            Radius = radius;
        }

        public double Radius { get; }

        public double GetSquare()
        {
            return Math.PI * Math.Pow(Radius, 2d);
        }
    }
}
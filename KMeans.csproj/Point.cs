using System;

namespace KMeans.csproj
{
    public class Point
    {
        public Point(double x, double y)
        {
            X = x; 
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Point other = (Point)obj;
            return X.Equals(other.X) & Y.Equals(other.Y);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KMeans.csproj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point[] points = new Point[]
            {
                new Point(1, 2),
                new Point(2, 1),
                new Point(3, 2),
                new Point(2, 3),
                new Point(5, 6),
                new Point(6, 5),
                new Point(7, 6),
                new Point(6, 7),
            };

            KMeansClusterization clusterization = new KMeansClusterization(points, 3);
            List<List<Point>> clusters = clusterization.GetClusters();
            int i = 1;
            foreach (List<Point> cluster in clusters)
            {
                Console.WriteLine($"Cluster: {i}");
                foreach (Point point in cluster)
                    Console.WriteLine("({0}, {1})", point.X, point.Y);
                i++;
            }
            Console.ReadKey();
        }
    }
}

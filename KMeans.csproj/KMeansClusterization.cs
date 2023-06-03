using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KMeans.csproj
{
    class KMeansClusterization
    {
        private int _k;
        private Point[] _points;
        private Random random = new Random();

        public KMeansClusterization(Point[] points, int k)
        {
            _points = points;
            _k = k;
        }

        public List<List<Point>> GetClusters() 
        {
            Point[] centroids = SetCentroids(_k);
            List<List<Point>> result = new List<List<Point>>();
            List<Point>[] clusters = new List<Point>[_k];

            for (int i = 0; i < _k; i++)
                clusters[i] = new List<Point>();

            SetClusters(clusters, centroids, _k);

            bool moved = true;
            while (moved)
            {
                moved = false;
                for(int i = 0; i < _k; i++)
                {
                    Point movedCentroids = GetCentroid(clusters[i]);
                    if (!movedCentroids.Equals(centroids[i]))
                    {
                        centroids[i] = movedCentroids;
                        moved = true;
                    }
                }
                if(moved)
                {
                    for (int i = 0; i < _k; i++)
                        clusters[i].Clear();
                    SetClusters(clusters, centroids, _k);
                }
            }
                    
            for (int i = 0; i < _k; i++)
                result.Add(clusters[i]);
            return result;
        }

        private void SetClusters(List<Point>[] clusters, Point[] centroids, int k)
        {
            foreach (Point p in _points)
            {
                int closest = 0;
                double closestDistance = CalculateDistance(p, centroids[0]);
                for (int i = 0; i < _k; i++)
                {
                    double distance = CalculateDistance(p, centroids[i]);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closest = i;
                    }
                    clusters[closest].Add(p);
                }
            }
        }

        private Point[] SetCentroids(int k)
        {
            Point[] centroids = new Point[_k];
            for(int i = 0; i < _k; i++)
                centroids[i] = _points[random.Next(_points.Length)];
            return centroids;
        }

        private Point GetCentroid(List<Point> points)
        {
            double totalX = 0;
            double totalY = 0;
            foreach(Point point in points) 
            {
                totalX += point.X;
                totalY += point.Y;
            }
            double centroidX = totalX / points.Count;
            double centroidY = totalY / points.Count;
            return new Point(centroidX, centroidY);
        }

        private double CalculateDistance(Point x, Point y)
        {
            if(x.Equals(y))
                return 0;
            double dx = x.X - y.X;
            double dy = x.Y - y.Y; 
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace PolygonDrawer.BL
{
    /// <summary>
    /// Represents serialization and deserialization of the polygons.
    /// </summary>
    public static class ShapesBl
    {
        /// <summary>
        /// Serialize the list of Polygons.
        /// </summary>
        /// <param name="polygons">List of Polygons.</param>
        /// <param name="path">Path to the file.</param>
        public static void SerializeList(List<Polygon> polygons, string path)
        {
            var formatterRectangle = new XmlSerializer(typeof(List<Polygon>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatterRectangle.Serialize(fs, polygons);
            }
        }
        /// <summary>
        /// Deserialize the list of Polygons.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        public static List<Polygon> DeserializeList(string path)
        {
            var formatter = new XmlSerializer(typeof(List<Polygon>));
            List<Polygon> polygons;
            using (var fs = new FileStream(path, FileMode.Open))
            {
                polygons = (List<Polygon>)formatter.Deserialize(fs);
            }

            if (polygons == null)
            {
                throw new ArgumentException($"Cannot deserialize file {path}");
            }
            
            return polygons;
        }

        /// <summary>
        /// Moves polygon to the point.
        /// </summary>
        /// <param name="shape">Polygon to move.</param>
        /// <param name="newCenter">New point on the canvas.</param>
        /// <returns></returns>
        public static Polygon MoveToPoint(Polygon shape, Point newCenter)
        {
            var previouseCenter = FindCentroid(shape.Points);

            var xShifting = previouseCenter.X - newCenter.X;
            var yShifting = previouseCenter.Y - newCenter.Y;

            var newPointList = new PointCollection();
            var points = shape.Points;
            var newPoint = new Point();
            foreach (var t in points)
            {
                newPoint.X = t.X - xShifting;
                newPoint.Y = t.Y - yShifting;
                newPointList.Add(newPoint);
            }
            shape.Points = newPointList;

            return shape;
        }

        private static double SignedPolygonArea(PointCollection points)
        {
            // Add the first point to the end.
            var numPoints = points.Count;
            Point[] pts = new Point[numPoints + 1];
            points.CopyTo(pts, 0);
            pts[numPoints] = points[0];

            // Get the areas.
            double area = 0;
            for (var i = 0; i < numPoints; i++)
            {
                area +=
                    (pts[i + 1].X - pts[i].X) *
                    (pts[i + 1].Y + pts[i].Y) / 2;
            }

            // Return the result.
            return area;
        }

        private static Point FindCentroid(PointCollection points)
        {
            // Add the first point at the end of the array.
            var numPoints = points.Count;
            var pts = new Point[numPoints + 1];
            points.CopyTo(pts, 0);
            pts[numPoints] = points[0];

            // Find the centroid.
            double x = 0;
            double y = 0;
            for (var i = 0; i < numPoints; i++)
            {
                var secondFactor = pts[i].X * pts[i + 1].Y -
                                       pts[i + 1].X * pts[i].Y;
                x += (pts[i].X + pts[i + 1].X) * secondFactor;
                y += (pts[i].Y + pts[i + 1].Y) * secondFactor;
            }

            // Divide by 6 times the polygon's area.
            var polygonArea = SignedPolygonArea(points);
            x /= (6 * polygonArea);
            y /= (6 * polygonArea);

            // If the values are negative, the polygon is
            // oriented counterclockwise so reverse the signs.
            if (!(x < 0))
                return new Point(x, y);
            x = -x;
            y = -y;

            return new Point(x, y);
        }
    }
}

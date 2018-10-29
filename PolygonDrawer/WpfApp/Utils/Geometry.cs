using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace PolygonDrawer.Utils
{
    /// <summary>
    /// Represents chekcer for cheking if the point is in the polygon.
    /// </summary>
    public class Geometry
    {
        /// <summary>
        /// Checks if the point is in the polygon.
        /// </summary>
        /// <param name="polygons">Polygon to check.</param>
        /// <param name="point">Point to check.</param>
        /// <returns>Returns the the result if point is in the polygon.</returns>
        public static bool IsInPolygon(PointCollection polygons, Point point)
        {
            bool result = false;
            int j = polygons.Count() - 1;
            for (int i = 0; i < polygons.Count(); i++)
            {
                if (polygons[i].X < point.Y && polygons[j].Y >= point.Y || polygons[j].Y < point.Y && polygons[i].Y >= point.Y)
                {
                    if (polygons[i].X + (point.Y - polygons[i].Y) / (polygons[j].Y - polygons[i].Y) * (polygons[j].X - polygons[i].X) < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
    }
}

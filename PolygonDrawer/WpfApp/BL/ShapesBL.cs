using System;
using System.Collections.Generic;
using System.IO;
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
    }
}

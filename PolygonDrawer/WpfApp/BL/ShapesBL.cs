using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace PolygonDrawer.BL
{
    public class ShapesBl
    {
        public static void SerializeList(List<Polygon> polygons, string path)
        {
            var formatterRectangle = new XmlSerializer(typeof(List<Polygon>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatterRectangle.Serialize(fs, polygons);
            }
        }

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
                throw new ApplicationException($"cannot deserialize file {path}");
            }
            
            return polygons;
        }
    }
}

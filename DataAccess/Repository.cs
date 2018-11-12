using BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAccess
{
    public class Repository<T> where T: Identified
    {
        private XmlSerializer serializer;
        private List<T> elements;
        private string filePath;

        public Repository(string filePath)
        {
            this.serializer = new XmlSerializer(typeof(List<T>));
            this.filePath = filePath;
            using (var fileStream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                this.elements = (List<T>)serializer.Deserialize(fileStream);
            }
        }

        public T Read(int id)
        {
            return elements.FirstOrDefault(x => x.Id == id);
        }

        public List<T> ReadAll()
        {
            return elements;
        }

        public void Delete(int id)
        {
            elements.Remove(Read(id));
            Save();
        }

        public void Create(T newElement)
        {
            elements.Add(newElement);
            Save();                   
        }

        public void Update(int id, T updatedElement)
        {
            Delete(id);
            Create(updatedElement);
            Save();
        }

        public void Save()
        {
            using (var fileStream = new StreamWriter(filePath))
            {
                serializer.Serialize(fileStream, elements);
            }
              
        }
    }
}

using TaxiServices;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace DataAccess
{
    public class Repository<T> where T : class, Identified
    {
        private AppDBContext context;

        public Repository(AppDBContext cont)
        {
            this.context = cont;
        }

        public T Read(int id)
        {
            return context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> ReadAll()
        {
            return context.Set<T>().ToList();
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(Read(id));
            Save();
        }

        public void Create(T newElement)
        {
            context.Set<T>().Add(newElement);
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
            context.SaveChanges();
        }
    }
}

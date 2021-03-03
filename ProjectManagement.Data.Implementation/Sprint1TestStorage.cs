using System.Collections.Generic;
using System.Linq;

namespace ProjectManagement.Data.Implementation
{
    public class Sprint1TestStorage<T> where T : class
    {
        private Dictionary<long,T> storage = new Dictionary<long, T>();

        public IEnumerable<T> GetAll() => storage.Values;

        public T GetById(long id)
        {
            return storage.FirstOrDefault(x => x.Key == id).Value;
        }

        public void AddOrUpdate(long id, T item)
        {
            storage[id] = item;
        }
    }
}

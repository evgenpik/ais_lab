using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(Guid id);
        IEnumerable<T> ReadAll();
        T ReadById(Guid id);
        void Update(T entity);
    }

}

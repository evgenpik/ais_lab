using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public interface IWriteRepository <T> where T : IDomainObject
    {
        void Add(T entity);
        void Delete(Guid id);
        void Update (T entity);
    }
}

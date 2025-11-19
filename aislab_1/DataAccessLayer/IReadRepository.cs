using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public interface IReadRepository<T> where T : IDomainObject
    {
        IEnumerable<T> ReadAll();
        T ReadById(Guid id);
    }
}

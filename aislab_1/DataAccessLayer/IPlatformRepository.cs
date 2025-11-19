using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IPlatformRepository : IRepository<Platform>
    {
        Platform GetByName(string name);
    }
}

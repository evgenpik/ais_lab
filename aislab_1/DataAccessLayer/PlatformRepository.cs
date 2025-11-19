using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PlatformRepository : EntityRepository<Platform>, IPlatformRepository
    {
        public Platform GetByName(string name)
        {
            using (var context = new AppDbContext())
            {
                return context.Platforms.FirstOrDefault(p => p.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}

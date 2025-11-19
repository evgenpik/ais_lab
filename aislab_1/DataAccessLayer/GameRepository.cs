using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class GameRepository : EntityRepository<Game>, IGameRepository
    {
        public IEnumerable<Game> GetWithAllPlatforms()
        {
            using (var context = new AppDbContext())
            {
                return context.Games.Include(g => g.Platform).ToList();
            }
                
        }

        public IEnumerable<Game> GetgamesByPlatformName(string platformName)
        {
            using (var context = new AppDbContext())
            {
                return context.Games
                    .Include(g => g.Platform)
                    .Where(g => g.Platform.Name.Equals(platformName, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }
    }
}

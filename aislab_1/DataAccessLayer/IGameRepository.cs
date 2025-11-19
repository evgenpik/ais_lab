using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public interface IGameRepository : IRepository<Model.Game>
    {
        IEnumerable<Game> GetWithAllPlatforms();

        IEnumerable<Game> GetgamesByPlatformName(string platformName);

    }
}

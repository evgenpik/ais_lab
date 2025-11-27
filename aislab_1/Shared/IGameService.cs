using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Shared
{
    public interface IGameService
    {

        // методы работы с играми (просто перенесены из логики)  
        void AddGame(string title, Genre genre, string developer, int releaseYear, Guid platformId, int rating);
        void UpdateGame(Guid id, string title, int rating, Guid platformId, string developer, Genre genre);
        bool DeleteGame(Guid id);
        IEnumerable<Game> GetAllGames();
        IEnumerable<Game> GetGamesByPlatform(Guid platformId);
        IEnumerable<Game> FindGamesByPlatformName(string platformName);
        IEnumerable<IGrouping<Genre, Game>> GetGamesGroupedByGenre();

        // методы работы с платформами (тоже перенесены с логики)
        IEnumerable<Platform> GetAllPlatforms();
        bool TryAddPlatform(string name);
        bool DeletePlatform(Guid id);
    }
}

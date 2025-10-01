using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogical
{
    public class InMemoryGameRepository: IGameRepository
    {
        private readonly List<Game> _games = new List<Game>();

        public void Add(Game game) => _games.Add(game);

        public bool Delete(Guid id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null) return false;
            _games.Remove(game);
            return true;
        }

        public bool Update(Game updatedGame)
        {
            var game = _games.FirstOrDefault(g => g.Id == updatedGame.Id);
            if (game == null) return false;

            game.Title = updatedGame.Title;
            game.Developer = updatedGame.Developer;
            game.Platform = updatedGame.Platform;
            game.ReleaseYear = updatedGame.ReleaseYear;
            game.GameGenre = updatedGame.GameGenre;
            game.Rating = updatedGame.Rating;
            return true;
        }

        public Game GetById(Guid id) => _games.FirstOrDefault(g => g.Id == id);

        public List<Game> GetAll() => _games.ToList();
    }
}

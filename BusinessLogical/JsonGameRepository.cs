using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;    
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace BusinessLogical
{
    public class JsonGameRepository : IGameRepository
    {
        private readonly string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"games.json"); // общий файл для хранения

        private List<Game> LoadGames()
        {
            if (!File.Exists(filePath)) return new List<Game>();
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Game>>(json) ?? new List<Game>();
        }

        private void SaveGames(List<Game> games)
        {
            string json = JsonConvert.SerializeObject(games, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void Add(Game game)
        {
            var games = LoadGames();
            games.Add(game);
            SaveGames(games);
        }

        public bool Delete(Guid id)
        {
            var games = LoadGames();
            var game = games.FirstOrDefault(g => g.Id == id);
            if (game == null) return false;
            games.Remove(game);
            SaveGames(games);
            return true;
        }

        public bool Update(Game updatedGame)
        {
            var games = LoadGames();
            var game = games.FirstOrDefault(g => g.Id == updatedGame.Id);
            if (game == null) return false;

            game.Title = updatedGame.Title;
            game.Developer = updatedGame.Developer;
            game.Platform = updatedGame.Platform;
            game.ReleaseYear = updatedGame.ReleaseYear;
            game.GameGenre = updatedGame.GameGenre;
            game.Rating = updatedGame.Rating;

            SaveGames(games);
            return true;
        }

        public Game GetById(Guid id) => LoadGames().FirstOrDefault(g => g.Id == id);

        public List<Game> GetAll() => LoadGames();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogical
{
    public class Logic
    {
        //public List<Game> Games = new List<Game>();
        private readonly IGameRepository _repository;
        public Logic(IGameRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Метод для создания сущности
        /// </summary>
        /// <param name="title"></param>
        /// <param name="genre"></param>
        /// <param name="developer"></param>
        /// <param name="releaseYear"></param>
        /// <param name="platform"></param>
        /// <param name="rating"></param>
        public void AddGame(string title, Genre genre, string developer, int releaseYear, string platform, int rating)
        {
            Game game = new Game()
            {
                Id = Guid.NewGuid(),
                Title = title,
                GameGenre = genre,
                Developer = developer,
                ReleaseYear = releaseYear,
                Platform = platform,
                Rating = rating
            };

            _repository.Add(game);
        }

        /// <summary>
        /// Читает сущности
        /// </summary>
        /// <returns>Возвращает строку с данными об играх</returns>
        public string GetAll()
        {
            var games = _repository.GetAll();
            if (games.Count == 0) return "У вас нет добавленных игр";

            var sb = new StringBuilder();
            foreach (var game in games)
            {
                sb.AppendLine($"Название: {game.Title} | Жанр: {game.GameGenre} | Платформа: {game.Platform} | Рейтинг: {game.Rating}/10");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Метод для дальнейшего отбора игр
        /// </summary>
        /// <returns>Строка с ID и названием игры</returns>
        public string GetGameListForSelection()
        {
            var games = _repository.GetAll();
            if (games.Count == 0) return "У вас пока нет добавленных игр";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Список игр:");

            foreach (var game in games)
            {
                sb.AppendLine($"ID: {game.Id}| Название: {game.Title}");

            }
            return sb.ToString();


        }

        /// <summary>
        /// Метод для изменения данных об игре
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTtile"></param>
        /// <param name="newRating"></param>
        /// <returns>True, если сведения изменены. False, если что-то пошло не так</returns>
        /*public bool ChangeGame(Guid id, string newTtile, int newRating, string newPlatform, string newDeveloper, Genre newGenre)
        {
            Game gameChange = Games.FirstOrDefault(g => g.Id == id);

            if (gameChange != null)
            {
                gameChange.Rating = newRating;
                gameChange.Title = newTtile;
                gameChange.Developer = newDeveloper;
                gameChange.Platform = newPlatform;
                gameChange.GameGenre = newGenre;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Метод для удаления игры
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True, если игра удалена. False, если что-то пошло не так</returns>
        public bool DeleteGame(Guid id)
        {
            Game gameToDelete = Games.FirstOrDefault(g => g.Id == id);

            if (gameToDelete != null)
            {
                Games.Remove(gameToDelete);
                return true; 
            }
            else
            {
                return false; 
            }

        }*/

        public bool ChangeGame(Game updatedGame) => _repository.Update(updatedGame);
        public bool DeleteGame(Guid id) => _repository.Delete(id);
        public List<Game> GetGames() => _repository.GetAll();

        /// <summary>
        /// Метод для группировки игр
        /// </summary>
        /// <returns>Строка с сгруппированными играми</returns>
        public string GetGamesGroupedByGenre()
        {
            var Games = _repository.GetAll();
            if (Games.Count == 0) return "Нет игр для группировки.";

            StringBuilder sb = new StringBuilder();         
            var groupedGames = Games.GroupBy(game => game.GameGenre);
           
            foreach (var group in groupedGames)
            {
                sb.AppendLine($"\n--- Жанр: {group.Key} ---"); 

                foreach (var game in group)
                {
                    sb.AppendLine($"    {game.Title} (Рейтинг: {game.Rating}/10)");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Фильтр игры по платформе
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        public string GetGamesByPlatform(string platform)
        {
            var Games = _repository.GetAll();
            var filteredGames = Games
                .Where(game => game.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase)).ToList();

            if (filteredGames.Count == 0)
            {
                return $"Игры на платформе '{platform}' не найдены.";
            }

            StringBuilder sb = new StringBuilder();
            foreach (var game in filteredGames)
            {
                sb.AppendLine($"{game.Title} (Рейтинг: {game.Rating}/10)");
            }
            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer;

namespace BusinessLogical
{
    public class Logic
    {
        private readonly IRepository<Game> _gameRepository;


        public Logic(IRepository<Game> gameRepository)
        {

            _gameRepository = gameRepository;

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
        public void AddGame(string title, Genre genre, string developer, int releaseYear, Guid platformId, int rating)
        {
            var platforms = _gameRepository.GetAllPlatforms();//ааааа
            var platform = platforms.FirstOrDefault(p => p.Id == platformId);
            //тут мы получаем существующие платформы по и тип проверяем, есть ли платформа с таким Id
            if (platform == null)
                throw new Exception($"Платформа с Id {platformId} не найдена!");

            Game game = new Game()
            {
                Id = Guid.NewGuid(),
                Title = title,
                GameGenre = genre,
                Developer = developer,
                ReleaseYear = releaseYear,
                PlatformId = platform.Id,
                PlatformName = platform.Name, 
                Rating = rating
            };
            _gameRepository.Add(game);
        }
        public List<Platform> GetAllPlatforms()
        {
            return _gameRepository.GetAllPlatforms();  
        }
        /// <summary>
        /// Читает сущности
        /// </summary>
        /// <returns>Возвращает строку с данными об играх</returns>
        public string GetAll()
        {
            StringBuilder sb = new StringBuilder();
            var allGames = _gameRepository.ReadAll();  
            foreach (Game game in allGames)
            {
                sb.AppendLine($"Название: {game.Title} | Жанр: {game.GameGenre} | Платформа: {game.PlatformName} | Рейтинг: {game.Rating}/10");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Возвращает "сырой" список всех игр для использования в слое Представления (например, WinForms)
        /// </summary>
        public List<Game> GetAllGames()
        {
            return _gameRepository.ReadAll().ToList();
        }

        /// <summary>
        /// Метод для дальнейшего отбора игр
        /// </summary>
        /// <returns>Строка с ID и названием игры</returns>
        public string GetGameListForSelection()
        {
            var allGames = _gameRepository.ReadAll();

            if (!allGames.Any())
            {
                return "У вас нет добавленных игр.";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Список игр:");

            foreach (var game in allGames)
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
        public bool ChangeGame(Guid id, string newTitle, int newRating, Guid newPlatformId, string newDeveloper, Genre newGenre)
        {
            Game gameChange = _gameRepository.ReadById(id);
            if (gameChange == null)
                return false;

            var platforms = _gameRepository.GetAllPlatforms();
            var platform = platforms.FirstOrDefault(p => p.Id == newPlatformId);

            if (platform == null)
                throw new Exception($"Платформа с Id {newPlatformId} не найдена!");

            gameChange.Rating = newRating;
            gameChange.Title = newTitle;
            gameChange.Developer = newDeveloper;
            gameChange.PlatformId = newPlatformId;
            gameChange.PlatformName = platform.Name;  
            gameChange.GameGenre = newGenre;

            _gameRepository.Update(gameChange);
            return true;
        }
        /// <summary>
        /// Метод для удаления игры
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True, если игра удалена. False, если что-то пошло не так</returns>
        public bool DeleteGame(Guid id)
        {
            _gameRepository.Delete(id);
            return true;
            
        }
        /// <summary>
        /// Метод для группировки игр
        /// </summary>
        /// <returns>Строка с сгруппированными играми</returns>
        public string GetGamesGroupedByGenre()
        {
            var allGames = _gameRepository.ReadAll();

            if (!allGames.Any()) return "Нет игр для группировки.";

            StringBuilder sb = new StringBuilder();
            var groupedGames = allGames.GroupBy(game => game.GameGenre);

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
        public string GetGamesByPlatform(string platformName)
        {
            var allGames = _gameRepository.ReadAll(); 
            var filteredGames = allGames
                .Where(game => game.PlatformName.Equals(platformName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (filteredGames.Count == 0)
                return $"Игры на платформе '{platformName}' не найдены.";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"--- Игры на платформе '{platformName}' ---");
            foreach (var game in filteredGames)
            {
                sb.AppendLine($"{game.Title} ({game.GameGenre}) - Рейтинг: {game.Rating}/10");
            }
            return sb.ToString();
        }


    }
}

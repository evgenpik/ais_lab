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
        private readonly IRepository<Game> repository;

        //высокоуровневый код (Logic) зависит от абстракций,
        //а выбор конкретных зависимостей делегируется контейнеру внедрения зависимостей SimpleConfigModule.
        public Logic(IRepository<Game> repo)
        {
            
            repository = repo;
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

            repository.Add(game);
        }

        /// <summary>
        /// Читает сущности
        /// </summary>
        /// <returns>Возвращает строку с данными об играх</returns>
        
        //public string GetAll()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    var allGames = repository.ReadAll();

        //    foreach (Game game in allGames)
        //    {
        //        sb.AppendLine($"Название: {game.Title} | Жанр: {game.GameGenre} | Платформа: {game.Platform} | Рейтинг: {game.Rating}/10");
        //    }
        //    return sb.ToString();
        //}

        /// <summary>
        /// Возвращает "сырой" список всех игр для использования в слое Представления (например, WinForms)
        /// </summary>
        public List<Game> GetAllGames()
        {
            // Просим у репозитория все игры и превращаем результат в List<Game>.
            return repository.ReadAll().ToList();
        }

        /// <summary>
        /// Метод для дальнейшего отбора игр
        /// </summary>
        /// <returns>Строка с ID и названием игры</returns>
        //public string GetGameListForSelection()
        //{
            //var allGames = repository.ReadAll();

            //if (!allGames.Any())
            //{
            //    return "У вас нет добавленных игр.";
            //}
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("Список игр:");

            //foreach (var game in allGames)
            //{
            //    sb.AppendLine($"ID: {game.Id}| Название: {game.Title}");

            //}
            //return sb.ToString();
            

        //}

        /// <summary>
        /// Метод для изменения данных об игре
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTtile"></param>
        /// <param name="newRating"></param>
        /// <returns>True, если сведения изменены. False, если что-то пошло не так</returns>
        public bool ChangeGame(Guid id, string newTtile, int newRating, string newPlatform, string newDeveloper, Genre newGenre)
        {
            Game gameChange = repository.ReadById(id);

            if (gameChange != null)
            {
                gameChange.Rating = newRating;
                gameChange.Title = newTtile;
                gameChange.Developer = newDeveloper;
                gameChange.Platform = newPlatform;
                gameChange.GameGenre = newGenre;
                repository.Update(gameChange);
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
            repository.Delete(id);
            return true;


            //Game gameToDelete = Games.FirstOrDefault(g => g.Id == id);
            //if (gameToDelete != null)
            //{
            //    Games.Remove(gameToDelete);
            //    return true; 
            //}
            //else
            //{
            //    return false; 
            //}

        }
        /// <summary>
        /// Метод для группировки игр
        /// </summary>
        /// <returns>Строка с сгруппированными играми</returns>
        //public string GetGamesGroupedByGenre()
        //{
        //    var allGames = repository.ReadAll();

        //    if (!allGames.Any()) return "Нет игр для группировки.";

        //    StringBuilder sb = new StringBuilder();         
        //    var groupedGames = allGames.GroupBy(game => game.GameGenre);

        //    foreach (var group in groupedGames)
        //    {
        //        sb.AppendLine($"\n--- Жанр: {group.Key} ---"); 

        //        foreach (var game in group)
        //        {
        //            sb.AppendLine($"    {game.Title} (Рейтинг: {game.Rating}/10)");
        //        }
        //    }
        //    return sb.ToString();
        //}

        public IEnumerable<IGrouping<Genre, Game>> GetGamesGroupedByGenre()
        {
            var allGames = repository.ReadAll();
            return allGames.GroupBy(game => game.GameGenre);
        }

        /// <summary>
        /// Фильтр игры по платформе
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        /// 

        //public string GetGamesByPlatform(string platform)
        //{
        //    var filteredGames = repository.ReadAll()
        //        .Where(game => game.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase)).ToList();

        //    if (filteredGames.Count == 0)
        //    {
        //        return $"Игры на платформе '{platform}' не найдены.";
        //    }

        //    StringBuilder sb = new StringBuilder();
        //    foreach (var game in filteredGames)
        //    {
        //        sb.AppendLine($"{game.Title} (Рейтинг: {game.Rating}/10)");
        //    }
        //    return sb.ToString();
        //}

        public List<Game> GetGamesByPlatform(string platform)
        {
            return repository.ReadAll()
                .Where(game => game.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }


        /// <summary>
        /// Получает список игр по заданному условию (фильтру)
        /// </summary>
        /// <param name="filter">Условие для фильтрации</param>
        /// <returns>Список отфильтрованных игр</returns>
        /// то есть это гибкий метод для более сложной фильтрации который как раз демонстрирует принцип Open/Closed, 
        public List<Game> GetGamesByFilter(Func<Game, bool> filter)
        {
            return repository.ReadAll().Where(filter).ToList();
        }
    }
}

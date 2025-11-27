using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Shared;

namespace BusinessLogical
{
    /// <summary>
    /// Адаптер, оборачивающий класс логики и предоставляющий event-driven интерфейс
    /// </summary>
    public class GameService : IGameService
    {
        
        private readonly Logic logic;


        

        public GameService(Logic logic)
        {
            this.logic = logic;
        }

        #region Реализация методов 

        /// <summary>
        /// Метод для добавления игры
        /// </summary>
        /// <param name="title"></param>
        /// <param name="genre"></param>
        /// <param name="developer"></param>
        /// <param name="releaseYear"></param>
        /// <param name="platformId"></param>
        /// <param name="rating"></param>
        public void AddGame(string title, Genre genre, string developer, int releaseYear, Guid platformId, int rating)
        {
            logic.AddGame(title, genre, developer, releaseYear, platformId, rating);
            
        }

        /// <summary>
        /// Метод для изменения свойств игры
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="rating"></param>
        /// <param name="platformId"></param>
        /// <param name="developer"></param>
        /// <param name="genre"></param>
        public void UpdateGame(Guid id, string title, int rating, Guid platformId, string developer, Genre genre)
        {
            logic.ChangeGame(id, title, rating, platformId, developer, genre);
            
        }

        /// <summary>
        /// Метод, позволяющий удалить игру по её идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteGame(Guid id)
        {
            return logic.DeleteGame(id);

           
        }

        /// <summary>
        /// Метод для получения всех игр
        /// </summary>
        /// <returns>Объект IEnumerable<Game> со всеми играми из источника данных</returns>
        public IEnumerable<Game> GetAllGames()
        {
            return logic.GetAllGames();
        }
        /// <summary>
        /// Метод, позволяющий получить игры по идентификатору платформы
        /// </summary>
        /// <param name="platformId"></param>
        /// <returns>Список игр, удовлетворяющий условию </returns>
        public IEnumerable<Game> GetGamesByPlatform(Guid platformId)
        {
            return logic.GetGamesByPlatform(platformId);
        }

        /// <summary>
        /// Метод, позволяющий найти игры по названию платформы
        /// </summary>
        /// <param name="platformName"></param>
        /// <returns>Список игр, удовлетворяющий условию</returns>
        public IEnumerable<Game> FindGamesByPlatformName(string platformName)
        {
            return logic.FindGamesOnPlatformByName(platformName);
        }

        /// <summary>
        /// Метод, группирующий игры по жанрам
        /// </summary>
        /// <returns>Список игр, сгруппированных по жанру</returns>
        public IEnumerable<IGrouping<Genre, Game>> GetGamesGroupedByGenre()
        {
            return logic.GetGamesGroupedByGenre();
        }

        /// <summary>
        /// Метод для получения всех платформ
        /// </summary>
        /// <returns>Список доступных платформ</returns>
        public IEnumerable<Platform> GetAllPlatforms()
        {
            return logic.GetAllPlatforms();
        }

        /// <summary>
        /// Метод для добавления платформы
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Значение True, если платформа добавлена</returns>
        public bool TryAddPlatform(string name)
        {
            return logic.TryAddPlatform(name);
        }
        /// <summary>
        /// Метод для удаления платформы по её идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Значение True, если удаление прошло успешно</returns>
        public bool DeletePlatform(Guid id)
        {
            return logic.DeletePlatform(id);
        }
        #endregion
    }
}

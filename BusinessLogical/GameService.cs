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


        //мне просто нравится регионы добавлять)))
        #region События
        public event EventHandler<IEnumerable<Game>> GamesLoaded;
        public event EventHandler<IEnumerable<Platform>> PlatformsLoaded;
        public event EventHandler<string> ErrorOccurred;
        public event EventHandler<string> SuccessOccurred;
        #endregion

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
            try
            {//в общем, презентер подписывается на события этого сервиса и обновляет view в ответ на них
                logic.AddGame(title, genre, developer, releaseYear, platformId, rating);
                GamesLoaded?.Invoke(this, logic.GetAllGames());
                SuccessOccurred?.Invoke(this, "Игра успешно добавлена!");
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, ex.Message);
            }
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
            try
            {
                if (logic.ChangeGame(id, title, rating, platformId, developer, genre))
                {
                    GamesLoaded?.Invoke(this, logic.GetAllGames());
                    SuccessOccurred?.Invoke(this, "Игра успешно обновлена!");
                }
                else
                {
                    ErrorOccurred?.Invoke(this, "Игра не найдена");
                }
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, ex.Message);
            }
        }

        /// <summary>
        /// Метод, позволяющий удалить игру по её идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteGame(Guid id)
        {
            try
            {
                var result = logic.DeleteGame(id);
                if (result)
                {
                    GamesLoaded?.Invoke(this, logic.GetAllGames());
                    SuccessOccurred?.Invoke(this, "Игра успешно удалена!");
                }
                return result;
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Метод для получения всех игр
        /// </summary>
        /// <returns>Объект IEnumerable<Game> со всеми играми из источника данных</returns>
        public IEnumerable<Game> GetAllGames()
        {
            try
            {
                return  logic.GetAllGames();
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, ex.Message);
                return new List<Game>();
            }
        }
        /// <summary>
        /// Метод, позволяющий получить игры по идентификатору платформы
        /// </summary>
        /// <param name="platformId"></param>
        /// <returns>Список игр, удовлетворяющий условию </returns>
        public IEnumerable<Game> GetGamesByPlatform(Guid platformId)
        {
            try
            {
                return logic.GetGamesByPlatform(platformId);
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, ex.Message);
                return new List<Game>();
            }
        }

        /// <summary>
        /// Метод, позволяющий найти игры по названию платформы
        /// </summary>
        /// <param name="platformName"></param>
        /// <returns>Список игр, удовлетворяющий условию</returns>
        public IEnumerable<Game> FindGamesByPlatformName(string platformName)
        {
            try
            {
                return logic.FindGamesOnPlatformByName(platformName);
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, ex.Message);
                return new List<Game>();
            }
        }

        /// <summary>
        /// Метод, группирующий игры по жанрам
        /// </summary>
        /// <returns>Список игр, сгруппированных по жанру</returns>
        public IEnumerable<IGrouping<Genre, Game>> GetGamesGroupedByGenre()
        {
            try
            {
                return logic.GetGamesGroupedByGenre();
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, ex.Message);
                return new List<IGrouping<Genre, Game>>();
            }
        }

        /// <summary>
        /// Метод для получения всех платформ
        /// </summary>
        /// <returns>Список доступных платформ</returns>
        public IEnumerable<Platform> GetAllPlatforms()
        {
            try
            {
                return logic.GetAllPlatforms();
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, ex.Message);
                return new List<Platform>();
            }
        }

        /// <summary>
        /// Метод для добавления платформы
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Значение True, если платформа добавлена</returns>
        public bool TryAddPlatform(string name)
        {
            try
            {
                var result = logic.TryAddPlatform(name);
                if (result)
                {
                    PlatformsLoaded?.Invoke(this, logic.GetAllPlatforms());
                    SuccessOccurred?.Invoke(this, "Платформа добавлена!");
                }
                return result;
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Метод для удаления платформы по её идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Значение True, если удаление прошло успешно</returns>
        public bool DeletePlatform(Guid id)
        {
            try
            {
                var result = logic.DeletePlatform(id);
                if (result)
                {
                    PlatformsLoaded?.Invoke(this, logic.GetAllPlatforms());
                    SuccessOccurred?.Invoke(this, "Платформа удалена!");
                }
                return result;
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke(this, ex.Message);
                return false;
            }
        }
        #endregion
    }
}

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
        //private readonly IRepository<Game> repository;
        private readonly IGameRepository gameRepository;
        private readonly IPlatformRepository platformRepository;

            
        //высокоуровневый код (Logic) зависит от абстракций,
        //а выбор конкретных зависимостей делегируется контейнеру внедрения зависимостей SimpleConfigModule.
        public Logic(IGameRepository game_repo, IPlatformRepository platform_repo)
        {
            
            gameRepository = game_repo;
            platformRepository = platform_repo;
        }
        public IEnumerable<Platform> GetAllPlatforms()
        {
            return platformRepository.ReadAll();
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
            var platforms = GetAllPlatforms();
            Game game = new Game()
            {
                Id = Guid.NewGuid(),
                Title = title,
                GameGenre = genre,
                Developer = developer,
                ReleaseYear = releaseYear,
                PlatformId = platformId,
                Rating = rating
            };

            gameRepository.Add(game);
        }


        /// <summary>
        /// Возвращает "сырой" список всех игр для использования в слое Представления (например, WinForms)
        /// </summary>
        public List<Game> GetAllGames()
        {
            // Просим у репозитория все игры и превращаем результат в List<Game>.
            //return gameRepository.ReadAll().ToList();
            return gameRepository.GetWithAllPlatforms().ToList();
        }

      

        /// <summary>
        /// Метод для изменения данных об игре
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTtile"></param>
        /// <param name="newRating"></param>
        /// <returns>True, если сведения изменены. False, если что-то пошло не так</returns>
        public bool ChangeGame(Guid id, string newTtile, int newRating, Guid newPlatformId, string newDeveloper, Genre newGenre)
        {
            //получаем игру из репозитория 
            Game gameChange = gameRepository.ReadById(id);

            if (gameChange != null)
            {
                gameChange.Rating = newRating;
                gameChange.Title = newTtile;
                gameChange.Developer = newDeveloper;
                gameChange.PlatformId = newPlatformId;
                gameChange.GameGenre = newGenre;
                gameRepository.Update(gameChange);
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
            gameRepository.Delete(id);
            return true;

        }
        
        public bool DeletePlatform(Guid id)
        {
            platformRepository.Delete(id);
            return true;
        }
       
        public IEnumerable<IGrouping<Genre, Game>> GetGamesGroupedByGenre()
        {
            var allGames = gameRepository.ReadAll();
            return allGames.GroupBy(game => game.GameGenre);
        }

        

        public List<Game> GetGamesByPlatform(Guid platformId)
        {
            return gameRepository.ReadAll()
                .Where(game => game.PlatformId == platformId)
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
            return gameRepository.ReadAll().Where(filter).ToList();
        }


        public bool TryAddPlatform(string platformName)
        {
            if (string.IsNullOrWhiteSpace(platformName))
            {
                return false; 
            }

            var existingPlatform = platformRepository.GetByName(platformName);
            if (existingPlatform != null)
            {
                return false;
            }

            var newPlatform = new Platform
            {
                Id = Guid.NewGuid(),
                Name = platformName
            };
            platformRepository.Add(newPlatform);
            return true;
        }

        public List<Game> FindGamesOnPlatformByName(string platformName)
        {
            return gameRepository.GetgamesByPlatformName(platformName).ToList();
        }
    }
}

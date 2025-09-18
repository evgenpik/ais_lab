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
        public List<Game> Games = new List<Game>();

        // Создание сущности
        /// <summary>
        ///     
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

            Games.Add(game);
        }

        // Чтение сущности
        public string GetAll()
        {
            StringBuilder sb = new StringBuilder();

            //как в примере сделал
            foreach (Game game in Games)
            {
                sb.AppendLine($"Название: {game.Title} | Жанр: {game.GameGenre} | Платформа: {game.Platform} | Рейтинг: {game.Rating}/10");
            }
            return sb.ToString();


            // это можно будет сделать какой-нибудь вывод типа карточки игры (более читаемо что-ли)
            //foreach (var game in Games)
            //{
            //    sb.AppendLine($"ID: {game.Id}");
            //    sb.AppendLine($"Title: {game.Title}");
            //    sb.AppendLine($"Genre: {game.GameGenre}");
            //    sb.AppendLine($"Developer: {game.Developer}");
            //    sb.AppendLine($"Release Year: {game.ReleaseYear}");
            //    sb.AppendLine($"Platforms: {string.Join(", ", game.Platforms)}");
            //    sb.AppendLine($"Rating: {game.Rating}/10");
            //    sb.AppendLine(new string('-', 20));
            //}
            //return sb.ToString();
        }


        public string GetGameListForSelection()
        {
            if (Games.Count == 0)
            {
                return "У вас нет добавленных игр.";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Список игр:");

            foreach (var game in Games)
            {
                sb.AppendLine($"ID: {game.Id}| Название: {game.Title}");

            }
            return sb.ToString();


        }

        public bool ChangeGame(Guid id, string newTtile, int newRating)
        {
            Game gameChange = Games.FirstOrDefault(g => g.Id == id);

            if (gameChange != null)
            {
                gameChange.Rating = newRating;
                gameChange.Title = newTtile;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteGame(Guid id)
        {
            // Ищем игру в списке по ID. FirstOrDefault вернет null, если ничего не найдено.
            Game gameToDelete = Games.FirstOrDefault(g => g.Id == id);

            if (gameToDelete != null)
            {
                Games.Remove(gameToDelete);
                return true; // Удаление успешно
            }
            else
            {
                return false; // Игра с таким ID не найдена
            }

        }

        public string GetGamesGroupedByGenre()
        {
            if (Games.Count == 0) return "Нет игр для группировки.";

            StringBuilder sb = new StringBuilder();

            // Используем LINQ для группировки
            var groupedGames = Games.GroupBy(game => game.GameGenre);

            // Проходим по каждой группе
            foreach (var group in groupedGames)
            {
                sb.AppendLine($"\n--- Жанр: {group.Key} ---"); // group.Key - это значение, по которому группировали (сам жанр)

                // Проходим по всем играм внутри этой группы
                foreach (var game in group)
                {
                    sb.AppendLine($"    {game.Title} (Рейтинг: {game.Rating}/10)");
                }
            }
            return sb.ToString();
        }


        public string GetGamesByPlatform(string platform)
        {
            var filteredGames = Games
                // 1. Оставляем фильтрацию .Where() - она находит нужные игры
                .Where(game => game.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase)).ToList();

            if (filteredGames.Count == 0)
            {
                return $"Игры на платформе '{platform}' не найдены.";
            }

            StringBuilder sb = new StringBuilder();
            foreach (var game in filteredGames)
            {
                // Формат вывода оставляем тем же, он хороший
                sb.AppendLine($"{game.Title} (Рейтинг: {game.Rating}/10)");
            }
            return sb.ToString();
        }
    }
}

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
        public List <Game> Games = new List <Game> ();
        
        // Создание сущности
        public void AddGame(string title, Genre genre, string developer, int releaseYear, string[] platform, int rating )
        {
            Game game = new Game()
            {
                Id = Guid.NewGuid(),
                Title = title,
                GameGenre = genre,
                Developer = developer,
                ReleaseYear = releaseYear,
                Platforms = platform,
                Rating = rating
            };

            Games.Add(game);
        }

        // Чтение сущности
        public string GetAll()
        {
            StringBuilder sb = new StringBuilder();

            //как в примере сделал
            foreach ( Game game in Games)
            {
                sb.AppendLine($"Название: {game.Title} | Жанр: {game.GameGenre} | Платформы: {string.Join(", ", game.Platforms)} | Рейтинг: {game.Rating}/10");
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


    }
}

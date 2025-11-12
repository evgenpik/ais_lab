using BusinessLogical;
using DataAccessLayer;
using Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static IKernel kernel;

        static void Main(string[] args)
        {
            
            kernel = new StandardKernel(new SimpleConfigModule());
            var logic = kernel.Get<Logic>();

            while (true)
            {
                Console.WriteLine("Выберите действие:\n" +
                "1.Добавить игру\n" +
                "2.Посмотреть свойства игры\n" +
                "3.Изменить игру\n" +
                "4.Удалить игру\n" +
                "5.Группировать по жанрам\n" +
                "6.Отсортировать по платформе и рейтингу\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        string title = GetValidString("Введите название игры: ");
                        Genre genre = GetValidGenre("Введите жанр:");
                        string developer = GetValidString("Введите разработчика: ");
                        int currentYear = DateTime.Now.Year;
                        int releaseYear = GetValidInt($"Введите год выпуска (1970-{currentYear}): ", 1970, currentYear);

                        
                        var platforms = logic.GetAllPlatforms().ToList();
                        if (platforms.Count == 0)
                        {
                            Console.WriteLine("Нет доступных платформ!");
                            break;
                        }

                        Console.WriteLine("Доступные платформы:");
                        for (int i = 0; i < platforms.Count; i++)
                        {
                            Console.WriteLine($"  {i + 1}. {platforms[i].Name} (ID: {platforms[i].Id})");
                        }

                        Console.Write("Выберите платформу (номер): ");
                        int platformChoice = GetValidInt("", 1, platforms.Count) - 1;
                        Guid platformId = platforms[platformChoice].Id;  

                        int rating = GetValidInt("Введите ваш рейтинг (1-10): ", 1, 10);
                        logic.AddGame(title, genre, developer, releaseYear, platformId, rating);
                        Console.WriteLine("\nИгра успешно добавлена!\n");
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("\n---Список ваших игр и их свойства---");

                        var allGames = logic.GetAllGames();
                        var allPlatforms = logic.GetAllPlatforms();

                        if (!allGames.Any())
                        {
                            Console.WriteLine("У вас пока нет добавленных игр");
                        }
                        else
                        {
                            // создаем словарь для быстрого поиска платформы по ее id
                            var platformDictionary = allPlatforms.ToDictionary(p => p.Id);

                            foreach (var game in allGames)
                            {
                                string platformName = "Неизвестно";
                                if (platformDictionary.ContainsKey(game.PlatformId))
                                {
                                    platformName = platformDictionary[game.PlatformId].Name;
                                }

                                Console.WriteLine($"Название: {game.Title} | Жанр: {game.GameGenre} | Платформа: {platformName} | Рейтинг: {game.Rating}/10");
                            }
                        }
                        Console.WriteLine("--------------------------------\n");
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Список игр для выбора:");
                        var gamesToSelectFrom = logic.GetAllGames();
                        if (!gamesToSelectFrom.Any())
                        {
                            Console.WriteLine("У вас нет добавленных игр.");
                            break;
                        }

                        foreach (var game in gamesToSelectFrom)
                        {
                            Console.WriteLine($"ID: {game.Id} | Название: {game.Title}");
                        }

                        Console.WriteLine("Введите ID игры, которую хотите изменить: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idForChange))
                        {
                            string newTitle = GetValidString("Введите новое название: ");
                            int newRating = GetValidInt("Введите новый рейтинг: ", 0, 10);


                            var platformsForChange = logic.GetAllPlatforms().ToList();
                            if (platformsForChange.Count == 0)
                            {
                                Console.WriteLine("Нет доступных платформ!");
                                break;
                            }

                            Console.WriteLine("Доступные платформы:");
                            for (int i = 0; i < platformsForChange.Count; i++)
                            {
                                Console.WriteLine($"  {i + 1}. {platformsForChange[i].Name}");
                            }

                            Console.Write("Выберите новую платформу (номер): ");
                            int platformChoiceChange = GetValidInt("", 1, platformsForChange.Count) - 1;
                            Guid newPlatformId = platformsForChange[platformChoiceChange].Id; 

                            string newDeveloper = GetValidString("Введите нового разработчика: ");
                            Genre newGenre = GetValidGenre("Введите новый жанр: ");

                            if (logic.ChangeGame(idForChange, newTitle, newRating, newPlatformId, newDeveloper, newGenre))
                            {
                                Console.WriteLine("\nИгра успешно изменена!\n");
                            }
                            else
                            {
                                Console.WriteLine("\nИгра с таким ID не найдена.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nНекорректный формат ID.\n");
                        }
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Список игр для выбора:");
                        var gamesToDeleteFrom = logic.GetAllGames();
                        if (!gamesToDeleteFrom.Any())
                        {
                            Console.WriteLine("У вас нет добавленных игр.");
                            break;
                        }

                        foreach (var game in gamesToDeleteFrom)
                        {
                            Console.WriteLine($"ID: {game.Id} | Название: {game.Title}");
                        }

                        Console.WriteLine("Введите ID игры, которую хотите удалить: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idForDelete))
                        {
                            if (logic.DeleteGame(idForDelete))
                            {
                                Console.WriteLine("\nИгра успешно удалена!\n");
                            }
                            else
                            {
                                Console.WriteLine("\nИгра с таким ID не найдена.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nНекорректный формат ID.\n");
                        }
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("\n--- Игры, сгруппированные по жанрам ---");
                        var groupedGames = logic.GetGamesGroupedByGenre();
                        foreach (var group in groupedGames)
                        {
                            Console.WriteLine($"\n--- Жанр: {group.Key} ---");
                            foreach (var game in group)
                            {
                                Console.WriteLine($" {game.Title} (Рейтинг: {game.Rating}/10)");
                            }
                        }
                        Console.WriteLine("--------------------------------------\n");
                        break;

                    case "6":
                        Console.Clear();

                        var platformsForFilter = logic.GetAllPlatforms().ToList();
                        if (platformsForFilter.Count == 0)
                        {
                            Console.WriteLine("Нет доступных платформ!");
                            break;
                        }

                        Console.WriteLine("Доступные платформы для фильтрации:");
                        for (int i = 0; i < platformsForFilter.Count; i++)
                        {
                            Console.WriteLine($"  {i + 1}. {platformsForFilter[i].Name}");
                        }

                        Console.Write("Выберите платформу (номер): ");
                        int platformChoiceFilter = GetValidInt("", 1, platformsForFilter.Count) - 1;
                        Guid platformIdFilter = platformsForFilter[platformChoiceFilter].Id;  

                        Console.WriteLine($"\n--- Игры на платформе '{platformsForFilter[platformChoiceFilter].Name}' ---");
                        var filteredGames = logic.GetGamesByPlatform(platformIdFilter);  

                        if (!filteredGames.Any())
                        {
                            Console.WriteLine($"Игры не найдены.");
                        }
                        else
                        {
                            foreach (var game in filteredGames)
                            {
                                Console.WriteLine($"{game.Title} (Рейтинг: {game.Rating}/10)");
                            }
                        }
                        Console.WriteLine("-------------------------------------------\n");
                        break;
                }
            }
        }

        /// <summary>
        /// Запрашивает у пользователя строку, пока он не введет непустое значение.
        /// </summary>
        static string GetValidString(string prompt)
        {
            string input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.WriteLine("Ошибка: Ввод не может быть пустым. Попробуйте снова.");
            }
        }

        /// <summary>
        /// Запрашивает у пользователя число в заданном диапазоне.
        /// </summary>
        static int GetValidInt(string prompt, int min, int max)
        {
            int result;
            while (true)
            {
                if (!string.IsNullOrEmpty(prompt))
                    Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result) && result >= min && result <= max)
                {
                    return result;
                }
                Console.WriteLine($"Ошибка: Пожалуйста, введите целое число от {min} до {max}.");
            }
        }

        /// <summary>
        /// Запрашивает у пользователя жанр, пока он не введет существующий.
        /// </summary>
        static Genre GetValidGenre(string prompt)
        {
            Genre result;
            while (true)
            {
                Console.WriteLine(prompt + $" (Доступные: {string.Join(", ", Enum.GetNames(typeof(Genre)))})");
                Console.Write("> ");
                string input = Console.ReadLine();
                if (Enum.TryParse(input, true, out result))
                {
                    return result;
                }
                Console.WriteLine("Ошибка: Такого жанра не существует. Попробуйте снова.");
            }
        }
    }
}

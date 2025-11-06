using BusinessLogical;
using DataAccessLayer;
using Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        private static IKernel kernel;//создаем в каждом классе Program, тк форма и консоль -
                                      //разные процессы с разной памятью
                                      //тут как бы поле, к которому можно обращаться из любых методов в program
                                      //таким образом мы один раз создаем контейнер и сохраняем синглтон
        static void Main(string[] args)
        {
            //стало
            kernel = new StandardKernel(new SimpleConfigModule());
            var logic = kernel.Get<Logic>();

            //было
            //var repository = new DapperGameRepository();     
            /*var repository = new EntityRepository<Game>();
            var logic = new Logic(repository);*/



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

                        string platform = GetValidString("Введите платформу: ");

                        
                        int rating = GetValidInt("Введите ваш рейтинг (1-10): ", 1, 10);


                   
                        logic.AddGame(title, genre, developer, releaseYear, platform, rating);

                        Console.WriteLine("\n--- Игра успешно добавлена! ---\n");

                        

                        break;


                    case "2":
                        //Console.Clear();
                        //Console.WriteLine("\n ---Cписок ваших игр и их свойства---");

                        //string allGamesInfo = logic.GetAll();

                        //if (string.IsNullOrEmpty(allGamesInfo)) 
                        //    {
                        //    Console.WriteLine("У вас пока нет добавленных игр");
                        //    }
                        //else
                        //{
                        //    Console.WriteLine(allGamesInfo);
                        //}




                        //Console.WriteLine("--------------------------------\n");

                        //break;

                        var allGames = logic.GetAllGames(); // Получаем список объектов
                        if (!allGames.Any())
                        {
                            Console.WriteLine("У вас пока нет добавленных игр");
                        }
                        else
                        {
                            // Сами форматируем вывод
                            foreach (var game in allGames)
                            {
                                Console.WriteLine($"Название: {game.Title} | Жанр: {game.GameGenre} | Платформа: {game.Platform} | Рейтинг: {game.Rating}/10");
                            }
                        }
                        Console.WriteLine("--------------------------------\n");
                        break;


                    case "3":
                        Console.Clear();
                        //Console.WriteLine(logic.GetGameListForSelection());

                        //тут я поменял, так как эти два метода (GetGameListForSelection и GetAllGames)
                        //делают одно и тоже, простопроверку перенес так же как и с остальными
                        Console.WriteLine("Список игр для выбора:");
                        var gamesToSelectFrom = logic.GetAllGames();
                        if (!gamesToSelectFrom.Any())
                        {
                            Console.WriteLine("У вас нет добавленных игр.");
                            break; // Выходим из case "3"
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

                            string newPlatform = GetValidString("Введите новую платформу: ");

                            string newDeveloper = GetValidString("Введите нового разработчика: ");

                            Genre newGenre = GetValidGenre("Введите новый жанр: ");

                           

                            if (logic.ChangeGame(idForChange, newTitle, newRating, newPlatform, newDeveloper, newGenre))
                            {
                                Console.WriteLine("\n--- Игра успешно изменена! ---\n");
                            }

                            else
                            {
                                Console.WriteLine("\n--- Игра с таким ID не найдена. ---\n");
                            }
                            

                        }
                        else
                        {
                            Console.WriteLine("\n--- Некорректный формат ID. ---\n");
                        }

                        break;

                        
                       
                    case "4":
                        Console.Clear();
                        //Console.WriteLine(logic.GetGameListForSelection());
                        Console.WriteLine("Список игр для выбора:");
                        var gamesToDeleteFrom = logic.GetAllGames();
                        if (!gamesToDeleteFrom.Any())
                        {
                            Console.WriteLine("У вас нет добавленных игр.");
                            break; // Выходим из case "4"
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
                                Console.WriteLine("\n--- Игра успешно удалена! ---\n");
                            }
                            else
                            {
                                Console.WriteLine("\n--- Игра с таким ID не найдена. ---\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n--- Некорректный формат ID. ---\n");
                        }

                        
                        
                        break;

                    case "5":

                        Console.Clear();
                        Console.WriteLine("\n--- Игры, сгруппированные по жанрам ---");
                        //string groupedResult = logic.GetGamesGroupedByGenre();
                        //Console.WriteLine(groupedResult);
                        //Console.WriteLine("--------------------------------------\n");

                        var groupedGames = logic.GetGamesGroupedByGenre(); 
                        foreach (var group in groupedGames)
                        {
                            Console.WriteLine($"\n--- Жанр: {group.Key} ---");
                            foreach (var game in group)
                            {
                                Console.WriteLine($"    {game.Title} (Рейтинг: {game.Rating}/10)");
                            }
                        }
                        Console.WriteLine("--------------------------------------\n");
                        break;

                        
                        
                    case "6":
                        Console.Clear();
                        Console.Write("Введите платформу для фильтрации (например, PC): ");
                        string platformFilter = Console.ReadLine();


                        Console.WriteLine($"\n--- Игры на платформе '{platformFilter}' ---");


                        //string filteredResult = logic.GetGamesByPlatform(platformFilter);

                        //Console.WriteLine(filteredResult);
                        //Console.WriteLine("-------------------------------------------\n");
                        //break;

                        var filteredGames = logic.GetGamesByPlatform(platformFilter);
                        if (!filteredGames.Any())
                        {
                            Console.WriteLine($"Игры на платформе '{platformFilter}' не найдены.");
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
                
                if (Enum.TryParse<Genre>(input, true, out result))
                {
                    return result; 
                }
                Console.WriteLine("Ошибка: Такого жанра не существует. Попробуйте снова.");
            }
        }

    }
}

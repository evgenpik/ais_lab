using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogical;
using Model;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();

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
                        Console.Clear();
                        Console.WriteLine("\n ---Cписок ваших игр и их свойства---");

                        string allGamesInfo = logic.GetAll();

                        if (string.IsNullOrEmpty(allGamesInfo)) 
                            {
                            Console.WriteLine("У вас пока нет добавленных игр");
                            }
                        else
                        {
                            Console.WriteLine(allGamesInfo);
                        }


                        

                        Console.WriteLine("--------------------------------\n");

                        break;


                    case "3":
                        Console.Clear();
                        Console.WriteLine(logic.GetGameListForSelection());
                        Console.WriteLine("Введите ID игры, которую хотите изменить: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idForChange))
                        {
                            string newTitle = GetValidString("Введите новое название: ");

                            int newRating = GetValidInt("Введите новый рейтинг: ", 0, 10);

                            string newPlatform = GetValidString("Введите новую платформу: ");

                            string newDeveloper = GetValidString("Введите нового разработчика: ");

                            Genre newGenre = GetValidGenre("Введите новый жанр: ");

                            if (newRating > 10) { newRating = 10; }
                            else if (newRating < 1) newRating = 1;

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
                        Console.WriteLine(logic.GetGameListForSelection());

                        Console.Write("Введите ID игры, которую хотите удалить: ");
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
                        string groupedResult = logic.GetGamesGroupedByGenre();
                        Console.WriteLine(groupedResult);
                        Console.WriteLine("--------------------------------------\n");

                        break;
                        
                    case "6":
                        Console.Clear();
                        Console.Write("Введите платформу для фильтрации (например, PC): ");
                        string platformFilter = Console.ReadLine();


                        Console.WriteLine($"\n--- Игры на платформе '{platformFilter}' ---");


                        string filteredResult = logic.GetGamesByPlatform(platformFilter);

                        Console.WriteLine(filteredResult);
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

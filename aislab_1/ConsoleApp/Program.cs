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

                        string title = GetValidString("Введите название игры: ");

                        Genre genre = GetValidGenre("Введите жанр:");

                        string developer = GetValidString("Введите разработчика: ");

                        
                        int currentYear = DateTime.Now.Year;
                        int releaseYear = GetValidInt($"Введите год выпуска (1970-{currentYear}): ", 1970, currentYear);

                        string platform = GetValidString("Введите платформу: ");

                        
                        int rating = GetValidInt("Введите ваш рейтинг (1-10): ", 1, 10);

                        
                        logic.AddGame(title, genre, developer, releaseYear, platform, rating);

                        Console.WriteLine("\n--- Игра успешно добавлена! ---\n");

                        //Console.WriteLine("Введите название игры:");
                        //string title = Console.ReadLine();

                        //Console.WriteLine("Введите жанр:");
                        //string genreInput = Console.ReadLine(); //тоже можно перечислением сделать, но я не уверена
                        //Enum.TryParse<Genre>(genreInput, true, out Genre genre );

                        //Console.WriteLine("Введите разработчика:");
                        //string developer = Console.ReadLine();

                        //Console.WriteLine("Введите год выпуска:");
                        //string releaseYearInput = Console.ReadLine();
                        //int.TryParse(developer, out int releaseYear);


                        //Console.WriteLine("Введите платформу:"); //тут как будто можно сделать перечисление с константами
                        //string platform = Console.ReadLine();

                        //Console.WriteLine("Введите рейтинг:"); //тут интовое значение можно
                        //string ratingInput = Console.ReadLine();
                        //int.TryParse(ratingInput, out int rating);

                        //if (rating > 10)
                        //{
                        //    rating = 10;
                        //}
                        //else if (rating < 1)
                        //{
                        //    rating = 1;
                        //}

                        //logic.AddGame(title, genre, developer, releaseYear, platform, rating); //добавляем игру
                        //Console.WriteLine("\n--- Игра успешно добавлена! ---\n");

                        break;


                    case "2":

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


                        ///foreach (game in logic.Games)
                        ///{
                        ///Console.WriteLine(game.ID, game.Title)
                        ///}
                        ///string idForReading = Console.ReadLine();
                        //Console.WriteLine(logic.ShowInfo(idForReading)); //тип метод, который выводит информацию о свойствах игры

                        Console.WriteLine("--------------------------------\n");

                        break;


                    case "3":
                        Console.WriteLine(logic.GetGameListForSelection());
                        Console.WriteLine("Введите ID игры, которую хотите изменить: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idForChange))
                        {
                            Console.WriteLine("Введите новое название: ");
                            string newTitle = Console.ReadLine();

                            Console.Write("Введите новы рейтинг (1-10): ");
                            int.TryParse(Console.ReadLine(), out int newRating);

                            if (newRating > 10) { newRating = 10; }
                            else if (newRating < 1) newRating = 1;

                            if (logic.ChangeGame(idForChange, newTitle, newRating))
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

                        ///foreach (game in logic.Games)
                        ///{
                        ///Console.WriteLine(game.ID, game.Title)
                        ///}
                        ///

                        //string idForChanging = Console.ReadLine();
                        //logic.ChangeGame(idForChanging) //надо подумать как это реализовать еще
                       
                    case "4":

                        // Сначала показываем пользователю список игр, чтобы он мог выбрать ID
                        Console.WriteLine(logic.GetGameListForSelection());

                        Console.Write("Введите ID игры, которую хотите удалить: ");
                        // Пытаемся безопасно преобразовать введенный текст в Guid
                        if (Guid.TryParse(Console.ReadLine(), out Guid idForDelete))
                        {
                            // Вызываем метод из логики и проверяем результат
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

                        ///foreach (game in logic.Games)
                        ///{
                        ///Console.WriteLine(game.ID, game.Title)
                        ///}
                        
                        
                        break;

                    case "5":

                        Console.WriteLine("\n--- Игры, сгруппированные по жанрам ---");
                        string groupedResult = logic.GetGamesGroupedByGenre();
                        Console.WriteLine(groupedResult);
                        Console.WriteLine("--------------------------------------\n");

                        break;
                        
                    case "6":
                        Console.Write("Введите платформу для фильтрации (например, PC): ");
                        string platformFilter = Console.ReadLine();

                        // Обновляем заголовок, убирая упоминание сортировки
                        Console.WriteLine($"\n--- Игры на платформе '{platformFilter}' ---");

                        // Вызываем наш новый, переименованный метод
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

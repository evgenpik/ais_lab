using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Logic logic = new Logic(); типа класс, который будет отвечать за логику
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
                        Console.WriteLine("Введите название игры:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Введите жанр:");
                        string genre = Console.ReadLine(); //тоже можно перечислением сделать, но я не уверена
                        Console.WriteLine("Введите разработчика:");
                        string developer = Console.ReadLine();
                        Console.WriteLine("Введите год выпуска:");
                        string releaseYear = Console.ReadLine();
                        Console.WriteLine("Введите платформу:"); //тут как будто можно сделать перечисление с константами
                        string platform = Console.ReadLine();
                        Console.WriteLine("Введите рейтинг:"); //тут интовое значение можно
                        string rating = Console.ReadLine();
                        //logic.AddGame(title, genre, developer, releaseYear, platform, rating) //добавляем игру
                        break;
                    case "2":
                        Console.WriteLine("Выберите игру и введите ее ID:");
                        ///foreach (game in logic.Games)
                        ///{
                        ///Console.WriteLine(game.ID, game.Title)
                        ///}
                        string idForReading = Console.ReadLine();
                        //Console.WriteLine(logic.ShowInfo(idForReading)); //тип метод, который выводит информацию о свойствах игры
                        break;
                    case "3":
                        Console.WriteLine("Выберите игру и введите ее ID:");
                        ///foreach (game in logic.Games)
                        ///{
                        ///Console.WriteLine(game.ID, game.Title)
                        ///}
                        string idForChanging = Console.ReadLine();
                        //logic.ChangeGame(idForChanging) //надо подумать как это реализовать еще
                        break;
                    case "4":
                        Console.WriteLine("Выберите игру и введите ее ID:");
                        ///foreach (game in logic.Games)
                        ///{
                        ///Console.WriteLine(game.ID, game.Title)
                        ///}
                        string idForDelete = Console.ReadLine();
                        //Console.WriteLine(logic.DeleteGame(idForDelete));
                        break;
                    case "5":
                        //logic.GenreGroup();
                        break;
                    case "6":
                        Console.WriteLine("Введите платформу и рейтинг");
                        string platformFilter = Console.ReadLine();
                        string ratingFilter = Console.ReadLine();
                        //logic.SortGames(platform, rating)
                        break;
                }

            }
        }
    }
}

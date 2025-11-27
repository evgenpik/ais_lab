using Model;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class GameController
    {
        private readonly IGameService _service;

        // Контроллер получает сервис через конструктор
        public GameController(IGameService service)
        {
            _service = service;
        }

        // Просто передает данные дальше в сервис
        public void AddGame(string title, Genre genre, string developer, int year, Guid platformId, int rating)
        {
            _service.AddGame(title, genre, developer, year, platformId, rating);
        }

        public void DeleteGame(Guid id)
        {
            _service.DeleteGame(id);
        }

        public void UpdateGame(Guid id, string title, int rating, Guid platformId, string developer, Genre genre)
        {
            _service.UpdateGame(id, title, rating, platformId, developer, genre);
        }

        public void AddPlatform(string name)
        {
            _service.TryAddPlatform(name);
        }
    }
}

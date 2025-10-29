using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Game: IDomainObject
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Genre GameGenre { get; set; }
        public string Developer { get; set; }
        public int ReleaseYear { get; set; }

        //public string Platform { get; set; }
        public int Rating { get; set; }

        // 2. Добавил свойство для хранения внешнего ключа (ID платформы).
        //    Тип Guid, чтобы соответствовать новой таблице Platforms.
        public Guid PlatformId { get; set; }

        // 3. Добавил "ненастоящее" свойство для удобного отображения.
        //    Атрибут [NotMapped] говорит Entity Framework, чтобы он НЕ пытался
        //    создать такую колонку в базе данных. Dapper его просто проигнорирует.
        //    Это свойство будет заполняться только при чтении с помощью SQL JOIN.
        [NotMapped]
        public string PlatformName { get; set; }

        


    }
}

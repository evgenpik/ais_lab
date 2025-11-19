using System;
using System.Collections.Generic;
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

        //public string Platform { get; set; } было
        public Guid PlatformId { get; set; }            
        public virtual Platform Platform { get; set; }  // навигационное свойство
        public int Rating { get; set; }


    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    //здесь мы расширяем стандартный EventArgs, чтобы передавать дополнительные данные при событии обновления игры
    public class GameUpdateEventArgs: EventArgs
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public Guid PlatformId { get; set; }
        public string Developer { get; set; }
        public Genre Genre { get; set; }
    }
}

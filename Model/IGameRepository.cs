using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IGameRepository
    {
            void Add(Game game);
            bool Delete(Guid id);
            bool Update(Game game);
            Game GetById(Guid id);
            List<Game> GetAll();
    }
}

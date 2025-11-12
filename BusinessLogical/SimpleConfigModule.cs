using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using DataAccessLayer;
using Model;
namespace BusinessLogical

{
    public class SimpleConfigModule: NinjectModule
    {
        public override void Load()
        {
            //когда кто-то просит IRepository<Game> создается экземпляр нужной реализации один на все приложение
            Bind<IRepository<Game>>().To<EntityRepository<Game>>().InSingletonScope();

            Bind<IRepository<Platform>>().To<EntityRepository<Platform>>().InSingletonScope();
            //Bind<IRepository<Game>>().To<DapperGameRepository>().InSingletonScope();

            //то же самое: если кто-то просит объект Logic, контейнер создает его сам одним экземпляром на все приложение
            Bind<Logic>().ToSelf().InSingletonScope();
        }
    }
}

using BusinessLogical;
using DataAccessLayer;
using Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;
using Controller;

namespace aislab_1
{
    internal static class Program
    {
        private static IKernel kernel;//создаем в каждом классе Program, тк форма и консоль -
                                      //разные процессы с разной памятью
                                      //тут как бы поле, к которому можно обращаться из любых методов в program
                                      //таким образом мы один раз создаем контейнер и сохраняем синглтон




        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            kernel = new StandardKernel(new SimpleConfigModule());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var repository = new DapperGameRepository();
            /*var repository = new EntityRepository<Game>();
            var logic = new Logic(repository);
            Application.Run(new MainForm(logic));*/
            var gameService = kernel.Get<IGameService>();

            
            var controller = new GameController(gameService);

            
            var mainForm = new MainForm();

            
            mainForm.Configure(controller, gameService);

            
            Application.Run(mainForm);

        }
    }
}

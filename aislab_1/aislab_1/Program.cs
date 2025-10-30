using BusinessLogical;
using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aislab_1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var repository = new DapperGameRepository();
            var repository = new EntityRepository<Game>();
            var platformRepository = new EntityRepository<Platform>();
            var logic = new Logic(repository, platformRepository);
            Application.Run(new MainForm(logic));

        }
    }
}

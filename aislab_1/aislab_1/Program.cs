using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using Model;
using BusinessLogical;

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

            var context = new AppDbContext();
            var repository = new EntityRepository<Game>(context);
            var logic = new Logic(repository);
            Application.Run(new MainForm(logic));
        }
    }
}

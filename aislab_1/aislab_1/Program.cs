using BusinessLogical;
using DataAccessLayer;
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

            var repository = new DapperGameRepository();
            var logic = new Logic(repository);
            Application.Run(new MainForm(logic));

            //string connectionString = ConfigurationManager.ConnectionStrings["GamesDatabase"].ConnectionString;


            //var repository = new DapperGameRepository(connectionString);


            //var logic = new Logic(repository);


            //Application.Run(new MainForm(logic));
        }
    }
}

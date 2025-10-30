using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("GamesDatabase")
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }

    }
}

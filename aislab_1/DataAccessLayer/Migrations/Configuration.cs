namespace DataAccessLayer.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            // ЯВНО УКАЗЫВАЕМ КОНТЕКСТ ЗДЕСЬ
            ContextKey = "DataAccessLayer.AppDbContext";
        }

        protected override void Seed(DataAccessLayer.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            if (!context.Platforms.Any())
            {
                context.Platforms.AddRange(new[]
                {
            new Platform { Id = Guid.NewGuid(), Name = "PC" },
            new Platform { Id = Guid.NewGuid(), Name = "PlayStation" },
            new Platform { Id = Guid.NewGuid(), Name = "Xbox" },
            new Platform { Id = Guid.NewGuid(), Name = "Nintendo Switch" },
            new Platform { Id = Guid.NewGuid(), Name = "Other" }
        });

                context.SaveChanges();
            }
        }
    }
}

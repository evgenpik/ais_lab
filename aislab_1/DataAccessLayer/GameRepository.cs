using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{
    /// <summary>
    /// репозиторий для работы с Game через Entity Framework
    /// ReadAll() ВСЕГДА возвращает Game с заполненными платформами через .Join()
    /// </summary>
    public class GameRepository : IRepository<Game>
    {
        #region CRUD методы 

        /// <summary>
        /// добавить новую игру в базу данных
        /// </summary>
        public void Add(Game entity)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Set<Game>().Add(entity);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при добавлении игры", ex);
            }
        }

        /// <summary>
        /// удалить игру по ID
        /// </summary>
        public void Delete(Guid id)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var entity = context.Set<Game>().FirstOrDefault(e => e.Id == id);
                    if (entity != null)
                    {
                        context.Set<Game>().Remove(entity);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при удалении игры с ID {id}", ex);
            }
        }

        /// <summary>
        /// получить все игры с заполненными платформами
        /// </summary>
        public IEnumerable<Game> ReadAll()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var games = context.Games.ToList();
                    var platforms = context.Platforms.ToList();

                    return games
                        .Join(platforms,                    // Соединяем с Platforms
                              g => g.PlatformId,           // ключ в Games
                              p => p.Id,                   // ключ в Platforms
                              (g, p) => {                  // результирующая функция
                                  g.PlatformName = p.Name; // заполняем PlatformName
                                  return g;
                              })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении всех игр", ex);
            }
        }

        /// <summary>
        /// получить игру по ID
        /// </summary>
        public Game ReadById(Guid id)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Set<Game>().FirstOrDefault(e => e.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении игры с ID {id}", ex);
            }
        }

        /// <summary>
        /// обновить существующую игру
        /// </summary>
        public void Update(Game entity)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обновлении игры", ex);
            }
        }

        #endregion

        #region Дополнительные методы

        /// <summary>
        /// получить все платформы (для ComboBox и тп)
        /// </summary>
        public List<Platform> GetAllPlatforms()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    return context.Platforms.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении платформ", ex);
            }
        }

        #endregion

    }
}

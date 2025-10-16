using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    { ///вообще здесь каждый раз создается новый контекст, тк EF кэширует данные и там короче не обновляются они
      /// если использовать один контекст на все операции, то можно столкнуться с проблемами кэширования
      /// можно и без этого, использовать один контекст, но тогда нужно будет вручную управлять состоянием сущностей

      /// <summary>
      /// Метод для добавления сущности
      /// </summary>
      /// <param name="entity"></param>
        public void Add(T entity)
        {
            
            using (var context = new AppDbContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Метод для удаления сущности по Id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
            
            using (var context = new AppDbContext())
            {
                var entity = context.Set<T>().FirstOrDefault(e => e.Id == id);
                if (entity != null)
                {
                    context.Set<T>().Remove(entity);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Метод для получения всех сущностей
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> ReadAll()
        {
            
            using (var context = new AppDbContext())
            {
                return context.Set<T>().ToList();
            }
        }

        /// <summary>
        /// Метод для чтения сущности по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T ReadById(Guid id)
        {
            using (var context = new AppDbContext())
            {
                return context.Set<T>().FirstOrDefault(e => e.Id == id);
            }

        }
        /// <summary>
        /// Метод для обновления сущностей
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            using (var _context = new AppDbContext())
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
               
        }
    }
}

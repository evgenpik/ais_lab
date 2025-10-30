using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace DataAccessLayer
{
    public class DapperGameRepository : IRepository<Game>
    {
        private readonly string _connectionString;

        public DapperGameRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["GamesDatabase"].ConnectionString;
        }

        //Каждый раз, когда мы обращаемся к "Connection",
        // оно будет создавать НОВЫЙ объект подключения к базе с нашим адресом.
        private IDbConnection Connection => new SqlConnection(_connectionString);




        public List<Platform> GetAllPlatforms()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var sql = "SELECT * FROM Platforms";
                    return connection.Query<Platform>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении платформ", ex);
            }
        }
        /// <summary>
        /// Реализует добавление игры в базу данных
        /// </summary>
        /// <param name="entity"></param>
        public void Add(Game entity)
        {
            // Создаем и открываем подключение к базе данных. using гарантирует, что ресурс будет освобожден после использования.
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Games (Id, Title, GameGenre, Developer, ReleaseYear, Platform, Rating) " +
                          "VALUES (@Id, @Title, @GameGenre, @Developer, @ReleaseYear, @Platform, @Rating)";

                // Dapper выполняет команду, автоматически подставляя значения
                // из свойств объекта "entity" в одноименные параметры в "sql".
                connection.Execute(sql, entity);
            }
        }

        /// <summary>
        /// Реализует удаление игры из базы данных по её идентификатору
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Games WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }

        /// <summary>
        /// Извлекает все игры из базы данных.
        /// </summary>
        /// <remarks>Этот метод выполняет SQL-запрос для получения всех записей из таблицы «Games» и
        /// возвращает их в виде коллекции <see cref="Game"/> objects.</remarks>
        /// <returns>An <see cref="IEnumerable{T}"/> Содержит все игры из базы данных. 
        /// Коллекция будет пустой, если игры не найдены.</returns>
        public IEnumerable<Game> ReadAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Games";

                // connection.Query<Game>(sql) - Dapper выполняет SQL-запрос,
                // получает результат и для каждой строки пытается создать объект Game,
                // сопоставляя имена колонок с именами свойств.
                // .ToList() - превращает результат в конкретный список.
                return connection.Query<Game>(sql).ToList();
            }
        }
        /// <summary>
        /// Извлекает игру из базы данных по её уникальному идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор игры для получения данных.</param>
        /// <returns>The <see cref="Game"/> object that matches the specified identifier, or <see langword="null"/>  Объект, 
        /// соответствующий указанному идентификатору, или отсутствие игры
        /// с указанным идентификатором.</returns>
        public Game ReadById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Games WHERE Id = @Id";
                return connection.QuerySingleOrDefault<Game>(sql, new { Id = id });
            }
        }
        /// <summary>
        /// Обновляет указанный игровой объект в базе данных.
        /// </summary>
        /// <remarks>Этот метод обновляет запись в базе данных, соответствующую <c>Id</c> из
        /// предоставленных <paramref name="entity"/>. Нужно убедиться в том,что <paramref name="entity"/> в форме заполнены все обязательные поля,
        /// так как отсутствие или неверность данных могут привести к неполному или неудачному обновлению.</remarks>
        /// <param name="entity">Игровой объект, который необходимо обновить. Объект должен иметь действительный <c>Id</c> и содержать обновлённые значения для
        /// игры.</param>
        public void Update(Game entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE Games SET Title = @Title, GameGenre = @GameGenre, Developer = @Developer, " +
                          "ReleaseYear = @ReleaseYear, Platform = @Platform, Rating = @Rating WHERE Id = @Id";
                
                connection.Execute(sql, entity);
            }
        }
    }
}

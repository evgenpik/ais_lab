using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;

namespace DataAccessLayer
{
    /// <summary>
    /// Репозиторий для работы с Game через Dapper
    /// ReadAll() ВСЕГДА возвращает Game с заполненными платформами через SQL JOIN
    /// </summary>
    public class DapperGameRepositoryVer2 : IRepository<Game>
    {
        private readonly string _connectionString;

        public DapperGameRepositoryVer2()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["GamesDatabase"].ConnectionString;
        }

        #region CRUD методы (реализация IRepository<Game>)

        /// <summary>
        /// Добавить новую игру в базу данных
        /// </summary>
        public void Add(Game entity)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var sql = @"INSERT INTO Games (Id, Title, GameGenre, Developer, ReleaseYear, PlatformId, Rating) 
                               VALUES (@Id, @Title, @GameGenre, @Developer, @ReleaseYear, @PlatformId, @Rating)";

                    connection.Execute(sql, entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении игры", ex);
            }
        }

        /// <summary>
        /// Удалить игру по ID
        /// </summary>
        public void Delete(Guid id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var sql = "DELETE FROM Games WHERE Id = @Id";
                    connection.Execute(sql, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при удалении игры с ID {id}", ex);
            }
        }

        /// <summary>
        /// Получить все игры с заполненными платформами
        /// ✅ ВСЕГДА с платформами через SQL LEFT JOIN
        /// </summary>
        public IEnumerable<Game> ReadAll()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var sql = @"SELECT g.Id, 
                                      g.Title, 
                                      g.GameGenre, 
                                      g.Developer, 
                                      g.ReleaseYear, 
                                      g.PlatformId, 
                                      p.Name AS PlatformName, 
                                      g.Rating
                               FROM Games g
                               LEFT JOIN Platforms p ON g.PlatformId = p.Id";

                    return connection.Query<Game>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении всех игр", ex);
            }
        }

        /// <summary>
        /// Получить игру по ID
        /// </summary>
        public Game ReadById(Guid id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var sql = "SELECT * FROM Games WHERE Id = @Id";
                    return connection.QuerySingleOrDefault<Game>(sql, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении игры с ID {id}", ex);
            }
        }

        /// <summary>
        /// Обновить существующую игру
        /// </summary>
        public void Update(Game entity)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var sql = @"UPDATE Games 
                               SET Title = @Title, 
                                   GameGenre = @GameGenre, 
                                   Developer = @Developer, 
                                   ReleaseYear = @ReleaseYear, 
                                   PlatformId = @PlatformId, 
                                   Rating = @Rating 
                               WHERE Id = @Id";

                    connection.Execute(sql, entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении игры", ex);
            }
        }

        #endregion

        #region Дополнительные методы

        /// <summary>
        /// ✅ Получить все платформы (для ComboBox и других нужд)
        /// </summary>
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

        #endregion
    }
}

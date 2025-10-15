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

        private IDbConnection Connection => new SqlConnection(_connectionString);

        //public DapperGameRepository(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}
        public void Add(Game entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Games (Id, Title, GameGenre, Developer, ReleaseYear, Platform, Rating) " +
                          "VALUES (@Id, @Title, @GameGenre, @Developer, @ReleaseYear, @Platform, @Rating)";
                connection.Execute(sql, entity);
            }
        }
        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Games WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
        public IEnumerable<Game> ReadAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Games";
                return connection.Query<Game>(sql).ToList();
            }
        }
        public Game ReadById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Games WHERE Id = @Id";
                return connection.QuerySingleOrDefault<Game>(sql, new { Id = id });
            }
        }
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

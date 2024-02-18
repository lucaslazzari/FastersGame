using Dapper;
using FasterGame.Core.Entities;
using FasterGame.Core.Repositories;
using Microsoft.Data.SqlClient;

namespace FasterGame.Infrastructure.Repositories
{
    public class UserService : IUserService
    {
        string _connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=FasterGame;Integrated Security=True;TrustServerCertificate=True";
        public async Task AddAsync(User user)
        {
            //*DAPPER*
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = "INSERT INTO Users(FullName, Email, BirthDate, Passwords) VALUES(@FullName, @Email, @BirthDate, @Passwords)";

                await sqlConnection.ExecuteAsync(script, new { FullName = user.FullName, Email = user.Email, BirthDate = user.BirthDate, Passwords = user.Passwords });
            }
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            //*DAPPER*
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = $"SELECT * FROM Users WHERE Email = '{email}' AND Passwords = '{password}'";

                var user = await sqlConnection.QueryAsync<User>(script);

                return user.FirstOrDefault();
            }
        }

        public async Task<User> GetUserByIdUser(int idUser)
        {
            //*DAPPER*
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = "SELECT * FROM Users WHERE IdUser = " + idUser;

                var user = await sqlConnection.QueryAsync<User>(script);

                return user.FirstOrDefault();
            }
        }

        public async Task UpdateIdPlayerAsync(int idPlayer , int idUser)
        {
            //*DAPPER*
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = $"UPDATE Users SET IdPlayer = {idPlayer} WHERE IdUser = {idUser}";

                await sqlConnection.ExecuteAsync(script);
            }
        }
    }
}
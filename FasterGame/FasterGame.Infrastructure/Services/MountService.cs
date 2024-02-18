using Dapper;
using FasterGame.Core.Entities;
using FasterGame.Core.Services;
using Microsoft.Data.SqlClient;

namespace FasterGame.Infrastructure.Services
{
    public class MountService : IMountService
    {
        string _connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=FasterGame;Integrated Security=True;TrustServerCertificate=True";
        public async Task AddAsync(Mount mount)
        {
            //*DAPPER*
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = "INSERT INTO Mount(MountName, MovimentSpeed, RestTime) VALUES(@MountName, @MovimentSpeed, @RestTime)";

                await sqlConnection.ExecuteAsync(script, new { MountName = mount.MountName, MovimentSpeed = mount.MovimentSpeed, RestTime = mount.RestTime });
            }
        }

        public async Task<int> GetMaxIdMountAsync()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = "SELECT MAX(IdMount) FROM Mount";

                IEnumerable<int> idMount = await sqlConnection.QueryAsync<int>(script);

                return idMount.FirstOrDefault();
            }
        }

        public async Task<Mount> GetMountByIdMountAsync(int idMount)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = "SELECT MountName, MovimentSpeed, RestTime FROM Mount";

                IEnumerable<Mount> mount = await sqlConnection.QueryAsync<Mount>(script);

                return mount.FirstOrDefault();
            }
        }
    }
}

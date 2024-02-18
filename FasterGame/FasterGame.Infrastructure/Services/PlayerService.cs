using Dapper;
using FasterGame.Core.Entities;
using FasterGame.Core.Services;
using Microsoft.Data.SqlClient;
using System.Drawing;

namespace FasterGame.Infrastructure.Services
{
    public class PlayerService : IPlayerService
    {
        string _connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=FasterGame;Integrated Security=True;TrustServerCertificate=True";

        public async Task AddAsync(Player player)
        {
            //*DAPPER*
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = "INSERT INTO Player(IdPlayerType, IdFisicCharacteristics, IdMount) VALUES(@IdPlayerType, @IdFisicCharacteristics, @IdMount)";

                await sqlConnection.ExecuteAsync(script, new { IdPlayerType = player.IdPlayerType, IdFisicCharacteristics = player.IdFisicCharacteristics, IdMount = player.IdMount });
            }
        }

        public async Task<int> GetMaxIdPlayerAsync()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = "SELECT MAX(IdPlayer) FROM Player";

                IEnumerable<int> idPlayer = await sqlConnection.QueryAsync<int>(script);

                return idPlayer.FirstOrDefault();
            }
        }

        public async Task<Player> GetPlayerByIdPlayerAsync(int idPlayer)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = "SELECT * FROM Player WHERE IdPlayer = " + idPlayer;

                IEnumerable<Player> player = await sqlConnection.QueryAsync<Player>(script);

                return player.FirstOrDefault();
            }
        }
    }
}

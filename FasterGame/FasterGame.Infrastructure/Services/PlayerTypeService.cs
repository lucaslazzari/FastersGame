using Dapper;
using FasterGame.Core.Entities;
using FasterGame.Core.Services;
using Microsoft.Data.SqlClient;

namespace FasterGame.Infrastructure.Services
{
    public class PlayerTypeService : IPlayerTypeService
    {
        string _connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=FasterGame;Integrated Security=True;TrustServerCertificate=True";
        public async Task AddAsync(PlayerType playerType)
        {
            //*DAPPER*
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = "INSERT INTO PlayerType(NameType, Weapon, Life, Mana, AtackSpeed) VALUES(@NameType, @Weapon, @Life, @Mana, @AtackSpeed)";

                await sqlConnection.ExecuteAsync(script, new { NameType = playerType.NameType, Weapon = playerType.Weapon, Life = playerType.Life, Mana = playerType.Mana, AtackSpeed = playerType.AtackSpeed });
            }
        }

        public async Task<int> GetMaxIdPlayerTypeAsync()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = "SELECT MAX(IdPlayerType) FROM PlayerType";

                IEnumerable<int> idPlayerType = await sqlConnection.QueryAsync<int>(script);

                return idPlayerType.FirstOrDefault();
            }
        }

        public async Task<PlayerType> GetPlayerTypeByIdPlayerTypeAsync(int idPlayerType)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = "SELECT NameType, Weapon, Life, Mana, AtackSpeed FROM PlayerType WHERE IdPlayerType = " + idPlayerType;

                IEnumerable<PlayerType> playerType = await sqlConnection.QueryAsync<PlayerType>(script);

                return playerType.FirstOrDefault();
            }
        }
    }
}

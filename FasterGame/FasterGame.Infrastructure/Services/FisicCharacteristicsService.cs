using Dapper;
using FasterGame.Core.Entities;
using FasterGame.Core.Services;
using Microsoft.Data.SqlClient;

namespace FasterGame.Infrastructure.Services
{
    public class FisicCharacteristicsService : IFisicCharacteristicsService
    {
        string _connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=FasterGame;Integrated Security=True;TrustServerCertificate=True";
        public async Task AddAsync(FisicCharacteristics fisicCharacteristics)
        {
            //*DAPPER*
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = "INSERT INTO FisicCharacteristics(HairColor, SkinColor, EyeColor, Biotype) VALUES(@HairColor, @SkinColor, @EyeColor, @Biotype)";

                await sqlConnection.ExecuteAsync(script, new { HairColor = fisicCharacteristics.HairColor, SkinColor = fisicCharacteristics.SkinColor, EyeColor = fisicCharacteristics.EyeColor, Biotype = fisicCharacteristics.Biotype });
            }
        }

        public async Task<FisicCharacteristics> GetFisicCharacteristicsByIdFisicCharacteristicsAsync(int idFisicCharacteristics)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = "SELECT HairColor, SkinColor, EyeColor, Biotype FROM FisicCharacteristics WHERE IdFisicCharacteristics = " + idFisicCharacteristics;

                IEnumerable<FisicCharacteristics> fisicCharacteristics = await sqlConnection.QueryAsync<FisicCharacteristics>(script);

                return fisicCharacteristics.FirstOrDefault();
            }
        }

        public async Task<int> GetMaxIdFisicCharacteristicsAsync()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string script = "SELECT MAX(IdFisicCharacteristics) FROM FisicCharacteristics";

                IEnumerable<int> idFisicCharacteristics = await sqlConnection.QueryAsync<int>(script);

                return idFisicCharacteristics.FirstOrDefault();
            }
        }
    }
}

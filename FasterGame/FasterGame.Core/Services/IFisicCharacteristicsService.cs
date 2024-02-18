using FasterGame.Core.Entities;

namespace FasterGame.Core.Services
{
    public interface IFisicCharacteristicsService
    {
        Task AddAsync(FisicCharacteristics fisicCharacteristics);
        Task<int> GetMaxIdFisicCharacteristicsAsync();
        Task<FisicCharacteristics> GetFisicCharacteristicsByIdFisicCharacteristicsAsync(int idFisicCharacteristics);
    }
}

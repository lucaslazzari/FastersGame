using FasterGame.Core.Entities;

namespace FasterGame.Core.Services
{
    public interface IPlayerTypeService
    {
        Task AddAsync(PlayerType playerType);
        Task<int> GetMaxIdPlayerTypeAsync();

        Task<PlayerType> GetPlayerTypeByIdPlayerTypeAsync(int idPlayerType);
    }
}

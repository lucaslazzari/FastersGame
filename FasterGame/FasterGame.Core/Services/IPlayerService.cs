using FasterGame.Core.Entities;

namespace FasterGame.Core.Services
{
    public interface IPlayerService
    {
        Task AddAsync(Player player);
        Task<int> GetMaxIdPlayerAsync();
        Task<Player> GetPlayerByIdPlayerAsync(int idPlayer);
    }
}

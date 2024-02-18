using FasterGame.Application.ViewModels;

namespace FasterGame.Application.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Task CreatePlayerAsync(PlayerViewModel playerViewModel);
        Task<PlayerViewModel> GetPlayerByIdPlayerAsync(int idPlayer);
    }
}

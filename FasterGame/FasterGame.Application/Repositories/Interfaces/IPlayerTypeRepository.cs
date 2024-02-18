using FasterGame.Application.ViewModels;

namespace FasterGame.Application.Repositories.Interfaces
{
    public interface IPlayerTypeRepository
    {
        Task<int> ChoosePlayerTypeAsync();
        Task GetPlayerTypeAsync(int idPlayerType);
    }
}

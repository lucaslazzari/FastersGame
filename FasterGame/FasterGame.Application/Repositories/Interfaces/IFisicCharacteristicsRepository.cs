using FasterGame.Application.ViewModels;

namespace FasterGame.Application.Repositories.Interfaces
{
    public interface IFisicCharacteristicsRepository
    {
        string ChooseHairColor();
        string ChooseSkinColor();
        string ChooseEyeColor();
        string ChooseBiotype();
        Task<int> CreateFisicCharacteristicsAsync();
        Task GetFisicCharacteristicsAsync(int idFisicCharacteristics);
    }
}

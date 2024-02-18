namespace FasterGame.Application.Repositories.Interfaces
{
    public interface IMountRepository
    {
        Task<int> ChooseMountAsync();
        Task GetMountAsync(int idMount);
    }
}

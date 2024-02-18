using FasterGame.Core.Entities;

namespace FasterGame.Core.Services
{
    public interface IMountService
    {
        Task AddAsync(Mount mount);
        Task<int> GetMaxIdMountAsync();
        Task<Mount> GetMountByIdMountAsync(int idMount);
    }
}

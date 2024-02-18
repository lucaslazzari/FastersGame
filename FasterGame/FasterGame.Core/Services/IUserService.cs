using FasterGame.Core.Entities;

namespace FasterGame.Core.Repositories
{
    public interface IUserService
    {
        Task AddAsync(User user);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
        Task UpdateIdPlayerAsync(int idPlayer, int idUser);
        Task<User> GetUserByIdUser(int idUser);
    }
}

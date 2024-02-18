using FasterGame.Application.ViewModels;
using FasterGame.Core.Entities;

namespace FasterGame.Application.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUserAsync(CreateUserViewModel createUserViewModel);
        Task<User> LoginUserAsync(LoginUserViewModel loginUserViewModel);
        Task UpdateIdPlayerAsync(int id);
        Task<User> GetUserAsync(int idUser);
    }
}

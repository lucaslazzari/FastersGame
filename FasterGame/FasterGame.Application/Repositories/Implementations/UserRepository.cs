using FasterGame.Application.Repositories.Interfaces;
using FasterGame.Application.ViewModels;
using FasterGame.Core.Entities;
using FasterGame.Core.Exceptions;
using FasterGame.Core.Repositories;
using FasterGame.Core.Services;

namespace FasterGame.Application.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserService _userService;
        private readonly IPlayerService _playerService;
        public UserRepository(IUserService userService, IPlayerService playerService)
        {
            _userService = userService;
            _playerService = playerService;
        }

        public async Task CreateUserAsync(CreateUserViewModel createUserViewModel)
        {
            Console.WriteLine("Nome Completo:");
            createUserViewModel.FullName = Console.ReadLine();
            Console.WriteLine("Data de Nascimento:");
            createUserViewModel.BirthDate = Console.ReadLine();
            Console.WriteLine("Email:");
            createUserViewModel.Email = Console.ReadLine();
            Console.WriteLine("Senha:");
            createUserViewModel.Password = Console.ReadLine();
            Console.WriteLine("Confirmar Senha");
            var passwordConfirm = Console.ReadLine();

            if(createUserViewModel.Password != passwordConfirm) 
                throw new PasswordsNotEqualException();

            User user = new User(createUserViewModel.FullName, createUserViewModel.BirthDate, createUserViewModel.Email, createUserViewModel.Password);
            await _userService.AddAsync(user);
        }

        public async Task<User> GetUserAsync(int idUser)
        {
            User user = new User();
            user = await _userService.GetUserByIdUser(idUser);
            return user;
        }

        public async Task<User> LoginUserAsync(LoginUserViewModel loginUserViewModel)
        {
            Console.WriteLine("Email:");
            loginUserViewModel.Email = Console.ReadLine();
            Console.WriteLine("Senha:");
            loginUserViewModel.Password = Console.ReadLine();

            var user = await _userService.GetUserByEmailAndPasswordAsync(loginUserViewModel.Email, loginUserViewModel.Password);

            if (user == null) 
                throw new UserNonExistentException();

            return user;
        }

        public async Task UpdateIdPlayerAsync(int id)
        {
            var idPlayer = await _playerService.GetMaxIdPlayerAsync();
            await _userService.UpdateIdPlayerAsync(idPlayer, id);
        }
    }
}

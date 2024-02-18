using FasterGame.Application.Repositories.Implementations;
using FasterGame.Application.Repositories.Interfaces;
using FasterGame.Application.ViewModels;
using FasterGame.Core.Entities;
using FasterGame.Core.Exceptions;
using FasterGame.Core.Repositories;
using FasterGame.Core.Services;
using FasterGame.Infrastructure.Repositories;
using FasterGame.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // Configuração da injeção de dependencia
        var serviceCollection = new ServiceCollection();

        serviceCollection
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IPlayerTypeRepository, PlayerTypeRepository>()
            .AddScoped<IPlayerTypeService, PlayerTypeService>()
            .AddScoped<IFisicCharacteristicsRepository, FisicCharacteristicsRepository>()
            .AddScoped<IFisicCharacteristicsService, FisicCharacteristicsService>()
            .AddScoped<IMountRepository, MountRepository>()
            .AddScoped<IMountService, MountService>()
            .AddScoped<IPlayerRepository, PlayerRepository>()
            .AddScoped<IPlayerService, PlayerService>();

        // Criando as variaveis da injeção de dependencia para usar os repositorios
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var user = serviceProvider.GetRequiredService<IUserRepository>();
        var playerType = serviceProvider.GetRequiredService<IPlayerTypeRepository>();
        var fisicCharacteristics = serviceProvider.GetRequiredService<IFisicCharacteristicsRepository>();
        var mount = serviceProvider.GetRequiredService<IMountRepository>();
        var player = serviceProvider.GetRequiredService<IPlayerRepository>();


        // Iniciando Codigo do menu
        bool condiction = true;
        int opctionUser = 0;
        while (condiction)
        {
            Console.WriteLine("MENU PRINCIPAL:");
            Console.WriteLine("1 - Cadastrar conta");
            Console.WriteLine("2 - Fazer Login");
            try
            {
                opctionUser = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

            switch (opctionUser)
            {
                case 1:
                    try
                    {
                        CreateUserViewModel createUserViewModel = new CreateUserViewModel();
                        await user.CreateUserAsync(createUserViewModel);
                        break;
                    }
                    catch(PasswordsNotEqualException ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    catch(Exception ex) 
                    { 
                        Console.WriteLine(ex.Message);
                        break;
                    }
                case 2:
                    try
                    {
                        LoginUserViewModel loginUserViewModel = new LoginUserViewModel();
                        User userDetails = await user.LoginUserAsync(loginUserViewModel);
                        //Se usuario nao tiver personagem cadastrado , cadastre um novo
                        if (userDetails.IdPlayer == null)
                        {
                            //Cadastro do Tipo , Caracteristicas Fisicas e Montaria do Boneco
                            int playerTypeId = await playerType.ChoosePlayerTypeAsync();
                            int fisicCharacteristicsId = await fisicCharacteristics.CreateFisicCharacteristicsAsync();
                            int mountId = await mount.ChooseMountAsync();
                            PlayerViewModel playerViewModel = new PlayerViewModel();
                            await player.CreatePlayerAsync(playerViewModel);

                            //Atualizando tabela Usuario com o Id do Boneco cadastrado
                            await user.UpdateIdPlayerAsync(userDetails.IdUser);

                            //Imprimindo na Tela dados do Boneco escolhido
                            User userAtualization = await user.GetUserAsync(userDetails.IdUser);
                            PlayerViewModel playerDetails = await player.GetPlayerByIdPlayerAsync(Convert.ToInt32(userAtualization.IdPlayer));
                            await playerType.GetPlayerTypeAsync(playerDetails.IdPlayerType);
                            await fisicCharacteristics.GetFisicCharacteristicsAsync(playerDetails.IdFisicCharacteristics);
                            await mount.GetMountAsync(playerDetails.IdMount);
                            break;
                        }
                        else
                        {
                            //Se tiver cadastrado apenas imprime o personagem
                            //Imprimindo na Tela dados do personagem escolhido
                            var userAtualization = await user.GetUserAsync(userDetails.IdUser);
                            var playerDetails = await player.GetPlayerByIdPlayerAsync(Convert.ToInt32(userAtualization.IdPlayer));
                            await playerType.GetPlayerTypeAsync(playerDetails.IdPlayerType);
                            await fisicCharacteristics.GetFisicCharacteristicsAsync(playerDetails.IdFisicCharacteristics);
                            await mount.GetMountAsync(playerDetails.IdMount);
                            break;
                        }
                    }
                    catch(UserNonExistentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
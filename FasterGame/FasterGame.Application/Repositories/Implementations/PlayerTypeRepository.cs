using FasterGame.Application.Repositories.Interfaces;
using FasterGame.Application.ViewModels;
using FasterGame.Core.Entities;
using FasterGame.Core.Services;

namespace FasterGame.Application.Repositories.Implementations
{
    public class PlayerTypeRepository : IPlayerTypeRepository
    {
        private readonly IPlayerTypeService _playerTypeService;
        private readonly IPlayerService _playerService;
        public PlayerTypeRepository(IPlayerTypeService playerTypeService, IPlayerService playerService)
        {
            _playerTypeService = playerTypeService;
            _playerService = playerService;

        }
        public async Task<int> ChoosePlayerTypeAsync()
        {
            PlayerType playerType = new PlayerType();
            int optionPlayer = 0;
            Console.WriteLine("ESCOLHA SEU PERSONAGEM");
            Console.WriteLine("1 - Paladino");
            Console.WriteLine("2 - Atirador");
            Console.WriteLine("3 - Arqueiro");
            Console.WriteLine("4 - Barbaro");
            Console.WriteLine("5 - Guerreiro");
            try
            {
                optionPlayer = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            switch (optionPlayer)
            {
                case 1:
                    int optionPaladin = 0;
                    Console.WriteLine("ARMA");
                    Console.WriteLine("1 - Lanca ( Vida:85 / Mana:35 / Velocidade de Ataque: 1,25)");
                    Console.WriteLine("2 - Escudo ( Vida:95 / Mana:38 / Velocidade de Ataque: 1,10)");
                    optionPaladin = Convert.ToInt32(Console.ReadLine());
                    switch (optionPaladin)
                    {
                        case 1:
                            playerType.PaladinSpear();
                            await _playerTypeService.AddAsync(playerType);
                            break;
                        case 2:
                            playerType.PaladinShield();
                            await _playerTypeService.AddAsync(playerType);
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    int optionShooter = 0;
                    Console.WriteLine("ARMA");
                    Console.WriteLine("1 - Espingarda ( Vida:70 / Mana:50 / Velocidade de Ataque:1,75 )");
                    optionShooter = Convert.ToInt32(Console.ReadLine());
                    switch (optionShooter)
                    {
                        case 1:
                            playerType.ShooterShotgun();
                            await _playerTypeService.AddAsync(playerType);
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    int optionArcher = 0;
                    Console.WriteLine("ARMA");
                    Console.WriteLine("1 - Arco e Flecha ( Vida:80 / Mana:35 / Velocidade de Ataque:1,50 )");
                    optionArcher = Convert.ToInt32(Console.ReadLine());
                    switch (optionArcher)
                    {
                        case 1:
                            playerType.AcherArchery();
                            await _playerTypeService.AddAsync(playerType);
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    int optionBarbarian = 0;
                    Console.WriteLine("ARMA");
                    Console.WriteLine("1 - Machado ( Vida:115 / Mana:24 / Velocidade de Ataque:1,0 )");
                    Console.WriteLine("2 - Marreta ( Vida:120 / Mana:22 / Velocidade de Ataque:0,95 )");
                    optionBarbarian = Convert.ToInt32(Console.ReadLine());
                    switch (optionBarbarian)
                    {
                        case 1:
                            playerType.BarbarianAx();
                            await _playerTypeService.AddAsync(playerType);
                            break;
                        case 2:
                            playerType.BarbarianSledgehammer();
                            await _playerTypeService.AddAsync(playerType);
                            break;
                        default:
                            break;
                    }
                    break;
                case 5:
                    int optionWarrior = 0;
                    Console.WriteLine("ARMA");
                    Console.WriteLine("1 - Espada ( Vida:100 / Mana:27 / Velocidade de Ataque:1,15 )");
                    Console.WriteLine("2 - Escudo ( Vida:115 / Mana:27 / Velocidade de Ataque:1,10 )");
                    optionWarrior = Convert.ToInt32(Console.ReadLine());
                    switch (optionWarrior)
                    {
                        case 1:
                            playerType.WarriorSword();
                            await _playerTypeService.AddAsync(playerType);
                            break;
                        case 2:
                            playerType.WarriorShield();
                            await _playerTypeService.AddAsync(playerType);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return playerType.IdPlayerType;
        }

        public async Task GetPlayerTypeAsync(int idPlayerType)
        {
            PlayerType playerType = await _playerTypeService.GetPlayerTypeByIdPlayerTypeAsync(idPlayerType);

            PlayerTypeViewModel playerTypeViewModel = new PlayerTypeViewModel(
                playerType.NameType,
                playerType.Weapon,
                playerType.Life,
                playerType.Mana,
                playerType.AtackSpeed
                );

            Console.WriteLine();
            Console.WriteLine("PERSONAGEM");
            Console.WriteLine("Nome: " + playerTypeViewModel.NameType);
            Console.WriteLine("Arma: " + playerTypeViewModel.Weapon);
            Console.WriteLine("Vida: " + playerTypeViewModel.Life);
            Console.WriteLine("Mana: " + playerTypeViewModel.Mana);
            Console.WriteLine("Velocidade de ataque: " + playerTypeViewModel.AtackSpeed);
            Console.WriteLine();
        }
    }
}

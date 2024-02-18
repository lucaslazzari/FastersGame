using FasterGame.Application.Repositories.Interfaces;
using FasterGame.Application.ViewModels;
using FasterGame.Core.Entities;
using FasterGame.Core.Services;

namespace FasterGame.Application.Repositories.Implementations
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IPlayerService _playerService;
        private readonly IPlayerTypeService _playerTypeService;
        private readonly IMountService _mountService;
        private readonly IFisicCharacteristicsService _fisicCharacteristicsService;
        public PlayerRepository(IPlayerService playerService, IPlayerTypeService playerTypeService, 
            IMountService mountService, IFisicCharacteristicsService fisicCharacteristicsService)
        {
            _playerService = playerService;
            _playerTypeService = playerTypeService;
            _mountService = mountService;
            _fisicCharacteristicsService = fisicCharacteristicsService;

        }
        public async Task CreatePlayerAsync(PlayerViewModel playerViewModel)
        {
            var idPlayerType = await _playerTypeService.GetMaxIdPlayerTypeAsync();
            var idFisicCharacteristics = await _fisicCharacteristicsService.GetMaxIdFisicCharacteristicsAsync();
            var idMount = await _mountService.GetMaxIdMountAsync();

            playerViewModel.IdPlayerType = Convert.ToInt32(idPlayerType);
            playerViewModel.IdFisicCharacteristics = Convert.ToInt32(idFisicCharacteristics);
            playerViewModel.IdMount = Convert.ToInt32(idMount);

            Player player = new Player(playerViewModel.IdPlayerType, playerViewModel.IdFisicCharacteristics, playerViewModel.IdMount);
            await _playerService.AddAsync(player);
        }

        public async Task<PlayerViewModel> GetPlayerByIdPlayerAsync(int idPlayer)
        {
            
            Player player = await _playerService.GetPlayerByIdPlayerAsync(idPlayer);

            PlayerViewModel playerViewModel = new PlayerViewModel(
                player.IdPlayerType,
                player.IdFisicCharacteristics,
                player.IdMount
                );
            return playerViewModel;
        }
    }
}

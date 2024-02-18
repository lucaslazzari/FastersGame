using FasterGame.Application.Repositories.Interfaces;
using FasterGame.Application.ViewModels;
using FasterGame.Core.Entities;
using FasterGame.Core.Services;

namespace FasterGame.Application.Repositories.Implementations
{
    public class MountRepository : IMountRepository
    {
        private readonly IMountService _mountService;
        public MountRepository(IMountService mountService)
        {
            _mountService = mountService;
        }
        public async Task<int> ChooseMountAsync()
        {
            Mount mount = new Mount();
            int optionMount = 0;
            Console.WriteLine("ESCOLHA SEU PERSONAGEM");
            Console.WriteLine("1 - Cavalo ( Velocidade Movimento:8 / Descanso:7min )");
            Console.WriteLine("2 - Panda ( Velocidade Movimento:5 / Descanso:5min )");
            Console.WriteLine("3 - Camelo ( Velocidade Movimento:3 / Descanso:2min )");
            Console.WriteLine("4 - Gavião ( Velocidade Movimento:10 / Descanso:9min )");
            Console.WriteLine("5 - Mamute ( Velocidade Movimento:1 / Descanso:1min )");
            try
            {
                optionMount = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            switch (optionMount)
            {
                case 1:
                    mount.Horse();
                    await _mountService.AddAsync(mount);
                    break;
                case 2:
                    mount.Panda();
                    await _mountService.AddAsync(mount);
                    break;
                case 3:
                    mount.Camel();
                    await _mountService.AddAsync(mount);
                    break;
                case 4:
                    mount.Hawk();
                    await _mountService.AddAsync(mount);
                    break;
                case 5:
                    mount.Mammoth();
                    await _mountService.AddAsync(mount);
                    break;
            }
            return mount.IdMount;
        }

        public async Task GetMountAsync(int idMount)
        {
            Mount mount = await _mountService.GetMountByIdMountAsync(idMount);

            MountViewModel mountViewModel = new MountViewModel(
                mount.MountName,
                mount.MovimentSpeed,
                mount.RestTime
                );

            Console.WriteLine("MONTARIA");
            Console.WriteLine("Nome: " + mountViewModel.MountName);
            Console.WriteLine("Velocidade de Movimento: " + mountViewModel.MovimentSpeed);
            Console.WriteLine("Tempo de descanso: " + mountViewModel.RestTime);
            Console.WriteLine();
        }
    }
}

using FasterGame.Application.Repositories.Interfaces;
using FasterGame.Application.ViewModels;
using FasterGame.Core.Entities;
using FasterGame.Core.Services;

namespace FasterGame.Application.Repositories.Implementations
{
    public class FisicCharacteristicsRepository : IFisicCharacteristicsRepository
    {
        private readonly IFisicCharacteristicsService _fisicCharacteristcsService;
        public FisicCharacteristicsRepository(IFisicCharacteristicsService fisicCharacteristcsService)
        {
            _fisicCharacteristcsService = fisicCharacteristcsService;
        }

        public string ChooseBiotype()
        {
            FisicCharacteristicsViewModel fisicCharacteristicsViewModel = new FisicCharacteristicsViewModel();
            int optionBiotype = 0;
            Console.WriteLine("Biotipo");
            Console.WriteLine("1 - Magro");
            Console.WriteLine("2 - Maromba");
            Console.WriteLine("3 - Gordo");
            try
            {
                optionBiotype = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            switch (optionBiotype)
            {
                case 1:
                    fisicCharacteristicsViewModel.Biotype = "Magro";
                    break;
                case 2:
                    fisicCharacteristicsViewModel.Biotype = "Maromba";
                    break;
                case 3:
                    fisicCharacteristicsViewModel.Biotype = "Gordo";
                    break;
            }
            return fisicCharacteristicsViewModel.Biotype.ToString();
        }

        public string ChooseEyeColor()
        {
            FisicCharacteristicsViewModel fisicCharacteristicsViewModel = new FisicCharacteristicsViewModel();
            int optionEyeColor = 0;
            Console.WriteLine("Cor do Olho");
            Console.WriteLine("1 - Rosa");
            Console.WriteLine("2 - Azul");
            Console.WriteLine("3 - Amarelo");
            Console.WriteLine("4 - Branco");
            Console.WriteLine("5 - Verde");
            try
            {
                optionEyeColor = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            switch (optionEyeColor)
            {
                case 1:
                    fisicCharacteristicsViewModel.EyeColor = "Rosa";
                    break;
                case 2:
                    fisicCharacteristicsViewModel.EyeColor = "Azul";
                    break;
                case 3:
                    fisicCharacteristicsViewModel.EyeColor = "Amarelo";
                    break;
                case 4:
                    fisicCharacteristicsViewModel.EyeColor = "Branco";
                    break;
                case 5:
                    fisicCharacteristicsViewModel.EyeColor = "Verde";
                    break;
            }
            return fisicCharacteristicsViewModel.EyeColor.ToString();
        }

        public string ChooseHairColor()
        {
            FisicCharacteristicsViewModel fisicCharacteristicsViewModel = new FisicCharacteristicsViewModel();
            int optionHairColor = 0;
            Console.WriteLine("Cor do Cabelo");
            Console.WriteLine("1 - Rosa");
            Console.WriteLine("2 - Azul");
            Console.WriteLine("3 - Amarelo");
            Console.WriteLine("4 - Branco");
            Console.WriteLine("5 - Verde");
            try
            {
                optionHairColor = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            switch (optionHairColor)
            {
                case 1:
                    fisicCharacteristicsViewModel.HairColor = "Rosa";
                    break;
                case 2:
                    fisicCharacteristicsViewModel.HairColor = "Azul";
                    break;
                case 3:
                    fisicCharacteristicsViewModel.HairColor = "Amarelo";
                    break;
                case 4:
                    fisicCharacteristicsViewModel.HairColor = "Branco";
                    break;
                case 5:
                    fisicCharacteristicsViewModel.HairColor = "Verde";
                    break;
            }
            return fisicCharacteristicsViewModel.HairColor.ToString();
        }

        public string ChooseSkinColor()
        {
            FisicCharacteristicsViewModel fisicCharacteristicsViewModel = new FisicCharacteristicsViewModel();
            int optionSkinColor = 0;
            Console.WriteLine("Cor da Pele");
            Console.WriteLine("1 - Rosa");
            Console.WriteLine("2 - Azul");
            Console.WriteLine("3 - Amarelo");
            Console.WriteLine("4 - Branco");
            Console.WriteLine("5 - Verde");
            try
            {
                optionSkinColor = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            switch (optionSkinColor)
            {
                case 1:
                    fisicCharacteristicsViewModel.SkinColor = "Rosa";
                    break;
                case 2:
                    fisicCharacteristicsViewModel.SkinColor = "Azul";
                    break;
                case 3:
                    fisicCharacteristicsViewModel.SkinColor = "Amarelo";
                    break;
                case 4:
                    fisicCharacteristicsViewModel.SkinColor = "Branco";
                    break;
                case 5:
                    fisicCharacteristicsViewModel.SkinColor = "Verde";
                    break;
            }
            return fisicCharacteristicsViewModel.SkinColor.ToString();
            
        }

        public async Task<int> CreateFisicCharacteristicsAsync()
        {
            FisicCharacteristics fisicCharacteristcs = new FisicCharacteristics(ChooseHairColor(),ChooseSkinColor(),ChooseEyeColor(),ChooseBiotype());
            await _fisicCharacteristcsService.AddAsync(fisicCharacteristcs);
            return fisicCharacteristcs.IdFisicCharacteristics;
        }

        public async Task GetFisicCharacteristicsAsync(int idFisicCharacteristics)
        {
            FisicCharacteristics fisicCharacteristics = await _fisicCharacteristcsService.GetFisicCharacteristicsByIdFisicCharacteristicsAsync(idFisicCharacteristics);

            FisicCharacteristicsViewModel fisicCharacteristicsViewModel = new FisicCharacteristicsViewModel(
                fisicCharacteristics.HairColor,
                fisicCharacteristics.SkinColor,
                fisicCharacteristics.EyeColor,
                fisicCharacteristics.Biotype
                );

            Console.WriteLine("CARACTERISTICAS FISICAS");
            Console.WriteLine("Cor do Cabelo: " + fisicCharacteristicsViewModel.HairColor);
            Console.WriteLine("Cor de Pele: " + fisicCharacteristicsViewModel.SkinColor);
            Console.WriteLine("Cor dos Olhos: " + fisicCharacteristicsViewModel.EyeColor);
            Console.WriteLine("Biotipo: " + fisicCharacteristicsViewModel.Biotype);
            Console.WriteLine();
        }
    }
}

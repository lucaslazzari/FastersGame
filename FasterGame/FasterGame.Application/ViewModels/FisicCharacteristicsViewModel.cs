namespace FasterGame.Application.ViewModels
{
    public class FisicCharacteristicsViewModel
    {
        public FisicCharacteristicsViewModel()
        {
            
        }
        public FisicCharacteristicsViewModel(string hairColor, string skinColor, string eyeColor, string biotype)
        {
            HairColor = hairColor;
            SkinColor = skinColor;
            EyeColor = eyeColor;
            Biotype = biotype;
        }

        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string Biotype { get; set; }
    }
}

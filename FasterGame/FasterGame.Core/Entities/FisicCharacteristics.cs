namespace FasterGame.Core.Entities
{
    public class FisicCharacteristics
    {
        public FisicCharacteristics()
        {
        }
        public FisicCharacteristics(string hairColor, string skinColor, string eyeColor, string biotype)
        {
            HairColor = hairColor;
            SkinColor = skinColor;
            EyeColor = eyeColor;
            Biotype = biotype;
        }

        public int IdFisicCharacteristics { get; private set; }
        public string HairColor { get; private set; }
        public string SkinColor { get; private set; }
        public string EyeColor { get; private set; }
        public string Biotype { get; private set; }
    }
}

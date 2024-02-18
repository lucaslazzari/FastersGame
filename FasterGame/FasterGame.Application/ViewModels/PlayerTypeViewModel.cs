namespace FasterGame.Application.ViewModels
{
    public class PlayerTypeViewModel
    {
        public PlayerTypeViewModel(string nameType, string weapon, int life, int mana, double atackSpeed)
        {
            NameType = nameType;
            Weapon = weapon;
            Life = life;
            Mana = mana;
            AtackSpeed = atackSpeed;
        }

        public string NameType { get; set; }
        public string Weapon { get; set; }
        public int Life { get; set; }
        public int Mana { get; set; }
        public double AtackSpeed { get; set; }
    }
}

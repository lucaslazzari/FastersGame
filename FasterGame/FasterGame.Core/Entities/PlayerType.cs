namespace FasterGame.Core.Entities
{
    public class PlayerType
    {
        public PlayerType()
        {
        }
        public PlayerType(string nameType, string weapon, int life, int mana, double atackSpeed)
        {
            NameType = nameType;
            Weapon = weapon;
            Life = life;
            Mana = mana;
            AtackSpeed = atackSpeed;
        }
        public int IdPlayerType { get; private set; }
        public string NameType { get; private set; }
        public string Weapon { get; private set; }
        public int Life { get; private set; }
        public int Mana { get; private set; }
        public double AtackSpeed { get; private set; }  
        
        public void PaladinSpear()
        {
            NameType = "Paladino";
            Weapon = "Lanca";
            Life = 85;
            Mana = 35;
            AtackSpeed = 1.25;
        }

        public void PaladinShield()
        {
            NameType = "Paladino";
            Weapon = "Escudo";
            Life = 95;
            Mana = 38;
            AtackSpeed = 1.10;
        }

        public void ShooterShotgun()
        {
            NameType = "Atirador";
            Weapon = "Espingarda";
            Life = 70;
            Mana = 50;
            AtackSpeed = 1.75;
        }

        public void AcherArchery()
        {
            NameType = "Arqueiro";
            Weapon = "Arco e Flecha";
            Life = 80;
            Mana = 35;
            AtackSpeed = 1.50;
        }

        public void BarbarianAx()
        {
            NameType = "Barbaro";
            Weapon = "Machado";
            Life = 115;
            Mana = 24;
            AtackSpeed = 1.00;
        }

        public void BarbarianSledgehammer()
        {
            NameType = "Barbaro";
            Weapon = "Marreta";
            Life = 120;
            Mana = 22;
            AtackSpeed = 0.95;
        }

        public void WarriorSword()
        {
            NameType = "Guerreiro";
            Weapon = "Espada";
            Life = 100;
            Mana = 27;
            AtackSpeed = 1.15;
        }

        public void WarriorShield()
        {
            NameType = "Guerreiro";
            Weapon = "Escudo";
            Life = 115;
            Mana = 27;
            AtackSpeed = 1.10;
        }
    }
}

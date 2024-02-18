namespace FasterGame.Core.Entities
{
    public class Player
    {
        public Player()
        {
            
        }
        public Player(int idPlayerType, int idMount, int idFisicCharacteristics)
        {
            IdPlayerType = idPlayerType;
            IdMount = idMount;
            IdFisicCharacteristics = idFisicCharacteristics;
            
        }

        public int IdPlayer { get; private set; }
        public int IdPlayerType { get; private set; }
        public int IdMount { get; private set; }
        public int IdFisicCharacteristics { get; private set; }
        
    }
}

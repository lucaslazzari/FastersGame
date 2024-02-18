namespace FasterGame.Application.ViewModels
{
    public class PlayerViewModel
    {
        public PlayerViewModel()
        {
            
        }
        public PlayerViewModel(int idPlayerType, int idFisicCharacteristics, int idMount)
        {
            IdPlayerType = idPlayerType;
            IdFisicCharacteristics = idFisicCharacteristics;
            IdMount = idMount;
        }

        public int IdPlayerType { get; set; }
        public int IdFisicCharacteristics { get; set; }
        public int IdMount { get; set; }
    }
}

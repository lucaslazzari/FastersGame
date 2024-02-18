namespace FasterGame.Application.ViewModels
{
    public class MountViewModel
    {
        public MountViewModel(string mountName, int movimentSpeed, int restTime)
        {
            MountName = mountName;
            MovimentSpeed = movimentSpeed;
            RestTime = restTime;
        }

        public string MountName { get; set; }
        public int MovimentSpeed { get; set; }
        public int RestTime { get; set; }
    }
}

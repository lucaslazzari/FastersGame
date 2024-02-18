namespace FasterGame.Core.Entities
{
    public class Mount
    {
        public Mount()
        {
        }
        public Mount(string mountName, int movimentSpeed, int restTime)
        {
            MountName = mountName;
            MovimentSpeed = movimentSpeed;
            RestTime = restTime;
        }

        public int IdMount { get; private set; }
        public string MountName { get; private set; }
        public int MovimentSpeed { get; private set; }
        public int RestTime { get; private set; }

        public void Horse()
        {
            MountName = "Cavalo";
            MovimentSpeed = 8;
            RestTime = 7;
        }

        public void Panda()
        {
            MountName = "Panda";
            MovimentSpeed = 5;
            RestTime = 5;
        }

        public void Camel()
        {
            MountName = "Camelo";
            MovimentSpeed = 3;
            RestTime = 2;
        }

        public void Hawk()
        {
            MountName = "Gavião";
            MovimentSpeed = 10;
            RestTime = 9;
        }

        public void Mammoth()
        {
            MountName = "Mamute";
            MovimentSpeed = 1;
            RestTime = 1;
        }
    }
}

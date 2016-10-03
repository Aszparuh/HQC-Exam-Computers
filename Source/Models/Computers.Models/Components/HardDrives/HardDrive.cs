namespace Computers.Models.Components.HardDrives
{
    public abstract class HardDrive
    {
        internal HardDrive()
        {
        }

        public abstract int Capacity { get; }

        public abstract void SaveData(int address, string data);

        public abstract string LoadData(int address);
    }
}

using System.Collections.Generic;
using Computers.Models.Components.Cpus;
using Computers.Models.Components.HardDrives;
using Computers.Models.Components.Rams;
using Computers.Models.Components.VideoCards;

namespace Computers.Models.ComputerTypes
{
    public class Server : BaseComputer
    {
        public Server(
            BaseCpu cpu,
            IRam ram,
            IEnumerable<HardDrive> hardDrives,
            BaseVideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Process(int data)
        {
            this.Ram.SaveValue(data);
            this.Cpu.SquareNumber();
        }
    }
}

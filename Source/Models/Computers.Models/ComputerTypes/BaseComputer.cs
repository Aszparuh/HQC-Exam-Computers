using System.Collections.Generic;
using Computers.Models.Components.Cpus;
using Computers.Models.Components.HardDrives;
using Computers.Models.Components.Motherboards;
using Computers.Models.Components.Rams;
using Computers.Models.Components.VideoCards;

namespace Computers.Models.ComputerTypes
{
    public abstract class BaseComputer
    {
        private Motherboard motherboard;

        internal BaseComputer(
            BaseCpu cpu,
            IRam ram,
            IEnumerable<HardDrive> hardDrives,
            BaseVideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
            this.motherboard = new Motherboard(this.Cpu, this.Ram, this.VideoCard);
        }

        protected IEnumerable<HardDrive> HardDrives { get; set; }

        protected BaseVideoCard VideoCard { get; set; }

        protected BaseCpu Cpu { get; set; }

        protected IRam Ram { get; set; }
    }
}

using System.Collections.Generic;
using Computers.Models.Components.Batteries;
using Computers.Models.Components.Cpus;
using Computers.Models.Components.HardDrives;
using Computers.Models.Components.Rams;
using Computers.Models.Components.VideoCards;

namespace Computers.Models.ComputerTypes
{
    public class Laptop : BaseComputer
    {
        private const string BatteryStatusStringFormat = "Battery status: {0}%";

        private readonly IBatttery battery;

        public Laptop(
            BaseCpu cpu,
            IRam ram,
            IEnumerable<HardDrive> hardDrives,
            BaseVideoCard videoCard,
            IBatttery battery)
            : base(cpu, ram, hardDrives, videoCard)
        {
            this.battery = battery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            this.VideoCard.Draw(string.Format(BatteryStatusStringFormat, this.battery.Percentage));
        }
    }
}

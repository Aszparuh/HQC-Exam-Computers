using System.Collections.Generic;
using Computers.Models.Components.Batteries;
using Computers.Models.Components.Cpus;
using Computers.Models.Components.HardDrives;
using Computers.Models.Components.Rams;
using Computers.Models.Components.VideoCards;
using Computers.Models.ComputerTypes;

namespace Computers.Models.Manufacturers
{
    public class DellComputerFactory : IComputerFactory
    {
        public const string Name = "Dell";

        public Laptop CreateLaptop()
        {
            var laptop = new Laptop(
                new Cpu32bit(4),
                new Ram(8),
                new[] { new SingleHardDrive(1000) },
                new ColourVideoCard(),
                new LaptopBattery());
            return laptop;
        }

        public PersonalComputer CreatePersonalComputer()
        {
            var pc = new PersonalComputer(
                new Cpu64bit(4),
                new Ram(8),
                new[] { new SingleHardDrive(1000) },
                new ColourVideoCard());
            return pc;
        }

        public Server CreateServer()
        {
            var server = new Server(
                 new Cpu64bit(8),
                 new Ram(64),
                 new List<HardDrive> { new RaidArray(new List<HardDrive> { new SingleHardDrive(2000), new SingleHardDrive(2000) }) },
                 new MonochromeVideoCard());
            return server;
        }
    }
}

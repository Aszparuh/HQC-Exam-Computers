using System.Collections.Generic;
using Computers.Models.Components.Batteries;
using Computers.Models.Components.Cpus;
using Computers.Models.Components.HardDrives;
using Computers.Models.Components.Rams;
using Computers.Models.Components.VideoCards;
using Computers.Models.ComputerTypes;

namespace Computers.Models.Manufacturers
{
    public class HpComputerFactory : IComputerFactory
    {
        public const string Name = "HP";

        public Laptop CreateLaptop()
        {
            var laptop = new Laptop(
                new Cpu64bit(2),
                new Ram(4),
                new[] { new SingleHardDrive(500) },
                new ColourVideoCard(),
                new LaptopBattery());
            return laptop;
        }

        public PersonalComputer CreatePersonalComputer()
        {
            var pc = new PersonalComputer(
                new Cpu32bit(2),
                new Ram(2),
                new[] { new SingleHardDrive(500) },
                new ColourVideoCard());
            return pc;
        }

        public Server CreateServer()
        {
            var server = new Server(
                 new Cpu32bit(4),
                 new Ram(32),
                 new List<HardDrive> { new RaidArray(new List<HardDrive> { new SingleHardDrive(1000), new SingleHardDrive(1000) }) },
                 new MonochromeVideoCard());
            return server;
        }
    }
}

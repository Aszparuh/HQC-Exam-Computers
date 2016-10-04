using System.Collections.Generic;
using Computers.Models.Components.Batteries;
using Computers.Models.Components.Cpus;
using Computers.Models.Components.HardDrives;
using Computers.Models.Components.Rams;
using Computers.Models.Components.VideoCards;
using Computers.Models.ComputerTypes;

namespace Computers.Models.Manufacturers
{
    public class LenovoComputerFactory : IComputerFactory
    {
        public const string Name = "Lenovo";

        public Laptop CreateLaptop()
        {
            var laptop = new Laptop(
                new Cpu64bit(2),
                new Ram(16),
                new[] { new SingleHardDrive(1000) },
                new ColourVideoCard(),
                new LaptopBattery());
            return laptop;
        }

        public PersonalComputer CreatePersonalComputer()
        {
            var pc = new PersonalComputer(
                new Cpu64bit(2),
                new Ram(4),
                new[] { new SingleHardDrive(2000) },
                new MonochromeVideoCard());
            return pc;
        }

        public Server CreateServer()
        {
            var server = new Server(
                new Cpu128bit(2),
                new Ram(8),
                new List<HardDrive> { new RaidArray(new List<HardDrive> { new SingleHardDrive(500), new SingleHardDrive(500) }) },
                new MonochromeVideoCard());
            return server;
        }
    }
}

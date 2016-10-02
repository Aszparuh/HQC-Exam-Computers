using System;
using System.Collections.Generic;

namespace Computers.Models
{
    internal class Program
    {
        public const int Eight = 8;
        private static Computer pc;
        private static Computer laptop;
        private static Computer server;

        public enum Type
        {
            PC, LAPTOP, SERVER
        }

        private interface IMotherboard
        {
            int LoadRamValue();

            void SaveRamValue(int value);

            void DrawOnVideoCard(string data);
        }

        public static void Start()
        {
            var manufacturer = Console.ReadLine();
            if (manufacturer == "HP")
            {
                var ram = new Rammstein(Eight / 4);
                var videoCard = new HardDriver() { IsMonochrome = false };
                pc = new Computer(Type.PC, new Cpu(Eight / 4, 32, ram, videoCard), ram, new[] { new HardDriver(500, false, 0) }, videoCard, null);

                var serverRam = new Rammstein(Eight * 4);
                var serverVideo = new HardDriver();
                server = new Computer(
                    Type.SERVER,
                    new Cpu(Eight / 2, 32, serverRam, serverVideo),
                    serverRam,
                    new List<HardDriver> { new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(1000, false, 0), new HardDriver(1000, false, 0) }) },
                    serverVideo,
                    null);
                {
                    var card = new HardDriver()
                    {
                        IsMonochrome = false
                    };
                    var ram1 = new Rammstein(Eight / 2);
                    laptop = new Computer(
                        Type.LAPTOP,
                        new Cpu(Eight / 4, 64, ram1, card),
                        ram1,
                        new[] { new HardDriver(500, false, 0) },
                        card,
                        new LaptopBattery());
                }
            }
            else if (manufacturer == "Dell")
            {
                var ram = new Rammstein(Eight);
                var videoCard = new HardDriver()
                {
                    IsMonochrome = false
                };

                pc = new Computer(Type.PC, new Cpu(Eight / 2, 64, ram, videoCard), ram, new[] { new HardDriver(1000, false, 0) }, videoCard, null);
                var ram1 = new Rammstein(Eight * Eight);
                var card = new HardDriver();
                server = new Computer(
                    Type.SERVER,
                    new Cpu(Eight, 64, ram1, card),
                    ram1,
                    new List<HardDriver> { new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(2000, false, 0), new HardDriver(2000, false, 0) }) },
                    card,
                    null);
                var ram2 = new Rammstein(Eight);
                var videoCard1 = new HardDriver() { IsMonochrome = false };
                laptop = new Computer(
                    Type.LAPTOP,
                    new Cpu(Eight / 2, 32, ram2, videoCard1),
                    ram2,
                    new[] { new HardDriver(1000, false, 0) },
                    videoCard1,
                    new LaptopBattery());
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            while (1 == 1)
            {
                var c = Console.ReadLine();
                if (c == null)
                {
                    goto end;
                }

                if (c.StartsWith("Exit"))
                {
                    goto end;
                }

                var cp = c.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (cp.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                var cn = cp[0];
                var ca = int.Parse(cp[1]);

                if (cn == "Charge")
                {
                    laptop.ChargeBattery(ca);
                }
                else if (cn == "Process")
                {
                    server.Process(ca);
                }
                else if (cn == "Play")
                {
                    pc.Play(ca);
                }

                Console.WriteLine("Invalid command!");
                continue;
            }

        end:
            ;
        }

        public class Computer
        {
            private readonly LaptopBattery battery;

            internal Computer(
                Type type,
                Cpu cpu,
                Rammstein ram,
                IEnumerable<HardDriver> hardDrives,
                HardDriver videoCard,
                LaptopBattery battery)
            {
                this.Cpu = cpu;
                this.Ram = ram;
                this.HardDrives = hardDrives;
                this.VideoCard = videoCard;
                if (type != Type.LAPTOP && type != Type.PC)
                {
                    this.VideoCard.IsMonochrome = true;
                }

                this.battery = battery;
            }

            private IEnumerable<HardDriver> HardDrives { get; set; }

            private HardDriver VideoCard { get; set; }

            private Cpu Cpu { get; set; }

            private Rammstein Ram { get; set; }

            public void Play(int guessNumber)
            {
                this.Cpu.Rand(1, 10);
                var number = this.Ram.LoadValue();
                if (number + 1 != guessNumber + 1)
                {
                    this.VideoCard.Draw(string.Format("You didn't guess the number {0}.", number));
                }
                else
                {
                    this.VideoCard.Draw("You win!");
                }
            }

            internal void ChargeBattery(int percentage)
            {
                this.battery.Charge(percentage);

                this.VideoCard.Draw(string.Format("Battery status: {0}", this.battery.Percentage));
            }

            internal void Process(int data)
            {
                this.Ram.SaveValue(data);
                this.Cpu.SquareNumber();
            }
        }

        public class InvalidArgumentException : ArgumentException
        {
            public InvalidArgumentException(string message)
                : base(message)
            {
            }
        }
    }
}

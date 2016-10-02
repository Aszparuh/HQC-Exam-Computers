﻿using System;
using System.Collections.Generic;
using Computers.Models.Types;

namespace Computers.Models
{
    internal class Program
    {
        public const int Eight = 8;
        private static Computer pc;
        private static Computer laptop;
        private static Computer server;

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
                var ram = new Ram(Eight / 4);
                var videoCard = new HardDriver() { IsMonochrome = false };
                pc = new Computer(ComputerType.Pc, new Cpu(Eight / 4, 32, ram, videoCard), ram, new[] { new HardDriver(500, false, 0) }, videoCard, null);

                var serverRam = new Ram(Eight * 4);
                var serverVideo = new HardDriver();
                server = new Computer(
                    ComputerType.Server,
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
                    var ram1 = new Ram(Eight / 2);
                    laptop = new Computer(
                        ComputerType.Laptop,
                        new Cpu(Eight / 4, 64, ram1, card),
                        ram1,
                        new[] { new HardDriver(500, false, 0) },
                        card,
                        new LaptopBattery());
                }
            }
            else if (manufacturer == "Dell")
            {
                var ram = new Ram(Eight);
                var videoCard = new HardDriver()
                {
                    IsMonochrome = false
                };

                pc = new Computer(ComputerType.Pc, new Cpu(Eight / 2, 64, ram, videoCard), ram, new[] { new HardDriver(1000, false, 0) }, videoCard, null);
                var ram1 = new Ram(Eight * Eight);
                var card = new HardDriver();
                server = new Computer(
                    ComputerType.Server,
                    new Cpu(Eight, 64, ram1, card),
                    ram1,
                    new List<HardDriver> { new HardDriver(0, true, 2, new List<HardDriver> { new HardDriver(2000, false, 0), new HardDriver(2000, false, 0) }) },
                    card,
                    null);
                var ram2 = new Ram(Eight);
                var videoCard1 = new HardDriver() { IsMonochrome = false };
                laptop = new Computer(
                    ComputerType.Laptop,
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

        public class InvalidArgumentException : ArgumentException
        {
            public InvalidArgumentException(string message)
                : base(message)
            {
            }
        }
    }
}
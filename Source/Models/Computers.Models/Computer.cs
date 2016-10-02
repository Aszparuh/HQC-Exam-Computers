﻿using System.Collections.Generic;
using Computers.Models.Types;

namespace Computers.Models
{
    public class Computer
    {
        private readonly LaptopBattery battery;

        internal Computer(
            ComputerType type,
            Cpu cpu,
            Ram ram,
            IEnumerable<HardDriver> hardDrives,
            HardDriver videoCard,
            LaptopBattery battery)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            this.VideoCard = videoCard;
            if (type != ComputerType.Laptop && type != ComputerType.Pc)
            {
                this.VideoCard.IsMonochrome = true;
            }

            this.battery = battery;
        }

        private IEnumerable<HardDriver> HardDrives { get; set; }

        private HardDriver VideoCard { get; set; }

        private Cpu Cpu { get; set; }

        private Ram Ram { get; set; }

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
}

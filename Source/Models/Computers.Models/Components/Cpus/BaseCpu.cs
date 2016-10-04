using System;
using Computers.Models.Components.Contracts;
using Computers.Models.Components.Motherboards;

namespace Computers.Models.Components.Cpus
{
    public abstract class BaseCpu : IMotherboardComponent
    {
        private readonly Random random = new Random();
        private readonly byte numberOfCores;
        private IMotherboard motherboard;

        internal BaseCpu(byte numberOfCores)
        {
            this.numberOfCores = numberOfCores;
        }

        public void AttachTo(IMotherboard motherboard)
        {
            this.motherboard = motherboard;
        }

        public void SquareNumber()
        {
            var value = this.motherboard.LoadRamValue();
            if (value < CpuConstants.MinimalNumberToBeCalculated)
            {
                this.motherboard.DrawOnVideoCard(CpuConstants.NumberTooLowMessage);
            }
            else if (value > this.GetMaxValue())
            {
                this.motherboard.DrawOnVideoCard(CpuConstants.NumberTooHighMessage);
            }
            else
            {
                var result = value * value;
                this.motherboard.DrawOnVideoCard(string.Format(CpuConstants.SquareFormatString, value, result));
            }
        }

        public void RandomNumber(int min, int max)
        {
            int randomNumber = this.random.Next(min, max + 1);
            this.motherboard.SaveRamValue(randomNumber);
        }

        protected abstract int GetMaxValue();
    }
}

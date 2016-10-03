using System;

namespace Computers.Models.Components.Cpus
{
    public abstract class BaseCpu
    {
        private readonly byte numberOfCores;

        internal BaseCpu(byte numberOfCores)
        {
            this.numberOfCores = numberOfCores;
        }

        public abstract int SquareNumber(int number);
    }
}

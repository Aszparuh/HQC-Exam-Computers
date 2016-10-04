using System;

namespace Computers.Models.Components.Cpus
{
    public class Cpu64bit : BaseCpu
    {
        public Cpu64bit(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        protected override int GetMaxValue()
        {
            return CpuConstants.MaximalNumberToBeCalculatedByCpu64;
        }
    }
}

using System;

namespace Computers.Models.Components.Cpus
{
    public class Cpu32bit : BaseCpu
    {
        public Cpu32bit(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        protected override int GetMaxValue()
        {
            return CpuConstants.MaximalNumberToBeCalculatedByCpu32;
        }
    }
}

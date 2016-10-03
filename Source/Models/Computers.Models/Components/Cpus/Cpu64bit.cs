using System;

namespace Computers.Models.Components.Cpus
{
    public class Cpu64bit : BaseCpu
    {
        public Cpu64bit(byte numberOfCores) 
            : base(numberOfCores)
        {
        }

        public override int SquareNumber(int number)
        {
            if (number < CpuConstants.MinimalNumberToBeCalculated)
            {
                throw new ArgumentException("The number must be larger than 0");
            }
            else if (number > CpuConstants.MaximalNumberToBeCalculatedByCpu64)
            {
                throw new ArgumentException("The number must not be greater than 1000");
            }
            else
            {
                var result = Math.Pow(number, 2);
                return (int)result;
            }
        }
    }
}

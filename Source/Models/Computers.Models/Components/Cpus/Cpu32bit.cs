using System;

namespace Computers.Models.Components.Cpus
{
    public class Cpu32bit : BaseCpu
    {
        public Cpu32bit(byte numberOfCores) 
            : base(numberOfCores)
        {
        }

        public override int SquareNumber(int number)
        {
            if (number < CpuConstants.MinimalNumberToBeCalculated)
            {
                throw new ArgumentException("The number must be larger than 0");
            }
            else if(number > CpuConstants.MaximalNumberToBeCalculatedByCpu32)
            {
                throw new ArgumentException("The number must not be greater than 500");
            }
            else
            {
                var result = Math.Pow(number, 2);
                return (int)result;
            }
        }
    }
}

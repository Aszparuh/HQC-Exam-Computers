namespace Computers.Models.Components.Cpus
{
    public class Cpu128bit : BaseCpu
    {
        public Cpu128bit(byte numberOfCores)
            : base(numberOfCores)
        {
        }

        protected override int GetMaxValue()
        {
            return CpuConstants.MaximalNumberToBeCalculatedByCpu128;
        }
    }
}

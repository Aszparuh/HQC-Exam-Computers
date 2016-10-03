namespace Computers.Models.Components
{
    internal abstract class BaseCpu
    {
        private readonly byte numberOfCores;

        internal BaseCpu(byte numberOfCores)
        {
            this.numberOfCores = numberOfCores;
        }

        internal abstract int SquareNumber();
    }
}

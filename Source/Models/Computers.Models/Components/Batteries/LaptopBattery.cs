namespace Computers.Models.Components.Batteries
{
    public class LaptopBattery : IBatttery
    {
        private const int InitialCharge = 50;
        private const int MinimalCharge = 0;
        private const int MaximalCharge = 100;

        public LaptopBattery()
        {
            this.Percentage = InitialCharge;
        }

        public int Percentage { get; private set; }

        public void Charge(int percentage)
        {
            this.Percentage += percentage;
            if (this.Percentage > MaximalCharge)
            {
                this.Percentage = 100;
            }

            if (this.Percentage < MinimalCharge)
            {
                this.Percentage = 0;
            }
        }
    }
}

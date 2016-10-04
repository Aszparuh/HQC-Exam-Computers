namespace Computers.Models.Components.Batteries
{
    public interface IBatttery
    {
        int Percentage { get; }

        void Charge(int percentage);
    }
}

namespace Computers.Models.Components.Rams
{
    public interface IRam
    {
        int Amount { get; }

        int LoadValue();

        void SaveValue(int newValue);
    }
}

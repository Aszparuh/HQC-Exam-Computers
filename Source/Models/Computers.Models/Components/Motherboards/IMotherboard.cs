namespace Computers.Models.Components.Motherboards
{
    public interface IMotherboard
    {
        int LoadRamValue();

        void SaveRamValue(int value);

        void DrawOnVideoCard(string data);
    }
}

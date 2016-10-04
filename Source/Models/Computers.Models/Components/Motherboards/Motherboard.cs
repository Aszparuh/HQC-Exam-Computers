using Computers.Models.Components.Cpus;
using Computers.Models.Components.Rams;
using Computers.Models.Components.VideoCards;

namespace Computers.Models.Components.Motherboards
{
    public class Motherboard : IMotherboard
    {
        public Motherboard(BaseCpu cpu, IRam ram, BaseVideoCard videoCard)
        {
            cpu.AttachTo(this);
            this.Ram = ram;
            this.VideoCard = videoCard;
        }

        private IRam Ram { get; set; }

        private BaseVideoCard VideoCard { get; set; }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }

        public int LoadRamValue()
        {
            return this.Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }
    }
}

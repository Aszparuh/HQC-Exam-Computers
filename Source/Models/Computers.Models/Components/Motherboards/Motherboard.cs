using System;
using Computers.Models.Components.Rams;
using Computers.Models.Components.VideoCards;

namespace Computers.Models.Components.Motherboards
{
    public class Motherboard : IMotherboard
    {
        public Motherboard(Cpu cpu, IRam ram, BaseVideoCard videoCard)
        {

        }

        private IRam Ram { get; set; }

        private BaseVideoCard VideoCard { get; set; }

        public void DrawOnVideoCard(string data)
        {
            throw new NotImplementedException();
        }

        public int LoadRamValue()
        {
            throw new NotImplementedException();
        }

        public void SaveRamValue(int value)
        {
            throw new NotImplementedException();
        }
    }
}

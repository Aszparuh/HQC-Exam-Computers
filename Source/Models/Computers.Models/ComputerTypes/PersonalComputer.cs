using System.Collections.Generic;
using Computers.Models.Components.Cpus;
using Computers.Models.Components.HardDrives;
using Computers.Models.Components.Rams;
using Computers.Models.Components.VideoCards;

namespace Computers.Models.ComputerTypes
{
    public class PersonalComputer : BaseComputer
    {
        private const string WrongNumberStringFormat = "You didn't guess the number {0}.";
        private const string WinMessage = "You win!";

        public PersonalComputer(
            BaseCpu cpu,
            IRam ram,
            IEnumerable<HardDrive> hardDrives,
            BaseVideoCard videoCard)
            : base(cpu, ram, hardDrives, videoCard)
        {
        }

        public void Play(int guessNumber)
        {
            this.Cpu.RandomNumber(1, 10);
            var number = this.Ram.LoadValue();
            if (number != guessNumber)
            {
                this.VideoCard.Draw(string.Format(WrongNumberStringFormat, number));
            }
            else
            {
                this.VideoCard.Draw(WinMessage);
            }
        }
    }
}

using System;

namespace Computers.Models.Components.VideoCards
{
    public class ColourVideoCard : BaseVideoCard
    {
        protected override ConsoleColor GetColour()
        {
            return ConsoleColor.Green;
        }
    }
}

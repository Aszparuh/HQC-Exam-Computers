using System;

namespace Computers.Models.Components.VideoCards
{
    public class MonochromeVideoCard : BaseVideoCard
    {
        protected override ConsoleColor GetColour()
        {
            return ConsoleColor.Gray;
        }
    }
}

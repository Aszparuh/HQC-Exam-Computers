using System;

namespace Computers.Models.Components.VideoCards
{
    public abstract class BaseVideoCard
    {
        public void Draw(string messege)
        {
            var color = this.GetColour();
            Console.ForegroundColor = color;
            Console.WriteLine(messege);
            Console.ResetColor();
        }

        protected abstract ConsoleColor GetColour();
    }
}

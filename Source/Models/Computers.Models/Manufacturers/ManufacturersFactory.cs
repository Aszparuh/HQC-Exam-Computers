using System;

namespace Computers.Models.Manufacturers
{
    public class ManufacturersFactory
    {
        private const string InvalidManufacturerMessage
            = "Invalid manufacturer!";

        public IComputerFactory GetManufacturer(string manufacturerName)
        {
            if (manufacturerName == HpComputerFactory.Name)
            {
                return new HpComputerFactory();
            }
            else if (manufacturerName == DellComputerFactory.Name)
            {
                return new DellComputerFactory();
            }
            else if (manufacturerName == LenovoComputerFactory.Name)
            {
                return new LenovoComputerFactory();
            }
            else
            {
                throw new ArgumentException(InvalidManufacturerMessage);
            }
        }
    }
}

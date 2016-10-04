using Computers.Models.ComputerTypes;

namespace Computers.Models.Manufacturers
{
    public interface IComputerFactory
    {
        PersonalComputer CreatePersonalComputer();

        Laptop CreateLaptop();

        Server CreateServer();
    }
}

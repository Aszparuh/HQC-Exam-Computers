using Computers.Models.Components.Motherboards;

namespace Computers.Models.Components.Contracts
{
    public interface IMotherboardComponent
    {
        void AttachTo(IMotherboard motherboard);
    }
}

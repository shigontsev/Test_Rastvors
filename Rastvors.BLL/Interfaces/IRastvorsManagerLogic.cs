using Rastvors.Common.Entities;

namespace Rastvors.BLL.Interfaces
{
    public interface IRastvorsManagerLogic
    {
        bool Save(IEnumerable<Rastvor> rastvors);

        IEnumerable<Rastvor> GetAllRastvors();

        IEnumerable<Component> GetAllComponents();

    }
}

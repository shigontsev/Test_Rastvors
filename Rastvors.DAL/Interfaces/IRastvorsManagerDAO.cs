using Rastvors.Common.Entities;

namespace Rastvors.DAL.Interfaces
{
    public interface IRastvorsManagerDAO
    {
        bool Save(IEnumerable<Rastvor> rastvors);

        IEnumerable<Rastvor> GetAllRastvors();

        IEnumerable<Component> GetAllComponents();
    }
}

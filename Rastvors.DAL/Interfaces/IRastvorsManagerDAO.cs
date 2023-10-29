using Rastvors.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rastvors.DAL.Interfaces
{
    public interface IRastvorsManagerDAO
    {
        bool Save(IEnumerable<Rastvor> rastvors);

        IEnumerable<Rastvor> GetAllRastvors();

        IEnumerable<Component> GetAllComponents();
    }
}

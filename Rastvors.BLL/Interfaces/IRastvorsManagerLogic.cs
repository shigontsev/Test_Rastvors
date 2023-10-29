using Rastvors.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rastvors.BLL.Interfaces
{
    public interface IRastvorsManagerLogic
    {
        bool Save(IEnumerable<Rastvor> rastvors);

        IEnumerable<Rastvor> GetAllRastvors();

        IEnumerable<Component> GetAllComponents();

    }
}

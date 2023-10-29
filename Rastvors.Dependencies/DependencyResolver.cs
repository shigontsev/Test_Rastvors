using Rastvors.BLL.Interfaces;
using Rastvors.BLL.Logics;
using Rastvors.DAL.DAO;
using Rastvors.DAL.Interfaces;

namespace Rastvors.Dependencies
{
    public class DependencyResolver
    {
        private static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new DependencyResolver();
                }
                return _instance;
            }
        }

        private IRastvorsManagerDAO RastvorsManagerDAO => new RastvorsManagerDAO();

        public IRastvorsManagerLogic RastvorsManagerLogic => new RastvorsManagerLogic(RastvorsManagerDAO);
    }
}
﻿using Rastvors.BLL.Interfaces;
using Rastvors.Common.Entities;
using Rastvors.DAL.Interfaces;

namespace Rastvors.BLL.Logics
{
    public class RastvorsManagerLogic : IRastvorsManagerLogic
    {
        IRastvorsManagerDAO _rastvorsManagerDAO;

        public RastvorsManagerLogic(IRastvorsManagerDAO rastvorsManagerDAO)
        {
            _rastvorsManagerDAO = rastvorsManagerDAO;
        }

        public IEnumerable<Component> GetAllComponents()
        {
            return _rastvorsManagerDAO.GetAllComponents();
        }

        public IEnumerable<Rastvor> GetAllRastvors()
        {
            return _rastvorsManagerDAO.GetAllRastvors();
        }

        public bool Save(IEnumerable<Rastvor> rastvors)
        {
            return _rastvorsManagerDAO.Save(rastvors);
        }
    }
}

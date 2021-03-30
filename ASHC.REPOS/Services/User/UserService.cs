using ASHC.DATA.Models;
using ASHC.REPOS.Interfaces.User;
using ASHC.REPOS.UnitOfWorkInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASHC.REPOS.Services.User
{
    public class UserService : IMUsers
    {
        private readonly UnitOfWork _unitOfWork;
        public UserService(IUnitOfWork _uow)
        {
            this._unitOfWork = _uow as UnitOfWork;
        }
        public IEnumerable<MUser> GetAll()
        {
            return _unitOfWork.Repository<MUser>().GetAll();
        }

        public IEnumerable<MUser> GetAllBySP()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MUser> GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<bool> PostUser(MUser obj)
        {
           var obj2 =  _unitOfWork.Repository<MUser>().Add(obj);
            IEnumerable<bool> result = new List<bool> { true };
            return result;
           // throw new NotImplementedException();
        }

         
    }
}

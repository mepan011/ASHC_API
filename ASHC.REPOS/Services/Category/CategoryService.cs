using ASHC.DATA.Models;
using ASHC.REPOS.Interfaces.Category;
using ASHC.REPOS.UnitOfWorkInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASHC.REPOS.Services.Category
{
    public class CategoryService:ICategory
    {
        private readonly UnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork _uow)
        {
            this._unitOfWork = _uow as UnitOfWork;
        }
        public IEnumerable<MCategory> GetAll()
        {
            return _unitOfWork.Repository<MCategory>().GetAll();
        }

        public IEnumerable<MCategory> GetAllBySP()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MCategory> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<bool> PostCategory(MCategory obj)
        {
            var obj2 = _unitOfWork.Repository<MCategory>().Add(obj);
            IEnumerable<bool> result = new List<bool> { true };
            return result;
            // throw new NotImplementedException();
        }

    }
}

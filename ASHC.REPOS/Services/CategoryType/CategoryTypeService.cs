using ASHC.DATA.Models;
using ASHC.REPOS.Interfaces.CategoryType;
using ASHC.REPOS.UnitOfWorkInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASHC.REPOS.Services.CategoryType
{
    public class CategoryTypeService:ICategoryType
    {
        private readonly UnitOfWork _unitOfWork;
        public CategoryTypeService(IUnitOfWork _uow)
        {
            this._unitOfWork = _uow as UnitOfWork;
        }
        public IEnumerable<MCategoryType> GetAll()
        {
            return _unitOfWork.Repository<MCategoryType>().GetAll();
        }

        public IEnumerable<MCategoryType> GetAllBySP()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MCategoryType> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<bool> PostCategoryType(MCategoryType obj)
        {
            var obj2 = _unitOfWork.Repository<MCategoryType>().Add(obj);
            IEnumerable<bool> result = new List<bool> { true };
            return result;
            // throw new NotImplementedException();
        }

    }
}

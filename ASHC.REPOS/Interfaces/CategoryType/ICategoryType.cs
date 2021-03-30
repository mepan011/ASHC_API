using ASHC.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASHC.REPOS.Interfaces.CategoryType
{
    public interface ICategoryType
    {
        IEnumerable<MCategoryType> GetByID(int id);
        IEnumerable<MCategoryType> GetAll();
        IEnumerable<MCategoryType> GetAllBySP();
        IEnumerable<bool> PostCategoryType(MCategoryType mCategoryType);
    }

}

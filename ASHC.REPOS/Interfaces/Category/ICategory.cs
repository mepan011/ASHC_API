using ASHC.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASHC.REPOS.Interfaces.Category
{
    public interface ICategory
    {
        IEnumerable<MCategory> GetByID(int id);
        IEnumerable<MCategory> GetAll();
        IEnumerable<MCategory> GetAllBySP();
        IEnumerable<bool> PostCategory(MCategory mCategory);
    }
}

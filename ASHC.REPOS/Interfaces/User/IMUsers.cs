using ASHC.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASHC.REPOS.Interfaces.User
{
    public interface IMUsers
    {
        IEnumerable<MUser> GetUserByID(int id);
        IEnumerable<MUser> GetAll();
        IEnumerable<MUser> GetAllBySP();
        IEnumerable<bool> PostUser(MUser mUser);
    }
}

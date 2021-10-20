using System.Collections.Generic;
using GC.Models;

namespace GC.Data
{
    public interface IUserRepo 
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
    }
}
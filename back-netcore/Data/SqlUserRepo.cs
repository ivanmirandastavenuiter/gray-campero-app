using System.Collections.Generic;
using System.Linq;
using GC.Models;

namespace GC.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly GCContext _context;

        public SqlUserRepo(GCContext context) 
        {
            _context = context;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.UserId == id);
        }
    }
}
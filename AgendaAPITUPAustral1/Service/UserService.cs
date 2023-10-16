using AgendaAPITUPAustral1.Data;
using AgendaAPITUPAustral1.Data.Entities;

namespace AgendaAPITUPAustral1.Service
{
    public class UserService
    {
        private readonly AgendaContext _context;

        public UserService(AgendaContext context){ _context = context; }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public User? GetUser(int id)
        {
            return _context.Users.SingleOrDefault(c => c.Id == id);
        }
        public bool DeleteUser(int id)
        {
            User? UserToDelete = GetUser(id);
            if (UserToDelete != null)
            {
                _context.Users.Remove(UserToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;

        }
        public User UpdateUser(User UserToUpdate)
        {
            User? updateUser = _context.Update(UserToUpdate).Entity;
            _context.SaveChanges();
            return updateUser;
        }
        public int AddUser(User User)
        {
            int UserId = _context.Users.Add(User).Entity.Id;
            _context.SaveChanges();
            return UserId;
        }
    }
}
}

using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using ProjectManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Data.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly PMContext _context;

        public UserRepository(PMContext context) : base(context)
        {
            _context = context;
        }

        public User Login(User user)
        {
            return _context.Users.Where(a => a.Email.Equals(user.Email) && a.Password.Equals(user.Password)).FirstOrDefault();
        }
    }
}

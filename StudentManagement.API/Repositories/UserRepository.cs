using Microsoft.EntityFrameworkCore;
using StudentManagement.API.Models;
using StudentManagement.API.Data;
namespace StudentManagement.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users
                .FirstOrDefault(x => x.Email == email);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();
        }
    }
}
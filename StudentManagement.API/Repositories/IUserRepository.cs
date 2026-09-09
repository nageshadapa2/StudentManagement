using StudentManagement.API.Models;


namespace StudentManagement.API.Repositories
{
    public interface IUserRepository
    {
        User GetByEmail(string email);

        void Add(User user);
    }
}

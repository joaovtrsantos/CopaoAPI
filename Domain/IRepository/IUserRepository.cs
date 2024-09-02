using Domain.Entities;

namespace Domain.IRepository
{
    public interface IUserRepository
    {
        Task<User?> Authenticate(string Username, string Password);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task<User?> AddAndUpdateUser(User userObj);
    }
}

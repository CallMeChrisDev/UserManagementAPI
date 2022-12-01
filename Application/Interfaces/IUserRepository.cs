using Domain;

namespace Application.Interfaces;

public interface IUserRepository
{
    public Task AddUser(User user);
    public Task<User?> GetUser(string userName);
}
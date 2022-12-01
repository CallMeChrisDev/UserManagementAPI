using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Users;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddUser(User user)
    {
        await _context.Set<User>().AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUser(string userName)
    {
        return await _context.Set<User>()
            .FirstOrDefaultAsync(license => license.UserName == userName);
    }
}
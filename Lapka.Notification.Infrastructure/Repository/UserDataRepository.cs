using Lapka.Notification.Application.Interfaces;
using Lapka.Notification.Core.Domain.Entities;
using Lapka.Notification.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Notification.Infrastructure.Repository;

internal class UserDataRepository : IUserDataRepository
{
    private readonly DataContext _context;

    public UserDataRepository(DataContext context)
    {
        _context = context;
    }

    public async Task CreateUserData(UserData userData)
    {
        await _context.AddAsync(userData);
        await _context.SaveChangesAsync();
    }

    public async Task<UserData> GetUserDataById(Guid id)
    {
        return await _context.UserData.FindAsync(id);
    }

    public async Task<UserData> GetUserDataByEmail(string email)
    {
        return await _context.UserData.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task UpdateUserData(UserData userData)
    {
        _context.UserData.Update(userData);
        await _context.SaveChangesAsync();
    }

    public Task DeleteUserData(UserData userData)
    {
        throw new NotImplementedException();
    }
}
using Lappka.Notification.Core.Entities;
using Lappka.Notification.Core.Repositories;
using Lappka.Notification.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lappka.Notification.Infrastructure.Database.Postgres;

internal sealed class PostgresUserDataRepository : IUserDataRepository
{
    private readonly INotificationDbContext _context;

    public PostgresUserDataRepository(INotificationDbContext context)
    {
        _context = context;
    }

    public Task<UserData> FindByEmailAsync(string email)
        => _context.UsersData.FirstOrDefaultAsync(x => x.Email == email);

    public Task<UserData> FindByIdAsync(Guid userId)
        => _context.UsersData.FirstOrDefaultAsync(x => x.UserId == userId);


    public async Task AddAsync(UserData userData)
    {
        await _context.UsersData.AddAsync(userData);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserData userData)
    {
        _context.UsersData.Update(userData);
        await _context.SaveChangesAsync();
    }
}
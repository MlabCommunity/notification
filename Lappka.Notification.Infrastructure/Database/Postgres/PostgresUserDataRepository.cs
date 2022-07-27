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

    public Task<UserData> GetByEmailAsync(string email)
    {
        return _context.UsersData.FirstOrDefaultAsync(x => x.Email == email);
    }
}
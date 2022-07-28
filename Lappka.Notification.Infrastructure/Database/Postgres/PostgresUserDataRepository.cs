using Microsoft.EntityFrameworkCore;
using Scheme.Core.Entities;
using Scheme.Core.Repositories;
using Scheme.Infrastructure.Database.Contexts;

namespace Scheme.Infrastructure.Database.Postgres;

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
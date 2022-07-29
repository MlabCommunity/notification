using Scheme.Core.Entities;

namespace Scheme.Core.Repositories;

public interface IUserDataRepository
{
    Task<UserData> FindByEmailAsync(string email);
    Task<UserData> FindByIdAsync(Guid userId);
    Task AddAsync(UserData userData);
    Task UpdateAsync(UserData userData);
}
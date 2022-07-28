using Scheme.Core.Entities;

namespace Scheme.Core.Repositories;

public interface IUserDataRepository
{
    Task<UserData> GetByEmailAsync(string email);

}
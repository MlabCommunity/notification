using Lappka.Notification.Core.Entities;

namespace Lappka.Notification.Core.Repositories;

public interface IUserDataRepository
{
    Task<UserData> GetByEmailAsync(string email);

}
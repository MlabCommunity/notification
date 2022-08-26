using Lapka.Notification.Core.Domain.Entities;

namespace Lapka.Notification.Application.Interfaces;

public interface IUserDataRepository
{
    Task CreateUserData(UserData userData);
    Task<UserData> GetUserDataById(Guid id);
    Task<UserData> GetUserDataByEmail(string email);
    Task UpdateUserData(UserData userData);
    Task DeleteUserData(UserData userData);
}
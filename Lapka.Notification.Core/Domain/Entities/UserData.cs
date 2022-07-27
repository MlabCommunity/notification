using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Notification.Core.Domain.Entities;

public class UserData
{
    public Guid Id { get; init; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<NotificationHistory> Notifications { get; set; }
}

public class UserDataConfiguration : IEntityTypeConfiguration<UserData>
{
    public void Configure(EntityTypeBuilder<UserData> user)
    {
        user.HasKey(x => x.Id);

        user.Property(x => x.Username)
            .IsRequired();

        user.Property(x => x.Email)
            .IsRequired();

        user.Property(x => x.FirstName)
            .IsRequired();

        user.Property(x => x.LastName)
            .IsRequired();

        user.HasMany(x => x.Notifications)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.User.Id)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
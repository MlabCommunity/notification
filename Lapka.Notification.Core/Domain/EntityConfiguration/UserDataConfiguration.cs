using Lapka.Notification.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Notification.Core.Domain.EntityConfiguration;

public class UserDataConfiguration : IEntityTypeConfiguration<UserData>
{
    public void Configure(EntityTypeBuilder<UserData> user)
    {
        user.HasKey(x => x.Id);

        user.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(64);

        user.Property(x => x.Email)
            .IsRequired();

        user.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(32);

        user.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(32);
    }
}
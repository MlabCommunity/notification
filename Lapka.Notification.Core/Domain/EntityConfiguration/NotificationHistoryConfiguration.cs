using Lapka.Notification.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Notification.Core.Domain.EntityConfiguration;

public class NotificationHistoryConfiguration : IEntityTypeConfiguration<NotificationHistory>
{
    public void Configure(EntityTypeBuilder<NotificationHistory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Type)
            .IsRequired()
            .HasMaxLength(32)
            .HasConversion<string>();

        builder.Property(x => x.UserEmail)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(x => x.Subject)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.IsSend)
            .IsRequired();
    }
}
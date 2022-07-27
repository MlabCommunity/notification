using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lapka.Notification.Core.Domain.Entities;

public class NotificationHistory : ICreatedAt
{
    public Guid Id { get; init; }
    public NotificationType Type { get; init; }
    public string UserEmail { get; init; }
    public string Subject { get; init; }
    public string Body { get; init; }
    public DateTime CreatedAt { get; set; }
    public bool IsSend { get; private set; }
    public Guid UserId { get; init; }
    public UserData User { get; set; }

    public void SetIsSend(bool isSend)
    {
        IsSend = isSend;
    }
}

public class NotificationHistoryConfiguration : IEntityTypeConfiguration<NotificationHistory>
{
    public void Configure(EntityTypeBuilder<NotificationHistory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.UserEmail)
            .IsRequired();

        builder.Property(x => x.Subject)
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.IsSend)
            .IsRequired();
    }
}
using Lappka.Notification.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lappka.Notification.Infrastructure.Database.Config;

internal sealed class EntitiesConfig : IEntityTypeConfiguration<NotificationHistory> ,IEntityTypeConfiguration<UserData>
{
    public void Configure(EntityTypeBuilder<NotificationHistory> builder)
    {
        builder.ToTable("NotificationsHistory");
        builder.HasKey(n => n.Id);
        
        builder.HasOne(u => u.User)
            .WithMany(n => n.Notifications).OnDelete(DeleteBehavior.SetNull);
        
    }
    
    public void Configure(EntityTypeBuilder<UserData> builder)
    {
        builder.ToTable("UsersData");
        builder.HasKey(u=>u.UserId);
    }
}
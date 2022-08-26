using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lapka.Notification.Infrastructure.DataBase.Migrations;

public partial class init : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "notification");

        migrationBuilder.CreateTable(
            name: "NotificationHistory",
            schema: "notification",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Type = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                UserEmail = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                Subject = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                Body = table.Column<string>(type: "text", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                IsSend = table.Column<bool>(type: "boolean", nullable: false),
                UserId = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_NotificationHistory", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "UserData",
            schema: "notification",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Username = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                Email = table.Column<string>(type: "text", nullable: false),
                FirstName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                LastName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserData", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "NotificationHistory",
            schema: "notification");

        migrationBuilder.DropTable(
            name: "UserData",
            schema: "notification");
    }
}
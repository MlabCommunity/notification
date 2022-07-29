using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lappka.Infrastructure.Database.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "NotificationsHistory",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "NotificationsHistory",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EventType",
                table: "NotificationsHistory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "NotificationsHistory",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isSent",
                table: "NotificationsHistory",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "NotificationsHistory");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "NotificationsHistory");

            migrationBuilder.DropColumn(
                name: "EventType",
                table: "NotificationsHistory");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "NotificationsHistory");

            migrationBuilder.DropColumn(
                name: "isSent",
                table: "NotificationsHistory");
        }
    }
}

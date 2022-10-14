using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thread.Modules.UserAccess.Infrastructure.Persistence.Migrations
{
    public partial class AddConfirmationTokenToRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmationToken",
                table: "Registrations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmationToken",
                table: "Registrations");
        }
    }
}

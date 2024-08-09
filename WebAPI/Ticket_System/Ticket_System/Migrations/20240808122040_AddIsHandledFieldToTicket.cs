using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_System.Migrations
{
    public partial class AddIsHandledFieldToTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHandled",
                table: "Ticket",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHandled",
                table: "Ticket");
        }
    }
}

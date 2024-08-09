using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticket_System.Migrations
{
    public partial class AddRestOfAttributesToTicketTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Governorate",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Governorate",
                table: "Ticket");
        }
    }
}

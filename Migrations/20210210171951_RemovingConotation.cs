using Microsoft.EntityFrameworkCore.Migrations;

namespace FinBet_Web_API.Migrations
{
    public partial class RemovingConotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conotation",
                table: "Lexicons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Conotation",
                table: "Lexicons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

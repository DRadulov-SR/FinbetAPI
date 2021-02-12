using Microsoft.EntityFrameworkCore.Migrations;

namespace FinBet_Web_API.Migrations
{
    public partial class SeedInitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Lexicons",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.InsertData(
                table: "Lexicons",
                columns: new[] { "Id", "Conotation", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, 0, "nice", 0.4m },
                    { 2, 0, "excellent", 0.8m },
                    { 3, 0, "modest", 0m },
                    { 4, 0, "horrible", -0.8m },
                    { 5, 0, "ugly", -0.5m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lexicons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lexicons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lexicons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lexicons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lexicons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rating",
                table: "Lexicons",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}

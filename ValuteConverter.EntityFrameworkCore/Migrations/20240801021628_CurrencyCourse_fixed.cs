using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuteConverter.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class CurrencyCourse_fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SellingPrice",
                schema: "CurrencyDB",
                table: "CurrencyCourses",
                type: "MONEY",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BuyingPrice",
                schema: "CurrencyDB",
                table: "CurrencyCourses",
                type: "MONEY",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SellingPrice",
                schema: "CurrencyDB",
                table: "CurrencyCourses",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "MONEY");

            migrationBuilder.AlterColumn<decimal>(
                name: "BuyingPrice",
                schema: "CurrencyDB",
                table: "CurrencyCourses",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "MONEY");
        }
    }
}

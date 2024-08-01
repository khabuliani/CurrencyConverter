using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValuteConverter.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CurrencyDB");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "CurrencyDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    RecomendatorPersonalNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                schema: "CurrencyDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    NameLatin = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyCourses",
                schema: "CurrencyDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyCourses_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "CurrencyDB",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "CurrencyDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToSellCurrencyId = table.Column<int>(type: "int", nullable: false),
                    ToSell = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToBuyCurrencyId = table.Column<int>(type: "int", nullable: false),
                    ToBuy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatorClientId = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Clients_CreatorClientId",
                        column: x => x.CreatorClientId,
                        principalSchema: "CurrencyDB",
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Currencies_ToBuyCurrencyId",
                        column: x => x.ToBuyCurrencyId,
                        principalSchema: "CurrencyDB",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Currencies_ToSellCurrencyId",
                        column: x => x.ToSellCurrencyId,
                        principalSchema: "CurrencyDB",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyCourses_CurrencyId",
                schema: "CurrencyDB",
                table: "CurrencyCourses",
                column: "CurrencyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CreatorClientId",
                schema: "CurrencyDB",
                table: "Transactions",
                column: "CreatorClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToBuyCurrencyId",
                schema: "CurrencyDB",
                table: "Transactions",
                column: "ToBuyCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToSellCurrencyId",
                schema: "CurrencyDB",
                table: "Transactions",
                column: "ToSellCurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyCourses",
                schema: "CurrencyDB");

            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "CurrencyDB");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "CurrencyDB");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "CurrencyDB");
        }
    }
}

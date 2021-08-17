using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ganesh.Expenses.Web.Server.Migrations
{
    public partial class AddIncome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeTypeId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Income_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Income_IncomeType_IncomeTypeId",
                        column: x => x.IncomeTypeId,
                        principalTable: "IncomeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Income_BankId",
                table: "Income",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Income_IncomeTypeId",
                table: "Income",
                column: "IncomeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Income");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ganesh.Expenses.Web.Server.Migrations
{
    public partial class CreditDebit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeTypeId = table.Column<int>(type: "int", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    PersonAndRelationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credit_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Credit_IncomeType_IncomeTypeId",
                        column: x => x.IncomeTypeId,
                        principalTable: "IncomeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Credit_PersonAndRelation_PersonAndRelationId",
                        column: x => x.PersonAndRelationId,
                        principalTable: "PersonAndRelation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Debit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeTypeId = table.Column<int>(type: "int", nullable: true),
                    BankId = table.Column<int>(type: "int", nullable: true),
                    PersonAndRelationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debit_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Debit_IncomeType_IncomeTypeId",
                        column: x => x.IncomeTypeId,
                        principalTable: "IncomeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Debit_PersonAndRelation_PersonAndRelationId",
                        column: x => x.PersonAndRelationId,
                        principalTable: "PersonAndRelation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credit_BankId",
                table: "Credit",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_IncomeTypeId",
                table: "Credit",
                column: "IncomeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_PersonAndRelationId",
                table: "Credit",
                column: "PersonAndRelationId");

            migrationBuilder.CreateIndex(
                name: "IX_Debit_BankId",
                table: "Debit",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Debit_IncomeTypeId",
                table: "Debit",
                column: "IncomeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Debit_PersonAndRelationId",
                table: "Debit",
                column: "PersonAndRelationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "Debit");
        }
    }
}

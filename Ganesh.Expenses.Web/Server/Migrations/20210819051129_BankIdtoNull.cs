using Microsoft.EntityFrameworkCore.Migrations;

namespace Ganesh.Expenses.Web.Server.Migrations
{
    public partial class BankIdtoNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Income_Bank_BankId",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_IncomeType_IncomeTypeId",
                table: "Income");

            migrationBuilder.AlterColumn<int>(
                name: "IncomeTypeId",
                table: "Income",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BankId",
                table: "Income",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Bank_BankId",
                table: "Income",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_IncomeType_IncomeTypeId",
                table: "Income",
                column: "IncomeTypeId",
                principalTable: "IncomeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Income_Bank_BankId",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_IncomeType_IncomeTypeId",
                table: "Income");

            migrationBuilder.AlterColumn<int>(
                name: "IncomeTypeId",
                table: "Income",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BankId",
                table: "Income",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Bank_BankId",
                table: "Income",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_IncomeType_IncomeTypeId",
                table: "Income",
                column: "IncomeTypeId",
                principalTable: "IncomeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

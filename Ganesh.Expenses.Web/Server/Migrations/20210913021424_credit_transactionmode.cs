using Microsoft.EntityFrameworkCore.Migrations;

namespace Ganesh.Expenses.Web.Server.Migrations
{
    public partial class credit_transactionmode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransactionModeId",
                table: "Debit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionModeId",
                table: "Credit",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Debit_TransactionModeId",
                table: "Debit",
                column: "TransactionModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_TransactionModeId",
                table: "Credit",
                column: "TransactionModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Credit_TransactionMode_TransactionModeId",
                table: "Credit",
                column: "TransactionModeId",
                principalTable: "TransactionMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Debit_TransactionMode_TransactionModeId",
                table: "Debit",
                column: "TransactionModeId",
                principalTable: "TransactionMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credit_TransactionMode_TransactionModeId",
                table: "Credit");

            migrationBuilder.DropForeignKey(
                name: "FK_Debit_TransactionMode_TransactionModeId",
                table: "Debit");

            migrationBuilder.DropIndex(
                name: "IX_Debit_TransactionModeId",
                table: "Debit");

            migrationBuilder.DropIndex(
                name: "IX_Credit_TransactionModeId",
                table: "Credit");

            migrationBuilder.DropColumn(
                name: "TransactionModeId",
                table: "Debit");

            migrationBuilder.DropColumn(
                name: "TransactionModeId",
                table: "Credit");
        }
    }
}

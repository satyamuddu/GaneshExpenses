using Microsoft.EntityFrameworkCore.Migrations;

namespace Ganesh.Expenses.Web.Server.Migrations
{
    public partial class AddPhoneforRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "PersonAndRelation",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "PersonAndRelation");
        }
    }
}

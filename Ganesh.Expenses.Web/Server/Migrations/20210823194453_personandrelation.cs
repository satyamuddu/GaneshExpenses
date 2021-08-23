using Microsoft.EntityFrameworkCore.Migrations;

namespace Ganesh.Expenses.Web.Server.Migrations
{
    public partial class personandrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonAndRelation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyGroupId = table.Column<int>(type: "int", nullable: false),
                    RelationTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAndRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAndRelation_FamilyGroup_FamilyGroupId",
                        column: x => x.FamilyGroupId,
                        principalTable: "FamilyGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonAndRelation_RelationType_RelationTypeId",
                        column: x => x.RelationTypeId,
                        principalTable: "RelationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonAndRelation_FamilyGroupId",
                table: "PersonAndRelation",
                column: "FamilyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAndRelation_RelationTypeId",
                table: "PersonAndRelation",
                column: "RelationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonAndRelation");
        }
    }
}

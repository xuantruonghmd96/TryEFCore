using Microsoft.EntityFrameworkCore.Migrations;

namespace Try_LazyLoad_EagerLoad.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchGroupMaps",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false),
                    BranchGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchGroupMaps", x => new { x.BranchId, x.BranchGroupId });
                    table.ForeignKey(
                        name: "FK_BranchGroupMaps_BranchGroups_BranchGroupId",
                        column: x => x.BranchGroupId,
                        principalTable: "BranchGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchGroupMaps_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchGroupMaps_BranchGroupId",
                table: "BranchGroupMaps",
                column: "BranchGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchGroupMaps");

            migrationBuilder.DropTable(
                name: "BranchGroups");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gs.TestingBugManagement.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bug",
                columns: table => new
                {
                    BugID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BugState = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bug", x => x.BugID);
                });

            migrationBuilder.CreateTable(
                name: "Enterprise",
                columns: table => new
                {
                    EnterpriseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnterpriseType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprise", x => x.EnterpriseID);
                });

            migrationBuilder.CreateTable(
                name: "Environment",
                columns: table => new
                {
                    EnvironmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnvironmentType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environment", x => x.EnvironmentID);
                });

            migrationBuilder.CreateTable(
                name: "BugManagement",
                columns: table => new
                {
                    BugNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssignedTo = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    EnterpriseID = table.Column<int>(nullable: false),
                    EnvironmentID = table.Column<int>(nullable: false),
                    BugID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugManagement", x => x.BugNumber);
                    table.ForeignKey(
                        name: "FK_BugManagement_Bug_BugID",
                        column: x => x.BugID,
                        principalTable: "Bug",
                        principalColumn: "BugID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BugManagement_Enterprise_EnterpriseID",
                        column: x => x.EnterpriseID,
                        principalTable: "Enterprise",
                        principalColumn: "EnterpriseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BugManagement_Environment_EnvironmentID",
                        column: x => x.EnvironmentID,
                        principalTable: "Environment",
                        principalColumn: "EnvironmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BugManagement_BugID",
                table: "BugManagement",
                column: "BugID");

            migrationBuilder.CreateIndex(
                name: "IX_BugManagement_EnterpriseID",
                table: "BugManagement",
                column: "EnterpriseID");

            migrationBuilder.CreateIndex(
                name: "IX_BugManagement_EnvironmentID",
                table: "BugManagement",
                column: "EnvironmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BugManagement");

            migrationBuilder.DropTable(
                name: "Bug");

            migrationBuilder.DropTable(
                name: "Enterprise");

            migrationBuilder.DropTable(
                name: "Environment");
        }
    }
}

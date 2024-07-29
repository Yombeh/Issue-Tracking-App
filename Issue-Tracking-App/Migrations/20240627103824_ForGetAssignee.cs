using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_Tracking_App.Migrations
{
    /// <inheritdoc />
    public partial class ForGetAssignee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GetAssignedId",
                table: "Statuses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GetAssignedId",
                table: "Severities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GetAssignedId",
                table: "Assignees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GetAssigneds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssigneeID = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    SeverityID = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetAssigneds", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_GetAssignedId",
                table: "Statuses",
                column: "GetAssignedId");

            migrationBuilder.CreateIndex(
                name: "IX_Severities_GetAssignedId",
                table: "Severities",
                column: "GetAssignedId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_GetAssignedId",
                table: "Assignees",
                column: "GetAssignedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignees_GetAssigneds_GetAssignedId",
                table: "Assignees",
                column: "GetAssignedId",
                principalTable: "GetAssigneds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Severities_GetAssigneds_GetAssignedId",
                table: "Severities",
                column: "GetAssignedId",
                principalTable: "GetAssigneds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_GetAssigneds_GetAssignedId",
                table: "Statuses",
                column: "GetAssignedId",
                principalTable: "GetAssigneds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignees_GetAssigneds_GetAssignedId",
                table: "Assignees");

            migrationBuilder.DropForeignKey(
                name: "FK_Severities_GetAssigneds_GetAssignedId",
                table: "Severities");

            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_GetAssigneds_GetAssignedId",
                table: "Statuses");

            migrationBuilder.DropTable(
                name: "GetAssigneds");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_GetAssignedId",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Severities_GetAssignedId",
                table: "Severities");

            migrationBuilder.DropIndex(
                name: "IX_Assignees_GetAssignedId",
                table: "Assignees");

            migrationBuilder.DropColumn(
                name: "GetAssignedId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "GetAssignedId",
                table: "Severities");

            migrationBuilder.DropColumn(
                name: "GetAssignedId",
                table: "Assignees");
        }
    }
}

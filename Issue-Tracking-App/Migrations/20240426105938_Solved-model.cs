using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_Tracking_App.Migrations
{
    /// <inheritdoc />
    public partial class Solvedmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SolvedIssueNumber",
                table: "Statuses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SolvedIssueNumber",
                table: "Severities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SolvedIssueNumber",
                table: "Issues",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SolvedIssueNumber",
                table: "Assignees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Solveds",
                columns: table => new
                {
                    IssueNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    EstimateTime = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssigneeID = table.Column<int>(type: "int", nullable: false),
                    SeverityID = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solveds", x => x.IssueNumber);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_SolvedIssueNumber",
                table: "Statuses",
                column: "SolvedIssueNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Severities_SolvedIssueNumber",
                table: "Severities",
                column: "SolvedIssueNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_SolvedIssueNumber",
                table: "Issues",
                column: "SolvedIssueNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_SolvedIssueNumber",
                table: "Assignees",
                column: "SolvedIssueNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignees_Solveds_SolvedIssueNumber",
                table: "Assignees",
                column: "SolvedIssueNumber",
                principalTable: "Solveds",
                principalColumn: "IssueNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Solveds_SolvedIssueNumber",
                table: "Issues",
                column: "SolvedIssueNumber",
                principalTable: "Solveds",
                principalColumn: "IssueNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Severities_Solveds_SolvedIssueNumber",
                table: "Severities",
                column: "SolvedIssueNumber",
                principalTable: "Solveds",
                principalColumn: "IssueNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Solveds_SolvedIssueNumber",
                table: "Statuses",
                column: "SolvedIssueNumber",
                principalTable: "Solveds",
                principalColumn: "IssueNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignees_Solveds_SolvedIssueNumber",
                table: "Assignees");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Solveds_SolvedIssueNumber",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Severities_Solveds_SolvedIssueNumber",
                table: "Severities");

            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Solveds_SolvedIssueNumber",
                table: "Statuses");

            migrationBuilder.DropTable(
                name: "Solveds");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_SolvedIssueNumber",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Severities_SolvedIssueNumber",
                table: "Severities");

            migrationBuilder.DropIndex(
                name: "IX_Issues_SolvedIssueNumber",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Assignees_SolvedIssueNumber",
                table: "Assignees");

            migrationBuilder.DropColumn(
                name: "SolvedIssueNumber",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "SolvedIssueNumber",
                table: "Severities");

            migrationBuilder.DropColumn(
                name: "SolvedIssueNumber",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "SolvedIssueNumber",
                table: "Assignees");
        }
    }
}

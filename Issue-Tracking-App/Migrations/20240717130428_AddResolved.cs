using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_Tracking_App.Migrations
{
    /// <inheritdoc />
    public partial class AddResolved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Solveds_SolvedIssueNumber",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_SolvedIssueNumber",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "SolvedIssueNumber",
                table: "Issues");

            migrationBuilder.AddColumn<int>(
                name: "SolvedIssueNumber",
                table: "Applications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_SolvedIssueNumber",
                table: "Applications",
                column: "SolvedIssueNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Solveds_SolvedIssueNumber",
                table: "Applications",
                column: "SolvedIssueNumber",
                principalTable: "Solveds",
                principalColumn: "IssueNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Solveds_SolvedIssueNumber",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_SolvedIssueNumber",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "SolvedIssueNumber",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "SolvedIssueNumber",
                table: "Issues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_SolvedIssueNumber",
                table: "Issues",
                column: "SolvedIssueNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Solveds_SolvedIssueNumber",
                table: "Issues",
                column: "SolvedIssueNumber",
                principalTable: "Solveds",
                principalColumn: "IssueNumber");
        }
    }
}

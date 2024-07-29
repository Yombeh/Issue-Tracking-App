using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_Tracking_App.Migrations
{
    /// <inheritdoc />
    public partial class EF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Tester",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "IssueCreated",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tester_TestId",
                table: "Tester",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueCreated_TestId",
                table: "IssueCreated",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueCreated_Tests_TestId",
                table: "IssueCreated",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tester_Tests_TestId",
                table: "Tester",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueCreated_Tests_TestId",
                table: "IssueCreated");

            migrationBuilder.DropForeignKey(
                name: "FK_Tester_Tests_TestId",
                table: "Tester");

            migrationBuilder.DropIndex(
                name: "IX_Tester_TestId",
                table: "Tester");

            migrationBuilder.DropIndex(
                name: "IX_IssueCreated_TestId",
                table: "IssueCreated");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Tester");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "IssueCreated");
        }
    }
}

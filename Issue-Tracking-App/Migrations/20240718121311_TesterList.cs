using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_Tracking_App.Migrations
{
    /// <inheritdoc />
    public partial class TesterList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tester_Tests_TestId",
                table: "Tester");

            migrationBuilder.DropIndex(
                name: "IX_Tester_TestId",
                table: "Tester");

            migrationBuilder.DropColumn(
                name: "TestersID",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Tester");

            migrationBuilder.AddColumn<string>(
                name: "Tester",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tester",
                table: "Tests");

            migrationBuilder.AddColumn<int>(
                name: "TestersID",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Tester",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tester_TestId",
                table: "Tester",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tester_Tests_TestId",
                table: "Tester",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id");
        }
    }
}

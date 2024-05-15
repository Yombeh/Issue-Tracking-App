using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_Tracking_App.Migrations
{
    /// <inheritdoc />
    public partial class summ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SummaryID",
                table: "Solveds",
                newName: "IssuesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IssuesID",
                table: "Solveds",
                newName: "SummaryID");
        }
    }
}

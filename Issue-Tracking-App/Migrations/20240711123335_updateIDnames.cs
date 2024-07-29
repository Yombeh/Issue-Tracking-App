using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_Tracking_App.Migrations
{
    /// <inheritdoc />
    public partial class updateIDnames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserReports",
                newName: "UserReportId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Applications",
                newName: "AppId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserReportId",
                table: "UserReports",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AppId",
                table: "Applications",
                newName: "Id");
        }
    }
}

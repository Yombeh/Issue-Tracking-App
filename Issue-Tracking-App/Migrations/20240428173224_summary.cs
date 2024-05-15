using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_Tracking_App.Migrations
{
    /// <inheritdoc />
    public partial class summary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Solveds");

            migrationBuilder.AddColumn<int>(
                name: "SummaryID",
                table: "Solveds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SummaryID",
                table: "Solveds");

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Solveds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

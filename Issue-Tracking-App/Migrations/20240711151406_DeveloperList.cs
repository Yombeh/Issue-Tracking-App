using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_Tracking_App.Migrations
{
    /// <inheritdoc />
    public partial class DeveloperList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssigneeID",
                table: "Developers");

            migrationBuilder.AddColumn<string>(
                name: "DeveloperName",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeveloperName",
                table: "Developers");

            migrationBuilder.AddColumn<int>(
                name: "AssigneeID",
                table: "Developers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

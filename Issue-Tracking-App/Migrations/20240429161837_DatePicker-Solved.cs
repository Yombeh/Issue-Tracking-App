using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_Tracking_App.Migrations
{
    /// <inheritdoc />
    public partial class DatePickerSolved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DatePicker",
                table: "Solveds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePicker",
                table: "Solveds");
        }
    }
}

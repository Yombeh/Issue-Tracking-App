using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_Tracking_App.Migrations
{
    /// <inheritdoc />
    public partial class datepicker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DateTimePicker",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimePicker",
                table: "Issues");
        }
    }
}

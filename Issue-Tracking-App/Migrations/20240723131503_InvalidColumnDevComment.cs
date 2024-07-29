using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_Tracking_App.Migrations
{
    /// <inheritdoc />
    public partial class InvalidColumnDevComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentByDevs_UserReports_UserReportsUserReportId",
                table: "CommentByDevs");

            migrationBuilder.AlterColumn<int>(
                name: "UserReportsUserReportId",
                table: "CommentByDevs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentByDevs_UserReports_UserReportsUserReportId",
                table: "CommentByDevs",
                column: "UserReportsUserReportId",
                principalTable: "UserReports",
                principalColumn: "UserReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentByDevs_UserReports_UserReportsUserReportId",
                table: "CommentByDevs");

            migrationBuilder.AlterColumn<int>(
                name: "UserReportsUserReportId",
                table: "CommentByDevs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentByDevs_UserReports_UserReportsUserReportId",
                table: "CommentByDevs",
                column: "UserReportsUserReportId",
                principalTable: "UserReports",
                principalColumn: "UserReportId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

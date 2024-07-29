using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_Tracking_App.Migrations
{
    /// <inheritdoc />
    public partial class devAndTesComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentByDevs",
                columns: table => new
                {
                    devCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    devComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserReportsUserReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentByDevs", x => x.devCommentId);
                    table.ForeignKey(
                        name: "FK_CommentByDevs_UserReports_UserReportsUserReportId",
                        column: x => x.UserReportsUserReportId,
                        principalTable: "UserReports",
                        principalColumn: "UserReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentByTesters",
                columns: table => new
                {
                    testerCommementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    testerComment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentByTesters", x => x.testerCommementId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentByDevs_UserReportsUserReportId",
                table: "CommentByDevs",
                column: "UserReportsUserReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentByDevs");

            migrationBuilder.DropTable(
                name: "CommentByTesters");
        }
    }
}

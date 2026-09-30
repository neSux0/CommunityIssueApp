using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityAppMiniProjectWinForms.Migrations
{
    /// <inheritdoc />
    public partial class AddIssueVotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueVotes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    IssueId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConfirmedIssue = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConfirmedComplete = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueVotes", x => new { x.UserId, x.IssueId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueVotes");
        }
    }
}

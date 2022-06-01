using Microsoft.EntityFrameworkCore.Migrations;

namespace NewLinkShortApp.Migrations
{
    public partial class indata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "NewCertificates",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NewCertificates_AppUserId",
                table: "NewCertificates",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewCertificates_AppUsers_AppUserId",
                table: "NewCertificates",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewCertificates_AppUsers_AppUserId",
                table: "NewCertificates");

            migrationBuilder.DropIndex(
                name: "IX_NewCertificates_AppUserId",
                table: "NewCertificates");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "NewCertificates");
        }
    }
}

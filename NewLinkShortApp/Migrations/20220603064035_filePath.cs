using Microsoft.EntityFrameworkCore.Migrations;

namespace NewLinkShortApp.Migrations
{
    public partial class filePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath2",
                table: "Templates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath2",
                table: "NewCertificates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath2",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "FilePath2",
                table: "NewCertificates");
        }
    }
}

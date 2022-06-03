using Microsoft.EntityFrameworkCore.Migrations;

namespace NewLinkShortApp.Migrations
{
    public partial class text2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text_",
                table: "FieldValues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text_",
                table: "FieldValues");
        }
    }
}

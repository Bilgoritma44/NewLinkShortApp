using Microsoft.EntityFrameworkCore.Migrations;

namespace NewLinkShortApp.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text1",
                table: "FieldValues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2",
                table: "FieldValues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3",
                table: "FieldValues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text4",
                table: "FieldValues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text5",
                table: "FieldValues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text1",
                table: "FieldValues");

            migrationBuilder.DropColumn(
                name: "Text2",
                table: "FieldValues");

            migrationBuilder.DropColumn(
                name: "Text3",
                table: "FieldValues");

            migrationBuilder.DropColumn(
                name: "Text4",
                table: "FieldValues");

            migrationBuilder.DropColumn(
                name: "Text5",
                table: "FieldValues");
        }
    }
}

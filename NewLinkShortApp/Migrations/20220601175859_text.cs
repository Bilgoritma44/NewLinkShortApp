using Microsoft.EntityFrameworkCore.Migrations;

namespace NewLinkShortApp.Migrations
{
    public partial class text : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Text_1",
                table: "FieldValues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text_2",
                table: "FieldValues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text_3",
                table: "FieldValues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text_4",
                table: "FieldValues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text_5",
                table: "FieldValues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text_1",
                table: "FieldValues");

            migrationBuilder.DropColumn(
                name: "Text_2",
                table: "FieldValues");

            migrationBuilder.DropColumn(
                name: "Text_3",
                table: "FieldValues");

            migrationBuilder.DropColumn(
                name: "Text_4",
                table: "FieldValues");

            migrationBuilder.DropColumn(
                name: "Text_5",
                table: "FieldValues");

            migrationBuilder.AddColumn<string>(
                name: "Text1",
                table: "FieldValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text2",
                table: "FieldValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text3",
                table: "FieldValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text4",
                table: "FieldValues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text5",
                table: "FieldValues",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

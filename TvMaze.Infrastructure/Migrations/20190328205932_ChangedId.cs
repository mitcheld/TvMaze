using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TvMaze.Infrastructure.Migrations
{
    public partial class ChangedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OriginalId",
                table: "Shows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDay",
                table: "CastMembers",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "OriginalId",
                table: "CastMembers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "OriginalId",
                table: "CastMembers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDay",
                table: "CastMembers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}

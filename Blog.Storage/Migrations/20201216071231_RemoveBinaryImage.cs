using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Storage.Migrations
{
    public partial class RemoveBinaryImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Posts",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}

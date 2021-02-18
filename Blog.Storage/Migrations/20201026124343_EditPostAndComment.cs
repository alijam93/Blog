using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Storage.Migrations
{
    public partial class EditPostAndComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ReplayId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ReplayId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ReplayId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                maxLength: 3000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReplyId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReplyId",
                table: "Comments",
                column: "ReplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ReplyId",
                table: "Comments",
                column: "ReplyId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ReplyId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ReplyId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ReplyId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3000);

            migrationBuilder.AddColumn<int>(
                name: "ReplayId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReplayId",
                table: "Comments",
                column: "ReplayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ReplayId",
                table: "Comments",
                column: "ReplayId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

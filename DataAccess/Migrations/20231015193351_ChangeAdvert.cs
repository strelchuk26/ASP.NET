using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangeAdvert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_AspNetUsers_UserId1",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdverts_AspNetUsers_UserId1",
                table: "UserAdverts");

            migrationBuilder.DropIndex(
                name: "IX_UserAdverts_UserId1",
                table: "UserAdverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_UserId1",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserAdverts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Adverts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserAdverts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdverts_UserId",
                table: "UserAdverts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_UserId",
                table: "Adverts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_AspNetUsers_UserId",
                table: "Adverts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdverts_AspNetUsers_UserId",
                table: "UserAdverts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_AspNetUsers_UserId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdverts_AspNetUsers_UserId",
                table: "UserAdverts");

            migrationBuilder.DropIndex(
                name: "IX_UserAdverts_UserId",
                table: "UserAdverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_UserId",
                table: "Adverts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserAdverts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserAdverts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Adverts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Adverts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAdverts_UserId1",
                table: "UserAdverts",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_UserId1",
                table: "Adverts",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_AspNetUsers_UserId1",
                table: "Adverts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdverts_AspNetUsers_UserId1",
                table: "UserAdverts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

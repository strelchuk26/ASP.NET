using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Users_UserId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdverts_Users_UserId",
                table: "UserAdverts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserAdverts_UserId",
                table: "UserAdverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_UserId",
                table: "Adverts");

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserAdverts",
                type: "nvarchar(450)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Phone" },
                values: new object[] { 1, "2e2@gamil.com", "+380000000" });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "Description", "ImageFile", "Location", "Name", "Price", "UserId" },
                values: new object[] { 1, 3, "dsadasdas", new byte[] { 1, 3, 5 }, "Kyiv", "Salomon XT-6 Gore-Tex", 3999, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserAdverts_UserId",
                table: "UserAdverts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_UserId",
                table: "Adverts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Users_UserId",
                table: "Adverts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdverts_Users_UserId",
                table: "UserAdverts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Reload1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_ImageModels_ImageId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdverts_ImageModels_ImageId",
                table: "UserAdverts");

            migrationBuilder.DropTable(
                name: "ImageModels");

            migrationBuilder.DropIndex(
                name: "IX_UserAdverts_ImageId",
                table: "UserAdverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_ImageId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "UserAdverts");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Adverts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "UserAdverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Adverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ImageModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAdverts_ImageId",
                table: "UserAdverts",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_ImageId",
                table: "Adverts",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_ImageModels_ImageId",
                table: "Adverts",
                column: "ImageId",
                principalTable: "ImageModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdverts_ImageModels_ImageId",
                table: "UserAdverts",
                column: "ImageId",
                principalTable: "ImageModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

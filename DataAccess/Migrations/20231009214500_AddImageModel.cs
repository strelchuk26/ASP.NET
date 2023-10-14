using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddImageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Adverts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Image",
                table: "UserAdverts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Adverts");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UserAdverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                name: "ImageModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModel", x => x.Id);
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
                name: "FK_Adverts_ImageModel_ImageId",
                table: "Adverts",
                column: "ImageId",
                principalTable: "ImageModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdverts_ImageModel_ImageId",
                table: "UserAdverts",
                column: "ImageId",
                principalTable: "ImageModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_ImageModel_ImageId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdverts_ImageModel_ImageId",
                table: "UserAdverts");

            migrationBuilder.DropTable(
                name: "ImageModel");

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

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UserAdverts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "UserAdverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "Date", "Description", "Image", "Location", "Name", "Price", "UserId" },
                values: new object[] { 1, 3, "09 жовт.", "Трекінгові кросівки, 42 розмір", "https://ireland.apollo.olxcdn.com/v1/files/8fi8icpcx5k93-UA/image;s=960x1280", "Київ, Солом'янський", "Salomon XT-6 Gore-Tex", 2999, 1 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "Date", "Description", "Image", "Location", "Name", "Price", "UserId" },
                values: new object[] { 2, 3, "09 жовт.", "Трекінгові кросівки, 42 розмір", "https://ireland.apollo.olxcdn.com/v1/files/8fi8icpcx5k93-UA/image;s=960x1280", "Київ, Солом'янський", "Salomon XT-6 Gore-Tex", 2999, 1 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "Date", "Description", "Image", "Location", "Name", "Price", "UserId" },
                values: new object[] { 3, 3, "09 жовт.", "Трекінгові кросівки, 42 розмір", "https://ireland.apollo.olxcdn.com/v1/files/8fi8icpcx5k93-UA/image;s=960x1280", "Київ, Солом'янський", "Salomon XT-6 Gore-Tex", 2999, 1 });
        }
    }
}

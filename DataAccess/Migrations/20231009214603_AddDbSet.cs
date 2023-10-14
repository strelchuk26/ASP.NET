using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_ImageModel_ImageId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdverts_ImageModel_ImageId",
                table: "UserAdverts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageModel",
                table: "ImageModel");

            migrationBuilder.RenameTable(
                name: "ImageModel",
                newName: "ImageModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageModels",
                table: "ImageModels",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_ImageModels_ImageId",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdverts_ImageModels_ImageId",
                table: "UserAdverts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageModels",
                table: "ImageModels");

            migrationBuilder.RenameTable(
                name: "ImageModels",
                newName: "ImageModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageModel",
                table: "ImageModel",
                column: "Id");

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
    }
}

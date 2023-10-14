using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class FillData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Sport" },
                    { 3, "Fashion" },
                    { 4, "Home & Garden" },
                    { 5, "Transport" },
                    { 6, "Toys & Hobbies" },
                    { 7, "Musical Instruments" },
                    { 8, "Art" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Phone" },
                values: new object[] { 1, "2e2@gamil.com", "+380000000" });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Location", "Name", "Price", "UserId" },
                values: new object[] { 1, 3, "Трекінгові кросівки, 42 розмір", "https://ireland.apollo.olxcdn.com/v1/files/8fi8icpcx5k93-UA/image;s=960x1280", "Київ, Солом'янський", "Salomon XT-6 Gore-Tex", 2999m, 1 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Location", "Name", "Price", "UserId" },
                values: new object[] { 2, 3, "Трекінгові кросівки, 42 розмір", "https://ireland.apollo.olxcdn.com/v1/files/8fi8icpcx5k93-UA/image;s=960x1280", "Київ, Солом'янський", "Salomon XT-6 Gore-Tex", 2999m, 1 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Location", "Name", "Price", "UserId" },
                values: new object[] { 3, 3, "Трекінгові кросівки, 42 розмір", "https://ireland.apollo.olxcdn.com/v1/files/8fi8icpcx5k93-UA/image;s=960x1280", "Київ, Солом'янський", "Salomon XT-6 Gore-Tex", 2999m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

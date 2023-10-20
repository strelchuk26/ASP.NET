using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddOrders1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_AdvertId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AdvertId",
                table: "Orders",
                column: "AdvertId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_AdvertId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AdvertId",
                table: "Orders",
                column: "AdvertId");
        }
    }
}

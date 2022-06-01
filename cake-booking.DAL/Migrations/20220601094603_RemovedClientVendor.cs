using Microsoft.EntityFrameworkCore.Migrations;

namespace cake_booking.DAL.Migrations
{
    public partial class RemovedClientVendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ClientInformations");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ClientInformations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ClientInformations");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ClientInformations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

 
            migrationBuilder.CreateIndex(
                name: "IX_ClientVendors_ClientId",
                table: "ClientVendors",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientVendors_VendorId",
                table: "ClientVendors",
                column: "VendorId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace cake_booking.DAL.Migrations
{
    public partial class GettingEverythingUpToDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndHour",
                table: "PickUpOrders",
                newName: "EndDay");

            migrationBuilder.RenameColumn(
                name: "StartHour",
                table: "PickUpOrders",
                newName: "StartDay");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndDay",
                table: "PickUpOrders",
                newName: "EndHour");

            migrationBuilder.RenameColumn(
                name: "StartDay",
                table: "PickUpOrders",
                newName: "StartHour");
        }
    }
}

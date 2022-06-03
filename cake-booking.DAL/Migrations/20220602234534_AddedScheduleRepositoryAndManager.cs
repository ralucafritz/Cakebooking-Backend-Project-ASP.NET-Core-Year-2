using Microsoft.EntityFrameworkCore.Migrations;

namespace cake_booking.DAL.Migrations
{
    public partial class AddedScheduleRepositoryAndManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StopHour",
                table: "Schedules",
                newName: "EndHour");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndHour",
                table: "Schedules",
                newName: "StopHour");
        }
    }
}

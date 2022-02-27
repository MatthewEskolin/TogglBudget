using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TogglTimeWeb.Server.Migrations
{
    public partial class morecolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "TimeLimits",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "TimeLimits");
        }
    }
}

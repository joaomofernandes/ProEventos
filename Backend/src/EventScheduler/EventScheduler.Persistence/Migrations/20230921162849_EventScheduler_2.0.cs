using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventScheduler.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EventScheduler_20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Speakers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Speakers");
        }
    }
}

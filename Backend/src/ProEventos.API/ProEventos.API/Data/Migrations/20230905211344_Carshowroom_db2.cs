using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShowroom.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Carshowroom_db2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manufacter",
                table: "Cars",
                newName: "Manufacturer");

            migrationBuilder.AddColumn<int>(
                name: "Kms",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kms",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Cars",
                newName: "Manufacter");
        }
    }
}

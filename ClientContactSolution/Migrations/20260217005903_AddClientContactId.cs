using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientContactSolution.Migrations
{
    /// <inheritdoc />
    public partial class AddClientContactId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ClientContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClientContacts");
        }
    }
}

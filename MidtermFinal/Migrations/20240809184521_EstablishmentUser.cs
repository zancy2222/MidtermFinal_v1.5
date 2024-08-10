using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidtermFinal.Migrations
{
    /// <inheritdoc />
    public partial class EstablishmentUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "EstablishmentUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "EstablishmentUsers");
        }
    }
}

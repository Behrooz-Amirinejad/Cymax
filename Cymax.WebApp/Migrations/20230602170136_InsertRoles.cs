using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cymax.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InsertRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2415a9b3-3b27-4c25-b23c-f003f3479244", "579d4276-89ed-437f-a2c4-ca13d3c4cc6e", "Visitor", "VISITOR" },
                    { "32c25d3a-e433-46e4-ae38-97014e351558", "f406e985-192b-4b49-8d27-2c8aabf19e44", "Administration", "ADMINISTRATION" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2415a9b3-3b27-4c25-b23c-f003f3479244");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32c25d3a-e433-46e4-ae38-97014e351558");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sampleAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08beacc0-38dd-42a9-82c1-c3706a0cf19e", "08beacc0-38dd-42a9-82c1-c3706a0cf19e", "User", "USER" },
                    { "6ac343b0-00ef-4a1c-8f64-68daaca77b5b", "6ac343b0-00ef-4a1c-8f64-68daaca77b5b", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08beacc0-38dd-42a9-82c1-c3706a0cf19e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ac343b0-00ef-4a1c-8f64-68daaca77b5b");
        }
    }
}

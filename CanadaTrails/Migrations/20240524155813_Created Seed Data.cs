using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CanadaTrails.Migrations
{
    /// <inheritdoc />
    public partial class CreatedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11f2c8bc-4783-4f36-a97a-d7cf020d5503"), "Medium" },
                    { new Guid("349cfa2e-07ad-4c20-adf9-1e73d1d41f53"), "Easy" },
                    { new Guid("ae27d1da-dd2b-4ffb-8042-92efc6b6c525"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("227c67d9-7b35-4445-8ab2-7c9de5899b72"), "SMS", "Summer Side", "summerSide.jpg" },
                    { new Guid("6bf45a00-d01d-4352-a84b-ded1341ce41c"), "AUR", "Aurora", "aurora.jpg" },
                    { new Guid("f5da48e5-758e-4476-b202-f2f3e5586858"), "WLK", "Walker", "walker.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("11f2c8bc-4783-4f36-a97a-d7cf020d5503"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("349cfa2e-07ad-4c20-adf9-1e73d1d41f53"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ae27d1da-dd2b-4ffb-8042-92efc6b6c525"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("227c67d9-7b35-4445-8ab2-7c9de5899b72"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6bf45a00-d01d-4352-a84b-ded1341ce41c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f5da48e5-758e-4476-b202-f2f3e5586858"));
        }
    }
}

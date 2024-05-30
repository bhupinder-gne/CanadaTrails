using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CanadaTrails.Migrations
{
    /// <inheritdoc />
    public partial class Addingimagestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("176c1c30-a24f-4253-a7d3-d0b751f69bb1"), "Hard" },
                    { new Guid("645ec315-8f74-4b7c-ba64-e8a3ebbc4553"), "Medium" },
                    { new Guid("7d09125a-ab86-49e5-9cb2-c3501505b7c4"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1418e780-1d5f-4564-b235-fb7c8913c755"), "AUR", "Aurora", "aurora.jpg" },
                    { new Guid("f3ffd628-2b92-4f46-88a0-139593b05ead"), "SMS", "Summer Side", "summerSide.jpg" },
                    { new Guid("f8ea65df-a396-40a8-a6f7-dae8a30d9e5c"), "WLK", "Walker", "walker.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("176c1c30-a24f-4253-a7d3-d0b751f69bb1"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("645ec315-8f74-4b7c-ba64-e8a3ebbc4553"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7d09125a-ab86-49e5-9cb2-c3501505b7c4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1418e780-1d5f-4564-b235-fb7c8913c755"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f3ffd628-2b92-4f46-88a0-139593b05ead"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f8ea65df-a396-40a8-a6f7-dae8a30d9e5c"));

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
    }
}

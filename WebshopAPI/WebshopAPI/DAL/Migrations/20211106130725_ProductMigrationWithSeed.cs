using Microsoft.EntityFrameworkCore.Migrations;

namespace WebshopAPI.DAL.Migrations
{
    public partial class ProductMigrationWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "RAMs");

            migrationBuilder.InsertData(
                table: "CPUs",
                columns: new[] { "ID", "AcquisitionPrice", "Brand", "CoreNumber", "ImgURL", "L3Cache", "ProductName", "SellPrice", "SocketType", "Speed" },
                values: new object[,]
                {
                    { 1, 100, "INTEL", 8, "", 24, "Test CPU 1", 110, "LGA 1700", 3700 },
                    { 2, 120, "AMD", 12, "", 32, "Test CPU 2", 140, "AM4", 3900 }
                });

            migrationBuilder.InsertData(
                table: "Motherboards",
                columns: new[] { "ID", "AcquisitionPrice", "Brand", "CPUSocketType", "ImgURL", "MaxMemorySize", "MemorySocketType", "NumberOfMemorySockets", "ProductName", "SellPrice", "SizeStandard", "Usb3Amount", "Wifi" },
                values: new object[,]
                {
                    { 1, 80, "ASUS", "AM4", "", 128, "DDR4", 4, "Test Motherboard 1", 95, "ATX", 8, true },
                    { 2, 110, "MSI", "LGA 1700", "", 128, "DDR5", 4, "Test Motherboard 2", 125, "EATX", 6, true }
                });

            migrationBuilder.InsertData(
                table: "RAMs",
                columns: new[] { "ID", "AcquisitionPrice", "Brand", "Delay", "Gb", "ImgURL", "ProductName", "SellPrice", "SocketType", "Speed" },
                values: new object[,]
                {
                    { 1, 30, "G.SKILL", 8, 32, "", "Test RAM 1", 35, "DDR4", 4200 },
                    { 2, 80, "KINGSTON", 12, 64, "", "Test RAM 2", 99, "DDR5", 6700 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CPUs",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CPUs",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Motherboards",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Motherboards",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RAMs",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RAMs",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "RAMs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

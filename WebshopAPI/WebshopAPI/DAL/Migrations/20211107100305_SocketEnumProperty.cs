using Microsoft.EntityFrameworkCore.Migrations;

namespace WebshopAPI.DAL.Migrations
{
    public partial class SocketEnumProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoreNumber = table.Column<int>(type: "int", nullable: false),
                    L3Cache = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    SocketType = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcquisitionPrice = table.Column<int>(type: "int", nullable: false),
                    SellPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usb3Amount = table.Column<int>(type: "int", nullable: false),
                    Wifi = table.Column<bool>(type: "bit", nullable: false),
                    SizeStandard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPUSocketType = table.Column<int>(type: "int", nullable: false),
                    MemorySocketType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxMemorySize = table.Column<int>(type: "int", nullable: false),
                    NumberOfMemorySockets = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcquisitionPrice = table.Column<int>(type: "int", nullable: false),
                    SellPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RAMs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gb = table.Column<int>(type: "int", nullable: false),
                    Delay = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    SocketType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcquisitionPrice = table.Column<int>(type: "int", nullable: false),
                    SellPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMs", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "CPUs",
                columns: new[] { "ID", "AcquisitionPrice", "Brand", "CoreNumber", "ImgURL", "L3Cache", "ProductName", "SellPrice", "SocketType", "Speed" },
                values: new object[,]
                {
                    { 1, 100, "INTEL", 8, "", 24, "Test CPU 1", 110, 27, 3700 },
                    { 2, 120, "AMD", 12, "", 32, "Test CPU 2", 140, 11, 3900 }
                });

            migrationBuilder.InsertData(
                table: "Motherboards",
                columns: new[] { "ID", "AcquisitionPrice", "Brand", "CPUSocketType", "ImgURL", "MaxMemorySize", "MemorySocketType", "NumberOfMemorySockets", "ProductName", "SellPrice", "SizeStandard", "Usb3Amount", "Wifi" },
                values: new object[,]
                {
                    { 1, 80, "ASUS", 11, "", 128, "DDR4", 4, "Test Motherboard 1", 95, "ATX", 8, true },
                    { 2, 110, "MSI", 27, "", 128, "DDR5", 4, "Test Motherboard 2", 125, "EATX", 6, true }
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
            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "RAMs");
        }
    }
}

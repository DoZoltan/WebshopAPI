using Microsoft.EntityFrameworkCore.Migrations;

namespace WebshopAPI.DAL.Migrations
{
    public partial class TypeForProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RAMs",
                table: "RAMs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CPUs",
                table: "CPUs");

            migrationBuilder.RenameTable(
                name: "RAMs",
                newName: "Rams");

            migrationBuilder.RenameTable(
                name: "CPUs",
                newName: "Cpus");

            migrationBuilder.RenameColumn(
                name: "CPUSocketType",
                table: "Motherboards",
                newName: "CpuSocketType");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Rams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Rams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "Rams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Motherboards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Motherboards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "Motherboards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Cpus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Cpus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "Cpus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rams",
                table: "Rams",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cpus",
                table: "Cpus",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Cpus",
                keyColumn: "ID",
                keyValue: 1,
                column: "ProductType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cpus",
                keyColumn: "ID",
                keyValue: 2,
                column: "ProductType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Motherboards",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "MemorySocketType", "ProductType" },
                values: new object[] { 5, 3 });

            migrationBuilder.UpdateData(
                table: "Motherboards",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "MemorySocketType", "ProductType" },
                values: new object[] { 6, 3 });

            migrationBuilder.UpdateData(
                table: "Rams",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ProductType", "SocketType" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "Rams",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ProductType", "SocketType" },
                values: new object[] { 2, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rams",
                table: "Rams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cpus",
                table: "Cpus");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Rams");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "Cpus");

            migrationBuilder.RenameTable(
                name: "Rams",
                newName: "RAMs");

            migrationBuilder.RenameTable(
                name: "Cpus",
                newName: "CPUs");

            migrationBuilder.RenameColumn(
                name: "CpuSocketType",
                table: "Motherboards",
                newName: "CPUSocketType");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "RAMs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "RAMs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Motherboards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Motherboards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "CPUs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "CPUs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RAMs",
                table: "RAMs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CPUs",
                table: "CPUs",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Motherboards",
                keyColumn: "ID",
                keyValue: 1,
                column: "MemorySocketType",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Motherboards",
                keyColumn: "ID",
                keyValue: 2,
                column: "MemorySocketType",
                value: 5);

            migrationBuilder.UpdateData(
                table: "RAMs",
                keyColumn: "ID",
                keyValue: 1,
                column: "SocketType",
                value: 4);

            migrationBuilder.UpdateData(
                table: "RAMs",
                keyColumn: "ID",
                keyValue: 2,
                column: "SocketType",
                value: 5);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicBilling.API.Migrations
{
    public partial class Added_Amount_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Billings",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 65.200000000000003);

            migrationBuilder.UpdateData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Amount",
                value: 165.90000000000001);

            migrationBuilder.UpdateData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Amount",
                value: 35.0);

            migrationBuilder.UpdateData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Amount",
                value: 270.0);

            migrationBuilder.UpdateData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Amount",
                value: 84.5);

            migrationBuilder.UpdateData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 6,
                column: "Amount",
                value: 15.0);

            migrationBuilder.UpdateData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 7,
                column: "Amount",
                value: 87.299999999999997);

            migrationBuilder.UpdateData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 8,
                column: "Amount",
                value: 94.099999999999994);

            migrationBuilder.UpdateData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 9,
                column: "Amount",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "Billings",
                keyColumn: "Id",
                keyValue: 10,
                column: "Amount",
                value: 61.700000000000003);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Billings");
        }
    }
}

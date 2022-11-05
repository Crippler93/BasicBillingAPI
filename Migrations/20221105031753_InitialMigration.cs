using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicBilling.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Period = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    BillId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Billings_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Billings_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "Category", "Period" },
                values: new object[] { 1, "WATER", 202209 });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "Category", "Period" },
                values: new object[] { 2, "ELECTRICITY", 202210 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[] { 100, "Joseph Carlton" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[] { 200, "Maria Juarez" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[] { 300, "Albert Kenny" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[] { 400, "Jessica Philips" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[] { 500, "Charles Johnson" });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "Id", "BillId", "ClientId", "State" },
                values: new object[] { 1, 1, 100, "Pending" });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "Id", "BillId", "ClientId", "State" },
                values: new object[] { 2, 2, 100, "Paid" });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "Id", "BillId", "ClientId", "State" },
                values: new object[] { 3, 1, 200, "Paid" });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "Id", "BillId", "ClientId", "State" },
                values: new object[] { 4, 2, 200, "Pending" });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "Id", "BillId", "ClientId", "State" },
                values: new object[] { 5, 1, 300, "Paid" });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "Id", "BillId", "ClientId", "State" },
                values: new object[] { 6, 2, 300, "Paid" });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "Id", "BillId", "ClientId", "State" },
                values: new object[] { 7, 1, 400, "Pending" });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "Id", "BillId", "ClientId", "State" },
                values: new object[] { 8, 2, 400, "Paid" });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "Id", "BillId", "ClientId", "State" },
                values: new object[] { 9, 1, 500, "Paid" });

            migrationBuilder.InsertData(
                table: "Billings",
                columns: new[] { "Id", "BillId", "ClientId", "State" },
                values: new object[] { 10, 2, 500, "Pending" });

            migrationBuilder.CreateIndex(
                name: "IX_Billings_BillId",
                table: "Billings",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_ClientId",
                table: "Billings",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}

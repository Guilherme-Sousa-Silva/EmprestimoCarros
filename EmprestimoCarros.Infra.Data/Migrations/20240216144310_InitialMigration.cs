using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimoCarros.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false),
                    Model = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Brand = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Year = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false),
                    Document = table.Column<string>(type: "NVARCHAR(15)", maxLength: 15, nullable: false),
                    Street = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(25)", maxLength: 25, nullable: false),
                    Number = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerLendingCar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "INT", nullable: false),
                    CarId = table.Column<int>(type: "INT", nullable: false),
                    LendingDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    DeliveryDate = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    Delivered = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLendingCar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerLendingCar_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerLendingCar_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLendingCar_CarId",
                table: "CustomerLendingCar",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLendingCar_CustomerId",
                table: "CustomerLendingCar",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerLendingCar");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimoCarros.API.Migrations
{
    public partial class CreateDataBase : Migration
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
                    City = table.Column<string>(type: "NVARCHAR(2)", maxLength: 2, nullable: false),
                    Number = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: false),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customerLendingCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    LendingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delivered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerLendingCars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerLendingCar",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLendingCar", x => new { x.CarId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomerLendingCar_CarId",
                        column: x => x.CarId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerLendingCar_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "customerLendingCars");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}

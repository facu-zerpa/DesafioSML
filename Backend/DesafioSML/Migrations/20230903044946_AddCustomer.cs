using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioSML.Migrations
{
    public partial class AddCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "FirstName", "LastName" },
                values: new object[] { 1, "Av Pueyrredon 285", "Facundo", "Zerpa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);
        }
    }
}

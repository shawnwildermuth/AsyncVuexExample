using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VueValidation.Migrations
{
    public partial class InitialCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    CityTown = table.Column<string>(nullable: true),
                    StateProvince = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CityTown", "CompanyName", "ContactName", "Country", "Phone", "PostalCode", "StateProvince" },
                values: new object[] { 1, "123 Main Street", null, "Atlanta", "Wilder Minds LLC", "Shawn Wildermuth", "USA", "404-555-1212", "12345", "GA" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CityTown", "CompanyName", "ContactName", "Country", "Phone", "PostalCode", "StateProvince" },
                values: new object[] { 2, "123 Main Street", null, "Atlanta", "Hello World Film", "Jake Smith", "USA", "404-555-1212", "12345", "GA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}

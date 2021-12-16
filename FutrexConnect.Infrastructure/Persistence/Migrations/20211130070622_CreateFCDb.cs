using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutrexConnect.Infrastructure.Persistence.Migrations
{
    public partial class CreateFCDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddressDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    OfficePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddressDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAddressDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerContactDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesignationCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContactDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerContactDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSupportingDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentUniqueReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSupportingDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSupportingDocuments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CustomerName", "CustomerType", "ModifiedBy", "ModifiedOn", "Website" },
                values: new object[] { 1L, null, null, "Fitnerss First", "Serviceprovider", null, null, null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CustomerName", "CustomerType", "ModifiedBy", "ModifiedOn", "Website" },
                values: new object[] { 2L, null, null, "John Doe", "IndividualUser", null, null, null });

            migrationBuilder.InsertData(
                table: "CustomerAddressDetails",
                columns: new[] { "Id", "Address1", "Address2", "City", "CompanyLogo", "Country", "CreatedBy", "CreatedOn", "CustomerId", "Email", "ModifiedBy", "ModifiedOn", "OfficeFax", "OfficePhone", "PinCode", "State" },
                values: new object[] { 1L, null, null, "Dubai", null, "United Arab Emirates", null, null, 1L, null, null, null, null, null, 0, "Dubai" });

            migrationBuilder.InsertData(
                table: "CustomerAddressDetails",
                columns: new[] { "Id", "Address1", "Address2", "City", "CompanyLogo", "Country", "CreatedBy", "CreatedOn", "CustomerId", "Email", "ModifiedBy", "ModifiedOn", "OfficeFax", "OfficePhone", "PinCode", "State" },
                values: new object[] { 2L, null, null, "Seattle", null, "United States", null, null, 2L, null, null, null, null, null, 0, "Washington" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddressDetails_CustomerId",
                table: "CustomerAddressDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContactDetails_CustomerId",
                table: "CustomerContactDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupportingDocuments_CustomerId",
                table: "CustomerSupportingDocuments",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddressDetails");

            migrationBuilder.DropTable(
                name: "CustomerContactDetails");

            migrationBuilder.DropTable(
                name: "CustomerSupportingDocuments");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}

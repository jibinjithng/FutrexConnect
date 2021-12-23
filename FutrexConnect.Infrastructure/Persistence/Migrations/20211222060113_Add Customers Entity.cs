using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutrexConnect.Infrastructure.Persistence.Migrations
{
    public partial class AddCustomersEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddressDetails_Customer_CustomerId",
                table: "CustomerAddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContactDetails_Customer_CustomerId",
                table: "CustomerContactDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSupportingDocuments_Customer_CustomerId",
                table: "CustomerSupportingDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddressDetails_Customers_CustomerId",
                table: "CustomerAddressDetails",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContactDetails_Customers_CustomerId",
                table: "CustomerContactDetails",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSupportingDocuments_Customers_CustomerId",
                table: "CustomerSupportingDocuments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddressDetails_Customers_CustomerId",
                table: "CustomerAddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContactDetails_Customers_CustomerId",
                table: "CustomerContactDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSupportingDocuments_Customers_CustomerId",
                table: "CustomerSupportingDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddressDetails_Customer_CustomerId",
                table: "CustomerAddressDetails",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerContactDetails_Customer_CustomerId",
                table: "CustomerContactDetails",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSupportingDocuments_Customer_CustomerId",
                table: "CustomerSupportingDocuments",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

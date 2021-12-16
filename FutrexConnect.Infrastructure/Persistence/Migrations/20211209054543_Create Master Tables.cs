using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutrexConnect.Infrastructure.Persistence.Migrations
{
    public partial class CreateMasterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "City",
                table: "CustomerAddressDetails");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "CustomerAddressDetails");

            migrationBuilder.DropColumn(
                name: "State",
                table: "CustomerAddressDetails");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "CustomerAddressDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CountryId",
                table: "CustomerAddressDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StateId",
                table: "CustomerAddressDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryPhoneCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthParameterGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParameterGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthParameterGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthReferenceTables",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthReferenceTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductColorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductModels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductModelCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemLanguages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UOMCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UOMName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UOMGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthParameters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParameterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParameterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HealthParameterGroupId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthParameters_HealthParameterGroups_HealthParameterGroupId",
                        column: x => x.HealthParameterGroupId,
                        principalTable: "HealthParameterGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDisplayCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductGroupId = table.Column<long>(type: "bigint", nullable: true),
                    ProductModelId = table.Column<long>(type: "bigint", nullable: true),
                    ProductColorId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductColors_ProductColorId",
                        column: x => x.ProductColorId,
                        principalTable: "ProductColors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ProductModels_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "ProductModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UOMConversions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceUOMId = table.Column<long>(type: "bigint", nullable: false),
                    TargetUOMId = table.Column<long>(type: "bigint", nullable: true),
                    Conversion = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UOMConversions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UOMConversions_UnitOfMeasures_SourceUOMId",
                        column: x => x.SourceUOMId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UOMConversions_UnitOfMeasures_TargetUOMId",
                        column: x => x.TargetUOMId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthReferenceRows",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthParameterResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HealthReferenceTableId = table.Column<long>(type: "bigint", nullable: false),
                    HealthParameterId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthReferenceRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthReferenceRows_HealthParameters_HealthParameterId",
                        column: x => x.HealthParameterId,
                        principalTable: "HealthParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthReferenceRows_HealthReferenceTables_HealthReferenceTableId",
                        column: x => x.HealthReferenceTableId,
                        principalTable: "HealthReferenceTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Individuals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FutrexConnectID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndividualName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    StateId = table.Column<long>(type: "bigint", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individuals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Individuals_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Individuals_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Individuals_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    OfficePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseCurrencyId = table.Column<long>(type: "bigint", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    StateId = table.Column<long>(type: "bigint", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_Currencies_BaseCurrencyId",
                        column: x => x.BaseCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organizations_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HealthReferenceRowCriterias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComparisonOperator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComparisonValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HealthParameterToCompareId = table.Column<long>(type: "bigint", nullable: true),
                    HealthReferenceRowId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthReferenceRowCriterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthReferenceRowCriterias_HealthParameters_HealthParameterToCompareId",
                        column: x => x.HealthParameterToCompareId,
                        principalTable: "HealthParameters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HealthReferenceRowCriterias_HealthReferenceRows_HealthReferenceRowId",
                        column: x => x.HealthReferenceRowId,
                        principalTable: "HealthReferenceRows",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "CountryName", "CountryPhoneCode", "CreatedBy", "CreatedOn", "IsActive", "ModifiedBy", "ModifiedOn" },
                values: new object[] { 1L, "UAE", "United Arab Emirates", null, null, null, false, null, null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "CountryName", "CountryPhoneCode", "CreatedBy", "CreatedOn", "IsActive", "ModifiedBy", "ModifiedOn" },
                values: new object[] { 2L, "IND", "India", null, null, null, false, null, null });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "CreatedBy", "CreatedOn", "IsActive", "ModifiedBy", "ModifiedOn", "StateCode", "StateName" },
                values: new object[] { 1L, 1L, null, null, false, null, null, "DXB", "Dubai" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "CreatedBy", "CreatedOn", "IsActive", "ModifiedBy", "ModifiedOn", "StateCode", "StateName" },
                values: new object[] { 2L, 1L, null, null, false, null, null, "MH", "Maharashtra" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityCode", "CityName", "CreatedBy", "CreatedOn", "IsActive", "ModifiedBy", "ModifiedOn", "StateId" },
                values: new object[] { 1L, "DXB", "Dubai", null, null, false, null, null, 1L });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityCode", "CityName", "CreatedBy", "CreatedOn", "IsActive", "ModifiedBy", "ModifiedOn", "StateId" },
                values: new object[] { 2L, "BOM", "Mumbai", null, null, false, null, null, 1L });

            migrationBuilder.UpdateData(
                table: "CustomerAddressDetails",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CityId", "CountryId", "StateId" },
                values: new object[] { 1L, 2L, 1L });

            migrationBuilder.UpdateData(
                table: "CustomerAddressDetails",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CityId", "CountryId", "StateId" },
                values: new object[] { 2L, 2L, 2L });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddressDetails_CityId",
                table: "CustomerAddressDetails",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddressDetails_CountryId",
                table: "CustomerAddressDetails",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddressDetails_StateId",
                table: "CustomerAddressDetails",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthParameters_HealthParameterGroupId",
                table: "HealthParameters",
                column: "HealthParameterGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthReferenceRowCriterias_HealthParameterToCompareId",
                table: "HealthReferenceRowCriterias",
                column: "HealthParameterToCompareId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthReferenceRowCriterias_HealthReferenceRowId",
                table: "HealthReferenceRowCriterias",
                column: "HealthReferenceRowId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthReferenceRows_HealthParameterId",
                table: "HealthReferenceRows",
                column: "HealthParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthReferenceRows_HealthReferenceTableId",
                table: "HealthReferenceRows",
                column: "HealthReferenceTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Individuals_CityId",
                table: "Individuals",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Individuals_CountryId",
                table: "Individuals",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Individuals_StateId",
                table: "Individuals",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_BaseCurrencyId",
                table: "Organizations",
                column: "BaseCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CityId",
                table: "Organizations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CountryId",
                table: "Organizations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_StateId",
                table: "Organizations",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductColorId",
                table: "Products",
                column: "ProductColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductModelId",
                table: "Products",
                column: "ProductModelId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UOMConversions_SourceUOMId",
                table: "UOMConversions",
                column: "SourceUOMId");

            migrationBuilder.CreateIndex(
                name: "IX_UOMConversions_TargetUOMId",
                table: "UOMConversions",
                column: "TargetUOMId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddressDetails_Cities_CityId",
                table: "CustomerAddressDetails",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddressDetails_Countries_CountryId",
                table: "CustomerAddressDetails",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddressDetails_Customer_CustomerId",
                table: "CustomerAddressDetails",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddressDetails_States_StateId",
                table: "CustomerAddressDetails",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddressDetails_Cities_CityId",
                table: "CustomerAddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddressDetails_Countries_CountryId",
                table: "CustomerAddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddressDetails_Customer_CustomerId",
                table: "CustomerAddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddressDetails_States_StateId",
                table: "CustomerAddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerContactDetails_Customer_CustomerId",
                table: "CustomerContactDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSupportingDocuments_Customer_CustomerId",
                table: "CustomerSupportingDocuments");

            migrationBuilder.DropTable(
                name: "HealthReferenceRowCriterias");

            migrationBuilder.DropTable(
                name: "Individuals");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SystemLanguages");

            migrationBuilder.DropTable(
                name: "UOMConversions");

            migrationBuilder.DropTable(
                name: "HealthReferenceRows");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropTable(
                name: "ProductGroups");

            migrationBuilder.DropTable(
                name: "ProductModels");

            migrationBuilder.DropTable(
                name: "UnitOfMeasures");

            migrationBuilder.DropTable(
                name: "HealthParameters");

            migrationBuilder.DropTable(
                name: "HealthReferenceTables");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "HealthParameterGroups");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAddressDetails_CityId",
                table: "CustomerAddressDetails");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAddressDetails_CountryId",
                table: "CustomerAddressDetails");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAddressDetails_StateId",
                table: "CustomerAddressDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "CustomerAddressDetails");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "CustomerAddressDetails");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "CustomerAddressDetails");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "CustomerAddressDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "CustomerAddressDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "CustomerAddressDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "CustomerAddressDetails",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "City", "Country", "State" },
                values: new object[] { "Dubai", "United Arab Emirates", "Dubai" });

            migrationBuilder.UpdateData(
                table: "CustomerAddressDetails",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "City", "Country", "State" },
                values: new object[] { "Seattle", "United States", "Washington" });

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
    }
}

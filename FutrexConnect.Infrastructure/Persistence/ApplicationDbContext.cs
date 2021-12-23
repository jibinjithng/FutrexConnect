using FutrexConnect.Domain.Entities;
using FutrexConnect.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace FutrexConnect.Infrastructure.Persistence;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer() { Id = 1, CustomerName = "Fitnerss First", CustomerType = CustomerTypes.Serviceprovider.ToString() },
            new Customer() { Id = 2, CustomerName = "John Doe", CustomerType = CustomerTypes.IndividualUser.ToString() }
        );

        modelBuilder.Entity<Country>().HasData(
            new Country() { Id = 1, CountryName = "United Arab Emirates", CountryCode = "UAE" },
            new Country() { Id = 2, CountryName = "India", CountryCode = "IND" }
        );

        modelBuilder.Entity<State>().HasData(
            new State() { Id = 1, StateName = "Dubai", StateCode = "DXB", CountryId = 1 },
            new State() { Id = 2, StateName = "Maharashtra", StateCode = "MH", CountryId = 1 }
        );
        modelBuilder.Entity<City>().HasData(
            new City() { Id = 1, CityName = "Dubai", CityCode = "DXB", StateId = 1 },
            new City() { Id = 2, CityName = "Mumbai", CityCode = "BOM", StateId = 1 }
        );

        modelBuilder.Entity<CustomerAddressDetails>()
         .HasData(
            new CustomerAddressDetails { Id = 1, CustomerId = 1, StateId = 1, CityId = 1, CountryId = 2 },
            new CustomerAddressDetails { Id = 2, CustomerId = 2, StateId = 2, CityId = 2, CountryId = 2 }
         );
    }

    #region "Entities"
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAddressDetails> CustomerAddressDetails { get; set; }
    public DbSet<CustomerContactDetails> CustomerContactDetails { get; set; }
    public DbSet<CustomerSupportingDocuments> CustomerSupportingDocuments { get; set; }
    public DbSet<HealthParameter> HealthParameters { get; set; }
    public DbSet<HealthParameterGroup> HealthParameterGroups { get; set; }
    public DbSet<HealthReferenceRow> HealthReferenceRows { get; set; }
    public DbSet<HealthReferenceRowCriteria> HealthReferenceRowCriterias { get; set; }
    public DbSet<HealthReferenceTable> HealthReferenceTables { get; set; }
    public DbSet<Individual> Individuals { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }
    public DbSet<ProductGroup> ProductGroups { get; set; }
    public DbSet<ProductModel> ProductModels { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<SystemLanguage> SystemLanguages { get; set; }
    public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
    public DbSet<UOMConversion> UOMConversions { get; set; }
    #endregion

}
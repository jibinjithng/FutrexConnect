using System.Text.Json.Serialization;
using AutoMapper;
using FutrexConnect.Core;
using FutrexConnect.Infrastructure;
using Microsoft.OpenApi.Models;

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

IConfiguration configuration = configurationBuilder.Build();

const string webAppCORSPolicyName = "FutrexConnect.Core.ClientApp";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: webAppCORSPolicyName,
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:44463",
                                              "http://localhost:4200");
                      });
});

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new FutrexConnectCoreProfiles());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Add services to the container.
builder.Services.AddInfrastructure(configuration);
builder.Services.AddServices(configuration);

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "FutrexConnect.Core API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(webAppCORSPolicyName);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

using Asp.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RedirectTemplate.Business;
using RedirectTemplate.Business.Interface;
using RedirectTemplate.Data.Context;
using RedirectTemplate.Repository;
using RedirectTemplate.Repository.Interface;
using RedirectTemplate.Repository.MongoDB;
using RedirectTemplate.Repository.MySQL;
using RedirectTemplate.Service;
using System;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Configure API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "RedirectTemplate API",
        Version = "v1",
        Description = "API REST para geração de URLs de redirecionamento baseadas em QR codes",
        Contact = new OpenApiContact
        {
            Name = "Redirect Template",
            Email = "contato@example.com"
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    var xmlFile = "RedirectTemplate.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Configure Database Contexts
var connectionString = builder.Configuration.GetConnectionString("MySQL");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));

builder.Services.AddDbContext<MySQLContext>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddDbContext<MongoDBContext>(options => { });

// Configure Dependency Injection
// Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IQRCodeService, QRCodeService>();

// Business
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();
builder.Services.AddScoped<IBrandBusiness, BrandBusiness>();
builder.Services.AddScoped<ICountryBusiness, CountryBusiness>();
builder.Services.AddScoped<IUrlBusiness, UrlBusiness>();
builder.Services.AddScoped<IQRCodeBusiness, QRCodeBusiness>();

// Repositories - MySQL (default)
builder.Services.AddScoped<IProductRepository, RedirectTemplate.Repository.MySQL.ProductRepository>();
builder.Services.AddScoped<IBrandRepository, RedirectTemplate.Repository.MySQL.BrandRepository>();
builder.Services.AddScoped<ICountryRepository, RedirectTemplate.Repository.MySQL.CountryRepository>();
builder.Services.AddScoped<IUrlRepository, RedirectTemplate.Repository.MySQL.UrlRepository>();

// Repositories - MongoDB (commented out, uncomment to use MongoDB instead)
// builder.Services.AddScoped<IProductRepository, RedirectTemplate.Repository.MongoDB.ProductRepository>();
// builder.Services.AddScoped<IBrandRepository, RedirectTemplate.Repository.MongoDB.BrandRepository>();
// builder.Services.AddScoped<ICountryRepository, RedirectTemplate.Repository.MongoDB.CountryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RedirectTemplate API v1");
    });
}

// Redirect root to Swagger
var rewriteOptions = new RewriteOptions();
rewriteOptions.AddRedirect("^$", "swagger");
app.UseRewriter(rewriteOptions);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

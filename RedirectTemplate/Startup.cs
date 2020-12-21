using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RedirectTemplate.Application;
using RedirectTemplate.Business;
using RedirectTemplate.Business.Interface;
using RedirectTemplate.Data.Context;
using RedirectTemplate.Repository.MySQL;
using RedirectTemplate.Repository.Interface;
using RedirectTemplate.Service;
using System;
using System.IO;
using System.Reflection;

namespace RedirectTemplate
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Add Cors
            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            //Add Context MySQL
            var MySQLconnectionString = _configuration["connectionStrings:MySQL:connectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(MySQLconnectionString));

            // Add Context MongoDB
            MongoDBContext.ConnectionString = _configuration.GetSection("connectionStrings:MongoDb:connectionString").Value;
            MongoDBContext.DatabaseName = _configuration.GetSection("connectionStrings:MongoDb:database").Value;
            MongoDBContext.IsSSL = Convert.ToBoolean(_configuration.GetSection("connectionStrings:MongoDb:isSSL").Value);
            services.AddDbContext<MongoDBContext>();

            //Add Versioning
            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            //Add Swagger
            services.AddSwaggerGen(options =>
            {
                // specify our operation filter here.  
                options.DocumentFilter<CustomDocumentFilter>();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"QRCode - v1 API",
                    Description = "API construída para efetuar o redirecionamento para as campanhas criadas pela empresa",
                    TermsOfService = new Uri("https://www.randon.com.br/media/1409/pol%C3%ADtica-de-privacidade-empresas-randon.pdf"),
                    Contact = new OpenApiContact
                    {
                        Name = "Negócios Digitais",
                        Email = "diego.vieira@randon.com.br",
                        Url = new Uri("https://www.google.com.br/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Negócios Digitais",
                        Url = new Uri("https://www.randon.com.br/media/1409/pol%C3%ADtica-de-privacidade-empresas-randon.pdf")
                    }
                });
                var xmlFile = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                options.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement { { securitySchema, new[] { "Bearer" } } };
                options.AddSecurityRequirement(securityRequirement);
            });
            //Add Controllers
            services.AddControllers();

            //Dependências
            //Scoped - Criado uma vez por escopo de uso
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IProductRepository, Repository.MySQL.ProductRepository>();
            services.AddScoped<IBrandRepository, Repository.MySQL.BrandRepository>();
            services.AddScoped<ICountryRepository, Repository.MySQL.CountryRepository>();
            services.AddScoped<IUrlRepository, Repository.MySQL.UrlRepository>();

            services.AddScoped<IBrandBusiness, BrandBusiness>();
            services.AddScoped<ICountryBusiness, CountryBusiness>();
            services.AddScoped<IProductBusiness, ProductBusiness>();
            services.AddScoped<IUrlBusiness, UrlBusiness>();
            services.AddScoped<IQRCodeBusiness, QRCodeBusiness>();

            //Singleton - Uma única instância para toda a aplicação

            //Transient - Criados toda vez que são solicitados

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseSwagger(c =>
            {
            });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 API");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller}");
            });
        }
    }
}

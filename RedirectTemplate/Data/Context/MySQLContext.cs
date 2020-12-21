using Microsoft.EntityFrameworkCore;
using RedirectTemplate.Data.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedirectTemplate.Data.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BrandEntityConfiguration());
            
            modelBuilder.Entity<CountryModel>().HasData(CountryData());
            modelBuilder.Entity<ProductModel>().HasData(ProductData());
            modelBuilder.Entity<BrandModel>().HasData(BrandData());
            modelBuilder.Entity<UrlModel>().HasData(UrlData());
        }
        public DbSet<BrandModel> Brands { get; set; }
        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UrlModel> Urls { get; set; }
        private BrandModel[] BrandData()
        {
            var brands =
                new List<BrandModel>
                {
                    new BrandModel
                    {
                        Id = 1,
                        Code = "B",
                        Description = "Bestbrake",
                    },
                    new BrandModel
                    {
                        Id = 2,
                        Code = "B",
                        Description = "Controil",
                    },
                    new BrandModel
                    {
                        Id = 3,
                        Code = "D",
                        Description = "Durbloc",
                    },
                    new BrandModel
                    {
                        Id = 4,
                        Code = "E",
                        Description = "Ferodo",
                    },
                    new BrandModel
                    {
                        Id = 5,
                        Code = "F",
                        Description = "Fras-le",
                    },
                    new BrandModel
                    {
                        Id = 6,
                        Code = "J",
                        Description = "Fras-le",
                    },
                    new BrandModel
                    {
                        Id = 7,
                        Code = "L",
                        Description = "Lonaflex",
                    },
                    new BrandModel
                    {
                        Id = 8,
                        Code = "M",
                        Description = "Midland Friction",
                    },
                    new BrandModel
                    {
                        Id = 9,
                        Code = "R",
                        Description = "Randon",
                    },
                    new BrandModel
                    {
                        Id = 10,
                        Code = "S",
                        Description = "Stop",
                    },
                    new BrandModel
                    {
                        Id = 11,
                        Code = "T",
                        Description = "StradaR",
                    },
                    new BrandModel
                    {
                        Id = 12,
                        Code = "V",
                        Description = "Randon Veículos",
                    },
                    new BrandModel
                    {
                        Id = 13,
                        Code = "X",
                        Description = "Fremax",
                    },
                };
            return brands.ToArray();
        }

        private ProductModel[] ProductData()
        {
            var products = 
                new List<ProductModel>
                {
                    new ProductModel
                    {
                        Id = 1,
                        Company = 2010,
                        Serie = "ABCDE123456789ABC12",
                        ComercialName = "PD/60",
                        Brand = "F",
                        SapIdClient = "1000003450",
                        SapClientAlpha_2Code = "BR",
                        DateTimeSync = DateTime.Now
                    }, 
                    new ProductModel
                    {
                        Id = 2,
                        Company = 2010,
                        Serie = "ABCDE123456789ABC13",
                        ComercialName = "P-60",
                        Brand = "F",
                        SapIdClient = "1000049110",
                        SapClientAlpha_2Code = "BR",
                        DateTimeSync = DateTime.Now
                    }, 
                    new ProductModel
                    {
                        Id = 3,
                        Company = 2010,
                        Serie = "ABCDE123456789ABC14",
                        ComercialName = "CA/33",
                        Brand = "F",
                        SapIdClient = "1000018473",
                        SapClientAlpha_2Code = "BR",
                        DateTimeSync = DateTime.Now
                    },
                    new ProductModel
                    {
                        Id = 4,
                        Company = 2010,
                        Serie = "ABCDE123456789ABC15",
                        ComercialName = "BD0001",
                        Brand = "X",
                        SapIdClient = "1000031413",
                        SapClientAlpha_2Code = "BR",
                        DateTimeSync = DateTime.Now
                    },
                    new ProductModel
                    {
                        Id = 5,
                        Company = 2010,
                        Serie = "ABCDE123456789ABC16",
                        ComercialName = "C-2000",
                        Brand = "C",
                        SapIdClient = "1000031413",
                        SapClientAlpha_2Code = "BR",
                        DateTimeSync = DateTime.Now
                    }
                };
            return products.ToArray();
        }

        private CountryModel[] CountryData()
        {
            var countries = 
                new List<CountryModel>
                {
                    new CountryModel
                    {
                        Id = 1,
                        Name = "Afghanistan",
                        Alpha_2Code = "AF",
                        Alpha_3Code = "AFG",
                        NumericCode = 4,
                        Latitude = 33,
                        Longitude = 65,
                    },
                    new CountryModel
                    {
                        Id = 2,
                        Name = "Albania",
                        Alpha_2Code = "AL",
                        Alpha_3Code = "ALB",
                        NumericCode = 8,
                        Latitude = 41,
                        Longitude = 20,
                    },
                    new CountryModel
                    {
                        Id = 3,
                        Name = "Brazil",
                        Alpha_2Code = "BR",
                        Alpha_3Code = "BRA",
                        NumericCode = 76,
                        Latitude = -10,
                        Longitude = -55,
                    }
                };
            return countries.ToArray();
        }
        private UrlModel[] UrlData()
        {
            var urls =
                new List<UrlModel>
                {
                    new UrlModel
                    {
                        Id = 1,
                        Company = 2040,
                        Url = "https://qrcode.autoexperts.parts/product/",
                        DateTimeSync = DateTime.Now,
                    },
                   new UrlModel
                    {
                        Id = 2,
                        Company = 2510,
                        Url = "https://qrcode.autoexperts.parts/product/",
                        DateTimeSync = DateTime.Now,
                    },
                    new UrlModel
                    {
                        Id = 3,
                        Company = 1010,
                        Url = "https://qrcode.autoexperts.parts/product/",
                        DateTimeSync = DateTime.Now,
                    },
                    new UrlModel
                    {
                        Id = 4,
                        Company = 2010,
                        Url = "https://qrcode.autoexperts.parts/product/",
                        DateTimeSync = DateTime.Now,
                    },
                    new UrlModel
                    {
                        Id = 5,
                        Company = 2310,
                        Url = "https://qrcode.autoexperts.parts/product/",
                        DateTimeSync = DateTime.Now,
                    }
                };
            return urls.ToArray();
        }
    }
}

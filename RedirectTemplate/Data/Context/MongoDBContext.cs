using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedirectTemplate.Data.Context
{
    public class MongoDBContext : DbContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
        private IMongoDatabase _database { get; }

        public MongoDBContext(DbContextOptions<MongoDBContext> options) : base(options)
        {
            _database = Set();
        }

        private IMongoDatabase Set()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                return mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public IMongoCollection<BrandModel> Brands
        {
            get { return _database.GetCollection<BrandModel>("Brands"); }
        }

        public IMongoCollection<ProductModel> Products
        {
            get { return _database.GetCollection<ProductModel>("Products"); }
        }

        public IMongoCollection<CountryModel> Countries
        {
            get { return _database.GetCollection<CountryModel>("Countries"); }
        }
    }
}

using RedirectTemplate.Data;
using RedirectTemplate.Data.Context;
using RedirectTemplate.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedirectTemplate.Repository.MySQL
{
    public class ProductRepository : BaseRepository<ProductModel>, IProductRepository
    {
        public ProductRepository(MySQLContext mySQLContext) : base(mySQLContext)
        {
        }
        public ProductModel FindBySerie(string code, string serie) =>Find(p => (p.Company.Equals(int.Parse(code)) && p.Serie.Equals(serie)));
    }
}

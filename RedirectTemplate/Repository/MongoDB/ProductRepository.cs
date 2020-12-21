using RedirectTemplate.Data;
using RedirectTemplate.Data.Context;
using RedirectTemplate.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedirectTemplate.Repository.MongoDB
{
    public class ProductRepository : BaseRepository<ProductModel>, IProductRepository
    {
        public ProductRepository(MongoDBContext mongoDBContext) : base(mongoDBContext)
        {
        }
        public ProductModel FindBySerie(string code, string serie) => Find(p => (p.Company.Equals(code) && p.Serie.Equals(serie)));
    }
}

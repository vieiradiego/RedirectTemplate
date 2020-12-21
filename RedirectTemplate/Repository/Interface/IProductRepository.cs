using RedirectTemplate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedirectTemplate.Repository.Interface
{
    public interface IProductRepository : IRepository<ProductModel>
    {
        ProductModel FindBySerie(string code, string serie);
    }
}

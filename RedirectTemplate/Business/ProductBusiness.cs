using RedirectTemplate.Business.Interface;
using RedirectTemplate.Data;
using RedirectTemplate.Repository;
using RedirectTemplate.Repository.Interface;
using System;

namespace RedirectTemplate.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository _productRepository;
        public ProductBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ProductModel GetBySerie(string code, string serie)
        {
            return _productRepository.FindBySerie(code, serie);
        }
    }
}

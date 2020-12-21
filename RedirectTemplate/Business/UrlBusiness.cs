using RedirectTemplate.Business.Interface;
using RedirectTemplate.Data;
using RedirectTemplate.Repository;
using RedirectTemplate.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedirectTemplate.Business
{
    public class UrlBusiness : IUrlBusiness
    {
        private readonly IUrlRepository _urlRepository;
        public UrlBusiness(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public UrlModel GetByCompany(int company)
        {
            return _urlRepository.FindByCompany(company);
        }
        public string Arrange(ProductModel product, BrandModel brand, CountryModel country, UrlModel urlBase)
        {
            var urlMaked = $"{urlBase.Url}?company={product.Company}&serie={product.Serie}&brand={brand.Description}&product={product.ComercialName}&country={country.Alpha_2Code}";
            //urlMaked = "https://google.com.br";
            return urlMaked;
        }
    }
}

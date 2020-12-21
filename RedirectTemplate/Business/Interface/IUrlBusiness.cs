using RedirectTemplate.Data;

namespace RedirectTemplate.Business.Interface
{
    public interface IUrlBusiness
    {
        public UrlModel GetByCompany(int company);
        public string Arrange(ProductModel product, BrandModel brand, CountryModel country, UrlModel urlBase);
    }
}

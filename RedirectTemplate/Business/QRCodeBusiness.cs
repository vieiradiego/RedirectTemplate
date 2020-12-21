using RedirectTemplate.Business.Interface;
using RedirectTemplate.Data;
using RedirectTemplate.Data.Context;

namespace RedirectTemplate.Business
{
    public class QRCodeBusiness : IQRCodeBusiness

    {
        private readonly IBrandBusiness _brandBusiness;
        private readonly IProductBusiness _productBusiness;
        private readonly ICountryBusiness _countryBusiness;
        private readonly IUrlBusiness _urlBusiness;

        public QRCodeBusiness(IBrandBusiness brandBusiness, IProductBusiness productBusiness, ICountryBusiness countryBusiness, IUrlBusiness urlBusiness)
        {
            
            _brandBusiness = brandBusiness;
            _productBusiness = productBusiness;
            _countryBusiness = countryBusiness;
            _urlBusiness = urlBusiness;
        }

        public string Redirect(string code, string serie)
        {//serie=ABC123456789
            
            ProductModel p = _productBusiness.GetBySerie(code, serie);
            BrandModel b = _brandBusiness.GetByBrand(p.Brand);
            CountryModel c = _countryBusiness.GetByAlpha2(p.SapClientAlpha_2Code);
            UrlModel u = _urlBusiness.GetByCompany(p.Company);
            return _urlBusiness.Arrange (p, b, c, u);
        }
    }
}

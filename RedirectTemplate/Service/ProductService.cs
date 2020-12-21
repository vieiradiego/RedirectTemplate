using RedirectTemplate.Business;
using RedirectTemplate.Business.Interface;

namespace RedirectTemplate.Service
{
    public class ProductService : IProductService
    {
        private readonly IQRCodeBusiness _qrCodeBusiness;

        public ProductService(IQRCodeBusiness qrCodeBusiness)
        {
            _qrCodeBusiness = qrCodeBusiness;
        }
       
        public string Racks(string code, string serie)
        {
            return _qrCodeBusiness.Redirect(code, serie);
        }
    }
}

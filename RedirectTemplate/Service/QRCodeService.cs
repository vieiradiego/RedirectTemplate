using RedirectTemplate.Business;
using RedirectTemplate.Business.Interface;

namespace RedirectTemplate.Service
{
    public class QRCodeService : IQRCodeService
    {
        private readonly IQRCodeBusiness _qrCodeBusiness;

        public QRCodeService(IQRCodeBusiness qrCodeBusiness)
        {
            _qrCodeBusiness = qrCodeBusiness;
        }
       
        public string Racks(string code, string rack)
        {
            return _qrCodeBusiness.Redirect(code, rack);
        }
    }
}

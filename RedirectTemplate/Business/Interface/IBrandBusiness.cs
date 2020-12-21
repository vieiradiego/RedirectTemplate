using RedirectTemplate.Data;

namespace RedirectTemplate.Business.Interface
{
    public interface IBrandBusiness
    {
        BrandModel GetByBrand(string brand);
    }
}

using RedirectTemplate.Data;

namespace RedirectTemplate.Business.Interface
{
    public interface IProductBusiness
    {
        public ProductModel GetBySerie(string code, string serie);
    }
}

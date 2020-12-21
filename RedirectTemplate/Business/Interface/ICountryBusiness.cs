using RedirectTemplate.Data;

namespace RedirectTemplate.Business.Interface
{
    public interface ICountryBusiness
    {
        CountryModel GetByAlpha2(string sapClientAlpha_2Code);
    }
}

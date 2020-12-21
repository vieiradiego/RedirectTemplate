using RedirectTemplate.Business.Interface;
using RedirectTemplate.Data;
using RedirectTemplate.Repository.Interface;

namespace RedirectTemplate.Business
{
    public class CountryBusiness : ICountryBusiness
    {
        private readonly ICountryRepository _countryRepository;
        public CountryBusiness(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public CountryModel GetByAlpha2(string sapClientAlpha_2Code)
        {
            return _countryRepository.FindByAlpha2(sapClientAlpha_2Code);
        }
    }
}

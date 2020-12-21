using RedirectTemplate.Data;
using RedirectTemplate.Data.Context;
using RedirectTemplate.Repository.Interface;

namespace RedirectTemplate.Repository.MySQL
{
    public class CountryRepository : BaseRepository<CountryModel>, ICountryRepository
    {
        public CountryRepository(MySQLContext mySQLContext) : base(mySQLContext)
        {
            
        }
        public CountryModel FindByAlpha2(string alpha2) => Find(p => p.Alpha_2Code.Equals(alpha2));
    }
}

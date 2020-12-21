using RedirectTemplate.Data;
using RedirectTemplate.Data.Context;
using RedirectTemplate.Repository.Interface;

namespace RedirectTemplate.Repository.MongoDB
{
    public class CountryRepository : BaseRepository<CountryModel>, ICountryRepository
    {
        public CountryRepository(MongoDBContext mongoDBContext) : base(mongoDBContext)
        {

        }
        public CountryModel FindByAlpha2(string alpha2) => Find(p => p.Alpha_2Code.Equals(alpha2));
    }
}

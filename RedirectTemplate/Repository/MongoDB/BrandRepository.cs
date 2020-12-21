using RedirectTemplate.Data;
using RedirectTemplate.Data.Context;
using RedirectTemplate.Repository.Interface;

namespace RedirectTemplate.Repository.MongoDB
{
    public class BrandRepository : BaseRepository<BrandModel>, IBrandRepository
    {
        public BrandRepository(MongoDBContext mongoDBContext) : base(mongoDBContext)
        {

        }
        public BrandModel FindByBrand(string code) => Find(p => p.Code.Equals(code));
    }
}

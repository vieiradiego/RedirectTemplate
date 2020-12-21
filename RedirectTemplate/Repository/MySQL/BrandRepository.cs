using RedirectTemplate.Data;
using RedirectTemplate.Data.Context;
using RedirectTemplate.Repository.Interface;

namespace RedirectTemplate.Repository.MySQL
{
    public class BrandRepository : BaseRepository<BrandModel>, IBrandRepository
    {
        public BrandRepository(MySQLContext mySQLContext) : base(mySQLContext)
        {
            
        }
        public BrandModel FindByBrand(string code) => Find(p => p.Code.Equals(code));
    }
}

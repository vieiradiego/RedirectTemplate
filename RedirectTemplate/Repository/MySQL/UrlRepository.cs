using RedirectTemplate.Data;
using RedirectTemplate.Data.Context;
using RedirectTemplate.Repository.Interface;

namespace RedirectTemplate.Repository.MySQL
{
    public class UrlRepository : BaseRepository<UrlModel>, IUrlRepository
    {
        public UrlRepository(MySQLContext mySQLContext) : base(mySQLContext)
        {
        }
        public UrlModel FindByCompany(int company) =>Find(p => p.Company.Equals(company));
    }
}

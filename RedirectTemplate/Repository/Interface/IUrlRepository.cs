using RedirectTemplate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedirectTemplate.Repository.Interface
{
    public interface IUrlRepository : IRepository<UrlModel>
    {
        UrlModel FindByCompany(int company);
    }
}

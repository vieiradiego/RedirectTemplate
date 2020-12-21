using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedirectTemplate.Business.Interface
{
    public interface IQRCodeBusiness
    {
        string Redirect(string code, string serie);
    }
}

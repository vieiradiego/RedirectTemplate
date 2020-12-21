using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedirectTemplate.Data
{
    public class ProductModel : BaseEntityModel
    {
        public int Company { get; set; }
        public string Serie { get; set; }
        public string ComercialName { get; set; }
        public string Brand { get; set; }
        public string SapIdClient { get; set; }
        public string SapClientAlpha_2Code { get; set; }
    }
}

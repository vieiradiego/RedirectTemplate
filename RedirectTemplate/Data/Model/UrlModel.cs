using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RedirectTemplate.Data
{
    public class UrlModel : BaseEntityModel
    {
        public int Company { get; set; }
        public string Url { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedirectTemplate.Data
{
    public class CountryModel : BaseEntityModel
    {
        public string Name { get; set; }
        public string Alpha_2Code { get; set; }
        public string Alpha_3Code { get; set; }
        public int NumericCode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}

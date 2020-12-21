using RedirectTemplate.Business.Interface;
using RedirectTemplate.Data;
using RedirectTemplate.Repository;
using RedirectTemplate.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedirectTemplate.Business
{
    public class BrandBusiness : IBrandBusiness
    {
        private readonly IBrandRepository _brandRepository;
        public BrandBusiness(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public BrandModel GetByBrand(string brand)
        {
            return _brandRepository.FindByBrand(brand);
        }
    }
}

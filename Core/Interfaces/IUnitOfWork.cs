using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepo<Product> Products {get;}
        public IGenericRepo<ProductBrand> ProductBrands {get;}
        public IGenericRepo<ProductType> ProductTypes {get;}
        int Complete();
    }
}
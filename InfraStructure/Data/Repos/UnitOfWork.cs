using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Entities;
using Core.Interfaces;
using InfraStructure.Repos;
using InfraStucture.Data;

namespace InfraStructure.Data.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        public IGenericRepo<Product> Products { get; private set; }

        public IGenericRepo<ProductBrand> ProductBrands { get; private set; }

        public IGenericRepo<ProductType> ProductTypes { get; private set; }

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;

            Products = new GenericRepo<Product>(_context);
            ProductBrands = new GenericRepo<ProductBrand>(_context);
            ProductTypes = new GenericRepo<ProductType>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
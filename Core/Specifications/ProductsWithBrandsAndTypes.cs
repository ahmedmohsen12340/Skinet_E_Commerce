using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Helpers;

namespace Core.Specifications
{
    public class ProductsWithBrandsAndTypes : BaseSpecifications<Product>
    {
        public ProductsWithBrandsAndTypes(ProductsSpecParams productsParams)
        : base(p =>
        (string.IsNullOrEmpty(productsParams.Search) || p.Name.ToLower().Contains(productsParams.Search)) &&
        (!productsParams.BrandId.HasValue || p.ProductBrandId == productsParams.BrandId) &&
        (!productsParams.TypeId.HasValue || p.ProductTypeId == productsParams.TypeId)
        )
        {
            if (productsParams.PageSize.HasValue && productsParams.PageIndex.HasValue)
            {
                IsPagingEnabled = true;
                PageSize = productsParams.PageSize;
                PageIndex = productsParams.PageIndex;
            }
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
            switch (productsParams.Sort)
            {
                case "priceAsc":
                    OrderBy = p => p.Price;
                    break;
                case "priceDesc":
                    OrderBy = p => p.Price;
                    OrderByType = Order.Desc;
                    break;
                case "name":
                    OrderBy = p => p.Name;
                    OrderByType = Order.Asc;
                    break;

                default:
                    OrderBy = p => p.Name;
                    break;
            }
        }
        public ProductsWithBrandsAndTypes(int id) : base(p => p.Id == id) { }
    }
}
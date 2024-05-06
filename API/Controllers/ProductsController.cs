
using InfraStucture.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core;
using Microsoft.AspNetCore.Routing.Constraints;
using Core.Specifications;
using Core.Interfaces;
using AutoMapper;
using API.DTOs;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var productsWithBrandsAndTypes = new BaseSpecifications<Product>();
            productsWithBrandsAndTypes.AddInclude(p => p.ProductBrand);
            productsWithBrandsAndTypes.AddInclude(p => p.ProductType);
            var products = await _unitOfWork.Products.ListAllAsync(productsWithBrandsAndTypes);
            var poductsDTO = _mapper.Map<IEnumerable<Product>,IEnumerable<ProductDTO>>(products);
            return Ok(poductsDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var productsWithBrandsAndTypes = new BaseSpecifications<Product>(p => p.Id == id);
            productsWithBrandsAndTypes.AddInclude(p => p.ProductBrand);
            productsWithBrandsAndTypes.AddInclude(p => p.ProductType);
            var product = await _unitOfWork.Products.GetEntityWithSpec(productsWithBrandsAndTypes);
            return _mapper.Map<Product,ProductDTO>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var spec = new BaseSpecifications<ProductBrand>();
            var productBrands = await _unitOfWork.ProductBrands.ListAllAsync(spec);
            return Ok(productBrands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var spec = new BaseSpecifications<ProductType>();
            var productTypes = await _unitOfWork.ProductTypes.ListAllAsync(spec);
            return Ok(productTypes);
        }
    }
}

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
using API.Helpers;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery] ProductsSpecParams productsParams)
        {
            var productsWithBrandsAndTypes = new ProductsWithBrandsAndTypes(productsParams);
            var products = await _unitOfWork.Products.ListAllAsync(productsWithBrandsAndTypes);
            var count = _unitOfWork.Products.GetCount();
            var poductsDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            var result = new Pagination<ProductDTO>(productsParams.PageIndex.Value,productsParams.PageSize.Value,count,poductsDTO);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var productWithBrandsAndTypes = new ProductsWithBrandsAndTypes(id);
            var product = await _unitOfWork.Products.GetEntityWithSpec(productWithBrandsAndTypes);
            return _mapper.Map<Product, ProductDTO>(product);
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
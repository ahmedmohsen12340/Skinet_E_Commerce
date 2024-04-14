
using InfraStucture.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepo<Product> _productRepo;

        private readonly IGenericRepo<ProductBrand> _productBrandRepo;

        public ProductsController(IProductRepository productRepository,IGenericRepo<Product> productRepo,IGenericRepo<ProductBrand> productBrandRepo)
        {
            _productBrandRepo = productBrandRepo;
            _productRepository = productRepository;
            _productRepo = productRepo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            return Ok(products);
            // return "no Prolem";
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var brands = await _productRepository.GetProductBrandsAsync();
            return Ok(brands);
            // return "no Prolem";
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var Types = await _productRepository.GetProductTypesAsync();
            return Ok(Types);
            // return "no Prolem";
        }

    }
}
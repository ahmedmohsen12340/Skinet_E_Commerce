using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using InfraStucture.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreDbContext _storeDbContext;
        public BuggyController(StoreDbContext storeDbContext){
            _storeDbContext = storeDbContext;
        }
        [HttpGet("notfound")]
        public IActionResult GetNotFound(){
            var product =_storeDbContext.Products.Find(42);
            if(product!=null){
                return Ok(product);
            }
            return NotFound(new ApiResponse(404));
        }
        [HttpGet("servererror")]
        public IActionResult GetServerError(){
            var product =_storeDbContext.Products.Find(42);
            return Ok(product.Description);
        }

        [HttpGet("badrequest")]
        public IActionResult GetbadRequest(){
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public IActionResult GetbadRequest(int id){
            return Ok();
        }

    }
}
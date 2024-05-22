using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class BasketController : BaseApiController
    {
        private readonly IBasketRepo _basketRepo;
        public BasketController(IBasketRepo basketRepo)
        {
            _basketRepo = basketRepo;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
        {
            var basket = await _basketRepo.GetCustomerBasket(id);
            return Ok(basket ?? new CustomerBasket(id));
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket customerBasket)
        {
            var basket = await _basketRepo.UpdateCustomerBasket(customerBasket);
            return Ok(basket);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(string id)
        {
            await _basketRepo.DeleteCustomerBasket(id);
            return NoContent();
        }
    }
}
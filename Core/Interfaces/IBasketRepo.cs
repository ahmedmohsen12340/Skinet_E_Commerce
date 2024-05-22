using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBasketRepo
    {
        Task<CustomerBasket> GetCustomerBasket(string id);
        Task<CustomerBasket> UpdateCustomerBasket(CustomerBasket customerBasket);
        Task<bool> DeleteCustomerBasket(string id);
    }
}
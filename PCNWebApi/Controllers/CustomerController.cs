using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PCNWebApi.Models;
using PCNWebApi.Response;

namespace PCNWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        
        private readonly ILogger<CustomerController> _logger;
        private readonly PCNPublicDBContext _context;

        public CustomerController(ILogger<CustomerController> logger,PCNPublicDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// This GET method returns Customer details by Id
        /// </summary>
        /// <returns>Customer details</returns>
        [HttpGet]
        public async Task<CustomerResponse> GetCustomerById(int customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
            if (customer == null)
            {
                return null;
            }
            var customerResponse = new CustomerResponse()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                Street = customer.Street,
                City = customer.City,
                State = customer.State,
                ZipCode = customer.ZipCode
            };
            return customerResponse;
        }

    }
}

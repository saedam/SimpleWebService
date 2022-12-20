using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebService.BL;
using SimpleWebService.BL.Exceptions;
using SimpleWebService.DAL;
using SimpleWebService.Models.Entities;
using SimpleWebService.Models.Requests;

namespace SimpleWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly SimpleDBContext _context;

        private readonly CustomersManager _customersManager;

        public CustomersController(SimpleDBContext context)
        {
            _context = context;
            _customersManager = new CustomersManager(context);
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(string id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(AddCustomerRequest request)
        {
            try
            {
                var response = await _customersManager.AddCustomer(request);

                return CreatedAtAction(nameof(GetCustomer), new { id = request?.Customer?.CustomerId }, null);
            }
            catch (BLException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private bool CustomerExists(string id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }

    }
}

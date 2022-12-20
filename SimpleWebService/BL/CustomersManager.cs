using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebService.BL.Exceptions;
using SimpleWebService.DAL;
using SimpleWebService.Models.Entities;
using SimpleWebService.Models.Requests;
using SimpleWebService.Models.Responses;
using System.Net;

namespace SimpleWebService.BL
{
    public class CustomersManager
    {
        private SimpleDBContext _context;
        public CustomersManager(SimpleDBContext dbContext)
        {
            this._context = dbContext;
        }
        public async Task<AddCustomerResponse> AddCustomer(AddCustomerRequest request)
        {

            if (!_context.Factories.Any(f => f.FactoryCode == request.FactoryCode))
            {
                throw new BLException($"Factory {request.FactoryCode} doesn't exist");
            }
            else if (!_context.Groups.Any(g => g.GroupCode == request.GroupCode))
            {
                throw new BLException($"Group {request.GroupCode} doesn't exist");
            }
            else if (request.Customer?.CustomerId == null)
            {
                throw new BLException($"Customer ID is empty");
            }
            else if (_context.Customers.Any(c => c.CustomerId == request.Customer.CustomerId))
            {
                throw new BLException($"Customer '{request.Customer.CustomerId}' already exists");
            }
            else
            {
                //add customer
                await _context.Customers.AddAsync(request.Customer);
                //link customer to factory and group
                await _context.FactoriesToCustomer.AddAsync(new FactoriesToCustomer()
                {
                    CustomerId = request.Customer.CustomerId,
                    FactoryCode = request.FactoryCode,
                    GroupCode = request.GroupCode
                }
                );

                await _context.SaveChangesAsync();

                return new AddCustomerResponse() { Customer = request.Customer };
            }

        }
    }
}

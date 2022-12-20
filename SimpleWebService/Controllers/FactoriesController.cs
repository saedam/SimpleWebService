using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebService.DAL;
using SimpleWebService.Models.Entities;

namespace SimpleWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoriesController : ControllerBase
    {
        private readonly SimpleDBContext _context;

        public FactoriesController(SimpleDBContext context)
        {
            _context = context;
        }

        // GET: api/Factories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factory>>> GetFactories()
        {
            return await _context.Factories.ToListAsync();
        }

        // GET: api/Factories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factory>> GetFactory(int? id)
        {
            var factory = await _context.Factories.FindAsync(id);

            if (factory == null)
            {
                return NotFound();
            }

            return factory;
        }


        // POST: api/Factories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Factory>> PostFactory(Factory factory)
        {
            _context.Factories.Add(factory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactory", new { id = factory.FactoryCode }, factory);
        }

        private bool FactoryExists(int? id)
        {
            return _context.Factories.Any(e => e.FactoryCode == id);
        }
    }
}

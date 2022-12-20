using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleWebService.BL;
using SimpleWebService.DAL;
using SimpleWebService.Models.Entities;
using SimpleWebService.Models.Responses;

namespace SimpleWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly SimpleDBContext _context;
        private readonly GroupsManager groupsManager;

        public GroupsController(SimpleDBContext context)
        {
            _context = context;
            groupsManager = new GroupsManager(context);
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        // GET: api/Groups/CustomersGroups
        [HttpGet("CustomersGroups")]
        public ActionResult<GetCustomersGroupsResponse> GetCustomersGroups()
        {
            return groupsManager.GetCustomersGroups();
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            var @group = await _context.Groups.FindAsync(id);

            if (@group == null)
            {
                return NotFound();
            }

            return @group;
        }


        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group @group)
        {
            _context.Groups.Add(@group);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup", new { id = @group.GroupCode }, @group);
        }


        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.GroupCode == id);
        }
    }
}

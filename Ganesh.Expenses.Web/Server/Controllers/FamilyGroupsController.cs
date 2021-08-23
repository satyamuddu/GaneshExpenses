using Ganesh.Expenses.Web.Server.Repository;
using Ganesh.Expenses.Web.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ganesh.Expenses.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyGroupsController : ControllerBase
    {
        private readonly IFamilyGroupRepository repository;

        public FamilyGroupsController(IFamilyGroupRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/FamilyGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyGroup>>> GetFamilyGroup()
        {
            return await repository.GetFamilyGroup();
        }

        // GET: api/FamilyGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyGroup>> GetFamilyGroup(int id)
        {
            var FamilyGroup = await repository.GetFamilyGroup(id);

            if (FamilyGroup == null)
            {
                return NotFound();
            }

            return FamilyGroup;
        }

        // PUT: api/FamilyGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFamilyGroup(int id, FamilyGroup FamilyGroup)
        {
            if (id != FamilyGroup.Id)
            {
                return BadRequest();
            }
            return await repository.PutFamilyGroup(id, FamilyGroup);
        }

        // POST: api/FamilyGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FamilyGroup>> PostFamilyGroup(FamilyGroup FamilyGroup)
        {
            await repository.PostFamilyGroup(FamilyGroup);

            return CreatedAtAction("GetFamilyGroup", new { id = FamilyGroup.Id }, FamilyGroup);
        }

        // DELETE: api/FamilyGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamilyGroup(int id)
        {
            return await repository.DeleteFamilyGroup(id);
        }
    }
}

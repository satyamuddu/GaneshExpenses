using Ganesh.Expenses.Web.Server.Data;
using Ganesh.Expenses.Web.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ganesh.Expenses.Web.Server.Repository;

namespace Ganesh.Expenses.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationTypesController : ControllerBase
    {
        private readonly IRelationTypeRepository incomeRepository;

        public RelationTypesController(IRelationTypeRepository incomeRepository)
        {
            this.incomeRepository = incomeRepository;
        }

        // GET: api/RelationTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelationType>>> GetRelationType()
        {
            return await incomeRepository.GetRelationType();
        }

        // GET: api/RelationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RelationType>> GetRelationType(int id)
        {
            var RelationType = await incomeRepository.GetRelationType(id);

            if (RelationType == null)
            {
                return NotFound();
            }

            return RelationType;
        }

        // PUT: api/RelationTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelationType(int id, RelationType RelationType)
        {
            if (id != RelationType.Id)
            {
                return BadRequest();
            }
            return await incomeRepository.PutRelationType(id, RelationType);
        }

        // POST: api/RelationTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RelationType>> PostRelationType(RelationType RelationType)
        {
            await incomeRepository.PostRelationType(RelationType);

            return CreatedAtAction("GetRelationType", new { id = RelationType.Id }, RelationType);
        }

        // DELETE: api/RelationTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelationType(int id)
        {
            return await incomeRepository.DeleteRelationType(id);
        }
    }
}

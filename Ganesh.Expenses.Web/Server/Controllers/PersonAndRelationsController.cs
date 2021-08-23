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
    public class PersonAndRelationsController : ControllerBase
    {
        private readonly IPersonAndRelationRepository incomeRepository;

        public PersonAndRelationsController(IPersonAndRelationRepository incomeRepository)
        {
            this.incomeRepository = incomeRepository;
        }

        // GET: api/PersonAndRelations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonAndRelation>>> GetPersonAndRelation()
        {
            return await incomeRepository.GetPersonAndRelation();
        }

        // GET: api/PersonAndRelations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonAndRelation>> GetPersonAndRelation(int id)
        {
            var PersonAndRelation = await incomeRepository.GetPersonAndRelation(id);

            if (PersonAndRelation == null)
            {
                return NotFound();
            }

            return PersonAndRelation;
        }

        // PUT: api/PersonAndRelations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonAndRelation(int id, PersonAndRelation PersonAndRelation)
        {
            if (id != PersonAndRelation.Id)
            {
                return BadRequest();
            }
            return await incomeRepository.PutPersonAndRelation(id, PersonAndRelation);
        }

        // POST: api/PersonAndRelations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonAndRelation>> PostPersonAndRelation(PersonAndRelation PersonAndRelation)
        {
            await incomeRepository.PostPersonAndRelation(PersonAndRelation);

            return CreatedAtAction("GetPersonAndRelation", new { id = PersonAndRelation.Id }, PersonAndRelation);
        }

        // DELETE: api/PersonAndRelations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonAndRelation(int id)
        {
            return await incomeRepository.DeletePersonAndRelation(id);
        }
    }
}

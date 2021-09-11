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
    public class CreditsController : ControllerBase
    {
        private readonly ICreditRepository incomeRepository;

        public CreditsController(ICreditRepository incomeRepository)
        {
            this.incomeRepository = incomeRepository;
        }

        // GET: api/Credits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Credit>>> GetCredit()
        {
            return await incomeRepository.GetCredit();
        }

        // GET: api/Credits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Credit>> GetCredit(int id)
        {
            var Credit = await incomeRepository.GetCredit(id);

            if (Credit == null)
            {
                return NotFound();
            }

            return Credit;
        }

        // PUT: api/Credits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCredit(int id, Credit Credit)
        {
            if (id != Credit.Id)
            {
                return BadRequest();
            }
            return await incomeRepository.PutCredit(id, Credit);
        }

        // POST: api/Credits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Credit>> PostCredit(Credit Credit)
        {
            await incomeRepository.PostCredit(Credit);

            return CreatedAtAction("GetCredit", new { id = Credit.Id }, Credit);
        }

        // DELETE: api/Credits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCredit(int id)
        {
            return await incomeRepository.DeleteCredit(id);
        }
    }
}

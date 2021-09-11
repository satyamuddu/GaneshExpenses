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
    public class DebitsController : ControllerBase
    {
        private readonly IDebitRepository incomeRepository;

        public DebitsController(IDebitRepository incomeRepository)
        {
            this.incomeRepository = incomeRepository;
        }

        // GET: api/Debits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Debit>>> GetDebit()
        {
            return await incomeRepository.GetDebit();
        }

        // GET: api/Debits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Debit>> GetDebit(int id)
        {
            var Debit = await incomeRepository.GetDebit(id);

            if (Debit == null)
            {
                return NotFound();
            }

            return Debit;
        }

        // PUT: api/Debits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDebit(int id, Debit Debit)
        {
            if (id != Debit.Id)
            {
                return BadRequest();
            }
            return await incomeRepository.PutDebit(id, Debit);
        }

        // POST: api/Debits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Debit>> PostDebit(Debit Debit)
        {
            await incomeRepository.PostDebit(Debit);

            return CreatedAtAction("GetDebit", new { id = Debit.Id }, Debit);
        }

        // DELETE: api/Debits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDebit(int id)
        {
            return await incomeRepository.DeleteDebit(id);
        }
    }
}

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
    public class TransactionModesController : ControllerBase
    {
        private readonly ITransactionModeRepository repoistory;

        public TransactionModesController(ITransactionModeRepository repository)
        {
            this.repoistory = repository;
        }

        // GET: api/TransactionModes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionMode>>> GetTransactionMode()
        {
            return await repoistory.GetTransactionMode();
        }

        // GET: api/TransactionModes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionMode>> GetTransactionMode(int id)
        {
            var TransactionMode = await repoistory.GetTransactionMode(id);

            if (TransactionMode == null)
            {
                return NotFound();
            }

            return TransactionMode;
        }

        // PUT: api/TransactionModes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionMode(int id, TransactionMode TransactionMode)
        {
            if (id != TransactionMode.Id)
            {
                return BadRequest();
            }
            return await repoistory.PutTransactionMode(id, TransactionMode);
        }

        // POST: api/TransactionModes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionMode>> PostTransactionMode(TransactionMode TransactionMode)
        {
            await repoistory.PostTransactionMode(TransactionMode);

            return CreatedAtAction("GetTransactionMode", new { id = TransactionMode.Id }, TransactionMode);
        }

        // DELETE: api/TransactionModes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionMode(int id)
        {
            return await repoistory.DeleteTransactionMode(id);
        }
    }
}

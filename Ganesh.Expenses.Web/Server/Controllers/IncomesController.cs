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
    public class IncomesController : ControllerBase
    {
        private readonly IIncomeRepository incomeRepository;

        public IncomesController(IIncomeRepository incomeRepository)
        {
            this.incomeRepository = incomeRepository;
        }

        // GET: api/Incomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Income>>> GetIncome()
        {
            return await incomeRepository.GetIncome();
        }

        // GET: api/Incomes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Income>> GetIncome(int id)
        {
            var Income = await incomeRepository.GetIncome(id);

            if (Income == null)
            {
                return NotFound();
            }

            return Income;
        }

        // PUT: api/Incomes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncome(int id, Income Income)
        {
            if (id != Income.Id)
            {
                return BadRequest();
            }
            return await incomeRepository.PutIncome(id, Income);
        }

        // POST: api/Incomes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Income>> PostIncome(Income Income)
        {
            await incomeRepository.PostIncome(Income);
            
            return CreatedAtAction("GetIncome", new { id = Income.Id }, Income);
        }

        // DELETE: api/Incomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            return await incomeRepository.DeleteIncome(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ganesh.Expenses.Web.Server.Data;
using Ganesh.Expenses.Web.Shared;

namespace Ganesh.Expenses.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeTypesController : ControllerBase
    {
        private readonly GaneshExpensesWebServerContext _context;

        public IncomeTypesController(GaneshExpensesWebServerContext context)
        {
            _context = context;
        }

        // GET: api/IncomeTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncomeType>>> GetIncomeType()
        {
            return await _context.IncomeType.ToListAsync();
        }

        // GET: api/IncomeTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncomeType>> GetIncomeType(int id)
        {
            var incomeType = await _context.IncomeType.FindAsync(id);

            if (incomeType == null)
            {
                return NotFound();
            }

            return incomeType;
        }

        // PUT: api/IncomeTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncomeType(int id, IncomeType incomeType)
        {
            if (id != incomeType.Id)
            {
                return BadRequest();
            }

            _context.Entry(incomeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IncomeTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IncomeType>> PostIncomeType(IncomeType incomeType)
        {
            _context.IncomeType.Add(incomeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncomeType", new { id = incomeType.Id }, incomeType);
        }

        // DELETE: api/IncomeTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncomeType(int id)
        {
            var incomeType = await _context.IncomeType.FindAsync(id);
            if (incomeType == null)
            {
                return NotFound();
            }

            _context.IncomeType.Remove(incomeType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncomeTypeExists(int id)
        {
            return _context.IncomeType.Any(e => e.Id == id);
        }
    }
}
